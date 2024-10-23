using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossHumanoid : MonoBehaviour
{
    public float health = 100f;
    public Slider HealthUI;
    [Space(20)]
    public GameObject BoomPfeb;
    public BoxCollider2D RangeBoom;
    public GameObject Player;
    public GameObject Mark;
    public Collider2D Hitboxrush;
    public static BossHumanoid bossHumanoid;
    bool db_BSpawn = false;
    bool db_Dashing = false;
    void Start()
    {
        if (bossHumanoid == null)
        {
            bossHumanoid = gameObject.GetComponent<BossHumanoid>();
        }
    }

    void Update ()
    {
        if (db_BSpawn == false)
        {
            StartCoroutine(Boom());
        }
        if (db_Dashing == false)
        {
            StartCoroutine(Dash());
        }
        HealthUI.value = health;
    }

    void Dashing(Vector2 Pos)
    {
        transform.position = Vector2.MoveTowards(transform.position, Pos, 5 * Time.deltaTime);
    }

    IEnumerator Dash()
    {
        Debug.Log("Dashing");
        db_Dashing = true;
        Vector2 playerPos = Player.transform.position;
        GameObject Markobj = Instantiate(Mark, transform.parent);
        Markobj.transform.position = playerPos;
        yield return new WaitForSeconds(1.5f);
        Hitboxrush.enabled = true;
        Destroy(Markobj);
        for (int i = 1;i<500; i++)
        {
            Dashing(playerPos);
            yield return new WaitForSeconds(0);
        }
        Hitboxrush.enabled = false;
        yield return new WaitForSeconds(5);
        db_Dashing = false;
    }

    IEnumerator Boom()
    {   
        db_BSpawn = true;
        for (int i = 1;i<25;i++)
        {
            GameObject Obj = Instantiate(BoomPfeb, transform.parent);
            Obj.transform.position = new Vector3(Random.Range(RangeBoom.transform.position.x - RangeBoom.size.x/2,RangeBoom.transform.position.x + RangeBoom.size.y/2),Random.Range(RangeBoom.transform.position.y - RangeBoom.size.y/2,RangeBoom.transform.position.y + RangeBoom.size.y/2),0);
            yield return new WaitForSeconds(.25f);
        }
        yield return new WaitForSeconds(10f);
        db_BSpawn = false;
    }


    public void TakeDamage(float Dmg)
    {
        health -= Dmg;
    }
}

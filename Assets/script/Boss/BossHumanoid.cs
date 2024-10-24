using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHumanoid : MonoBehaviour
{
    public float health = 100f;
    public Slider HealthUI;
    public bool Fadetwo = false;
    [Space(20)]
    public bool Starting = false;
    public GameObject BoomPfeb;
    public BoxCollider2D RangeBoom;
    public GameObject Player;
    public GameObject Mark;
    public GameObject RageEffect;
    public Collider2D Hitboxrush;
    public static BossHumanoid bossHumanoid;
    bool db_BSpawn = false;
    bool db_Dashing = false;

    bool db_BSpawn_Lock = false;
    bool db_DashingBoosting = false;
    void Start()
    {
        if (bossHumanoid == null)
        {
            bossHumanoid = gameObject.GetComponent<BossHumanoid>();
        }
        StartCoroutine(WaitForStart ());
    }

    void Update ()
    {   
        if (Starting == true)
        {
            if (db_BSpawn == false)
            {
                StartCoroutine(Boom());
            }
            if (db_Dashing == false && Fadetwo == false)
            {
                StartCoroutine(Dash());
            }
            //Fade 2
            if (db_BSpawn_Lock == false && Fadetwo == true)
            {
                StartCoroutine(BoomLock());
            }
            if (db_DashingBoosting == false && Fadetwo == true)
            {
                StartCoroutine(DashBoosting());
            }

            if (health <= 0 && Fadetwo == false)
            {
                Fadetwo = true;
                health = 150;
                HealthUI.maxValue = 150;
                RageEffect.SetActive(true);
                SoundAudioManager.soundAudioManager.Play_Sound("Roar", 3);
            }
            if (health == 0 && Fadetwo == true)
            {
                SceneManager.LoadScene("RealEnding");
            }
        }

        HealthUI.value = health;
    }

    void Dashing(Vector2 Pos)
    {
        transform.position = Vector2.MoveTowards(transform.position, Pos, 5 * Time.deltaTime);
    }
    void DashingBoosting(Vector2 Pos)
    {
        transform.position = Vector2.MoveTowards(transform.position, Pos, 10 * Time.deltaTime);
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
    IEnumerator DashBoosting()
    {
        Debug.Log("Dashing");
        db_DashingBoosting = true;
        Vector2 playerPos = Player.transform.position;
        GameObject Markobj = Instantiate(Mark, transform.parent);
        Markobj.transform.position = playerPos;
        yield return new WaitForSeconds(.7f);
        Hitboxrush.enabled = true;
        Destroy(Markobj);
        for (int i = 1;i<150; i++)
        {
            DashingBoosting(playerPos);
            yield return new WaitForSeconds(0);
        }
        Hitboxrush.enabled = false;
        yield return new WaitForSeconds(.1f);
        db_DashingBoosting = false;
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

    IEnumerator BoomLock()
    {   
        db_BSpawn_Lock = true;
        for (int i = 1;i<20;i++)
        {
            GameObject Obj = Instantiate(BoomPfeb, transform.parent);
            Obj.transform.position = Player.transform.position;
            yield return new WaitForSeconds(.25f);
        }
        yield return new WaitForSeconds(5f);
        db_BSpawn_Lock = false;
    }


    IEnumerator WaitForStart ()
    {
        yield return new WaitForSeconds(3);
        Starting = true;
    }

}

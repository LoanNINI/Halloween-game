using UnityEngine;

public class Bullet : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.transform.tag == "Boss")
        {
            Debug.Log("hitBoss");
            //ObjSever.objsever.Restart.SetActive(true);
            col.GetComponent<BossHumanoid>().health -= 5f;
            //SoundAudioManager.soundAudioManager.Play_Sound("HIT", 2);
        }
    }
    void Start()
    {
        Destroy(gameObject, .25f);
    }
}

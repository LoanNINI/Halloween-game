using NUnit.Framework;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public bool onetime = false;
    bool hitted = false;
    void OnTriggerEnter2D (Collider2D col)
    {
        if (onetime == false)
        {
            if (col.transform.tag == "Player" && hitted == false)
            {
                hitted = true;
                //ObjSever.objsever.Restart.SetActive(true);
                col.GetComponent<Health>().Health_HP -= 20f;
                SoundAudioManager.soundAudioManager.Play_Sound("HIT", 2);
            }
        }
        else
        {
            if (col.transform.tag == "Player")
            {
                hitted = true;
                //ObjSever.objsever.Restart.SetActive(true);
                col.GetComponent<Health>().Health_HP -= 20f;
                SoundAudioManager.soundAudioManager.Play_Sound("HIT", 2);
            }
        }
    }
}

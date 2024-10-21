using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class RoomGhost : MonoBehaviour
{
    public float countdown = 5;
    public float speed = 2f;
    public Light2D Light_Main;
    public GameObject Ghost;
    public GameObject Pos1;
    public GameObject Pos2;

    bool PlayerIn = false;
    bool dbCount = false;
    bool lightOut = false;
    bool GhostMovingUp = false;
    bool GhostMovingDown = false;



    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            PlayerIn = true;
        }
    }
    void OnTriggerExit2D (Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            PlayerIn = false;
        }
    }
    void Update()
    {
        if (dbCount == false && countdown > 0 && lightOut == false && GhostMovingUp == false && PlayerIn == true)
        {
            StartCoroutine(Time_Count());
        }

        if (countdown <= 0 && lightOut == false && GhostMovingUp == false)
        {
            LigtOut ();
        }



        if (GhostMovingUp == true && Ghost.transform.position != new Vector3(Pos1.transform.position.x,Pos1.transform.position.y,Ghost.transform.position.z))
        {
            Ghost.transform.position = Vector3.MoveTowards(Ghost.transform.position, Pos1.transform.position, speed * Time.deltaTime);
        }
        if (GhostMovingUp == true && Ghost.transform.position == new Vector3(Pos1.transform.position.x,Pos1.transform.position.y,Ghost.transform.position.z))
        {
            GhostMovingUp = false;
            GhostMovingDown = true;
        }



        if (GhostMovingDown == true && Ghost.transform.position != new Vector3(Pos2.transform.position.x,Pos2.transform.position.y,Ghost.transform.position.z))
        {
            Ghost.transform.position = Vector3.MoveTowards(Ghost.transform.position, Pos2.transform.position, speed * Time.deltaTime);
        }
        if (GhostMovingDown == true && Ghost.transform.position == new Vector3(Pos2.transform.position.x,Pos2.transform.position.y,Ghost.transform.position.z))
        {
            lightOut = false;
            Light_Main.enabled = true;
            GhostMovingUp = false;
            GhostMovingDown = false;
        }
    }



    void LigtOut ()
    {
        lightOut = true;
        StartCoroutine(Lightouting());
    }
    IEnumerator Lightouting ()
    {   
        for (int i = 0; i<7;i++)
        {
            Light_Main.enabled = false;
            yield return new WaitForSeconds(.1f);
            Light_Main.enabled = true;
            yield return new WaitForSeconds(.1f);
        }
        Light_Main.enabled = false;
        yield return new WaitForSeconds(.5f);
        countdown = 10f;
        SoundAudioManager.soundAudioManager.Play_Sound("Ghost", 10);
        GhostMovingUp = true;
    }





    IEnumerator Time_Count ()
    {
        dbCount = true;
        countdown -= 1;
        yield return new WaitForSeconds(1);
        dbCount = false;
    }
}

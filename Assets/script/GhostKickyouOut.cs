using UnityEngine;

public class GhostKickyouOut : MonoBehaviour
{
    public GameObject Posout;
    public LockPuzzle NearPuzzle;
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.transform.tag == "Player" && col.gameObject.GetComponent<Humanoid_Player>().Hidding == false)
        {
            col.transform.position = Posout.transform.position;
            col.GetComponent<Humanoid_Player>().State_Game = false;
            ObjSever.objsever.Restart.SetActive(true);
            SoundAudioManager.soundAudioManager.Play_Sound("Scream", 2);
            if (NearPuzzle != null)
            {
                NearPuzzle.StopLockpick();
            }
        }
    }

}

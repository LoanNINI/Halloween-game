using UnityEngine;

public class GhostKickyouOut : MonoBehaviour
{
    public GameObject Posout;
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.transform.tag == "Player" && col.gameObject.GetComponent<Humanoid_Player>().Hidding == false)
        {
            col.transform.position = Posout.transform.position;
            col.GetComponent<Humanoid_Player>().State_Game = false;
        }
    }

}

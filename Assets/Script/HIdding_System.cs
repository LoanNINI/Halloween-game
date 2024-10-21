using UnityEngine;

public class Hidding_System : MonoBehaviour
{
    public GameObject player_Character;
    public GameObject UI_Interact;

    public SpriteRenderer FrontDoor;
    public SpriteRenderer FrontDoorClose;
    public SpriteRenderer BgWardor;
    public GameObject PosHidding;

    bool Trigger = false;
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            UI_Interact.SetActive(true);
            player_Character = col.gameObject;
            Trigger = true;
        }
    }
    void OnTriggerExit2D (Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            UI_Interact.SetActive(false);
            player_Character = null;
            Trigger = false;
        }
    }


    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player_Character != null)
            {
                if (Trigger == true && player_Character.GetComponent<Humanoid_Player>().Hidding == false)
                {
                    FrontDoor.enabled = false;
                    FrontDoorClose.enabled = true;

                    player_Character.GetComponent<Humanoid_Player>().Hidding = true;
                    player_Character.GetComponent<Movement>().enabled = false;
                    player_Character.transform.position = PosHidding.transform.position;
                }else if (player_Character.GetComponent<Humanoid_Player>().Hidding == true)
                {
                    FrontDoor.enabled = true;
                    FrontDoorClose.enabled = false;

                    player_Character.GetComponent<Humanoid_Player>().Hidding = false;
                    player_Character.GetComponent<Movement>().enabled = true;
                    player_Character.transform.position = PosHidding.transform.position;
                }
            }
        }
    }
}

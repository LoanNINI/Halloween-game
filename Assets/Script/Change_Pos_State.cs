using UnityEngine;

public class Change_Pos_State : MonoBehaviour
{
    public GameObject PosToGO;
    public GameObject Ui_Interact;
    public bool Change_State = false;

    GameObject playerCharacter;
    bool Trigger = false;
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            playerCharacter = col.gameObject;
            Ui_Interact.SetActive(true);
            Trigger = true;
        }
    }
    void OnTriggerExit2D (Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            Ui_Interact.SetActive(false);
            playerCharacter = null;
            Trigger = false;
        }
    }
    
    
    void Update ()
    {
        if (Trigger == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                playerCharacter.GetComponent<Humanoid_Player>().MainCamera.transform.position = PosToGO.transform.position;
                playerCharacter.transform.position = PosToGO.transform.position;
                if (Change_State == true)
                {
                    playerCharacter.GetComponent<Humanoid_Player>().MainCameraVirtual.enabled = !playerCharacter.GetComponent<Humanoid_Player>().MainCameraVirtual.enabled;
                    playerCharacter.GetComponent<Humanoid_Player>().State_Game = !playerCharacter.GetComponent<Humanoid_Player>().State_Game;
                }
            }
        }
    }
}

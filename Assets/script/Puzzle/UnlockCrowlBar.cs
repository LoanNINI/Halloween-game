using UnityEngine;

public class UnlockCrowlBar : MonoBehaviour
{
    public GameObject Ui_Interact;

    public string ItemWant = "CrowlBar";

    public GameObject GoalObj;

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
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Trigger == true)
            {
                if (ItemWant == "CrowlBar")
                {
                    if (playerCharacter.GetComponent<Inventory>().CrowlBar == true)
                    {
                        Ui_Interact.SetActive(false);
                        GoalObj.SetActive(true);
                        gameObject.SetActive(false);
                        SoundAudioManager.soundAudioManager.Play_Sound("Break",1);
                    }
                }
            }
        }
    }
}

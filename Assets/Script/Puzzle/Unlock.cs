using UnityEngine;

public class Unlock : MonoBehaviour
{
    public GameObject Ui_Interact;

    public string ItemWant = "key_1";

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
                if (ItemWant == "key_1")
                {
                    if (playerCharacter.GetComponent<Inventory>().key_1 == true)
                    {
                        SoundAudioManager.soundAudioManager.Play_Sound("LockPick", 1);
                        Ui_Interact.SetActive(false);
                        GoalObj.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
                if (ItemWant == "key_2")
                {
                    if (playerCharacter.GetComponent<Inventory>().key_2 == true)
                    {
                        SoundAudioManager.soundAudioManager.Play_Sound("LockPick", 1);
                        Ui_Interact.SetActive(false);
                        GoalObj.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
                if (ItemWant == "Basement_Key")
                {
                    if (playerCharacter.GetComponent<Inventory>().Basement_Key == true)
                    {
                        SoundAudioManager.soundAudioManager.Play_Sound("LockPick", 1);
                        Ui_Interact.SetActive(false);
                        GoalObj.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
                    SoundAudioManager.soundAudioManager.Play_Sound("KnockDoor", 2.5f);
                }
            }
        }
    }
}

using UnityEngine;

public class UnlockEnd : MonoBehaviour
{
    public GameObject Ui_Interact;

    public string GateKey_1 = "GateKey_1";
    public string GateKey_2 = "GateKey_2";

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
                if (GateKey_1 == "GateKey_1")
                {
                    if (playerCharacter.GetComponent<Inventory>().GateKey_1 == true && playerCharacter.GetComponent<Inventory>().GateKey_2 == true)
                    {
                        SoundAudioManager.soundAudioManager.Play_Sound("LockPick", 1);
                        Ui_Interact.SetActive(false);
                        GoalObj.SetActive(false);
                        gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}

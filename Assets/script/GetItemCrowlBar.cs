using UnityEngine;

public class GetItem_CrowlBar : MonoBehaviour
{
    public GameObject Ui_interact;
    public GameObject Visible;
    public GameObject UnVisible;
    public string Id_Item;

    GameObject playerCharacter;
    bool Trigger = false;
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            Ui_interact.SetActive(true);
            playerCharacter = col.gameObject;
            Trigger = true;
        }
    }
    void OnTriggerExit2D (Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            Ui_interact.SetActive(false);
            playerCharacter = null;
            Trigger = false;
        }
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Trigger == true)
        {
            if (Id_Item == "CrowlBar")
            {
                Visible.SetActive(false);
                UnVisible.SetActive(true);
                Trigger = false;
                playerCharacter.GetComponent<Inventory>().CrowlBar = true;
                gameObject.GetComponent<Collider2D>().enabled = false;
                gameObject.SetActive(false);
                SoundAudioManager.soundAudioManager.Play_Sound("GetItem",1);
            }
        }
    }
}

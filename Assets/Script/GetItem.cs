using Unity.Android.Gradle.Manifest;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    public GameObject Ui_interact;
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
            if (Id_Item == "Key_1")
            {
                Trigger = false;
                playerCharacter.GetComponent<Inventory>().key_1 = true;
                gameObject.GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}

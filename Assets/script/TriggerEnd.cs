using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEnd : MonoBehaviour
{
    public GameObject Ui_interact;
    bool Trigger = false;
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            Ui_interact.SetActive(true);
            Trigger = true;
        }
    }
    void OnTriggerExit2D (Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            Ui_interact.SetActive(false);
            Trigger = false;
        }
    }
    void Update()
    {
        if (Trigger == true)
        {
            SceneManager.LoadScene("Ending");
        }
    }
}

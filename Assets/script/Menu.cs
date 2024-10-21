using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject UISetting;

    public void Exittomenu ()
    {
        SceneManager.LoadScene("Manu Scene");
    }
    bool db = false;
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (UISetting.active == false)
            {
                db = true;
                UISetting.SetActive(true);
            }else if (UISetting.active == true)
            {
                db = false;
                UISetting.SetActive(false);
            }
        }
    }
}

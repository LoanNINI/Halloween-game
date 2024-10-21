using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystemFix : MonoBehaviour
{

    public void ChangeScene_toIntroduction ()
    {
        SceneManager.LoadScene("Introduction");
    }
    public void Exit ()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}

using UnityEngine;
using UnityEngine.SceneManagement;

public class ReSpawn : MonoBehaviour
{
    public void Restart ()
    {
        SceneManager.LoadScene("BossFight");
    }
    public void Back ()
    {
        SceneManager.LoadScene("Manu Scene");
    }
}

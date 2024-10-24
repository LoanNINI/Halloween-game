using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class Backto_manu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadScence()
    {
       
        SceneManager.LoadScene("Manu Scene");
    }

    
}

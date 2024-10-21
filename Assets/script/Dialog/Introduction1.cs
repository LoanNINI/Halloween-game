using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Introduction_2 : MonoBehaviour
{
    public TextMeshProUGUI TextMP;
    public string[] lines;
    public float speed = .01f;
    public int index;


    void Start ()
    {
        StartDialogue();
    }
    void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (TextMP.text == lines[index])
            {
                NextLines();
            }
            else
            {
                StopAllCoroutines();
                TextMP.text = lines[index];
            }
            
        }
    }
    void StartDialogue()
    {
        TextMP.text = string.Empty;
        index = 0;
        StartCoroutine(Typing());
    }

    IEnumerator Typing()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            TextMP.text += c;
            yield return new WaitForSeconds(speed);
        }
    }


    void NextLines ()
    {
        if (index < lines.Length - 1)
        {
            index++;
            TextMP.text = string.Empty;
            StartCoroutine(Typing());
        }else
        {
            SceneManager.LoadScene("Manu Scene");
        }
    }
}

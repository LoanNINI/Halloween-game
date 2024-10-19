using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class _3x3PuzzleCube : MonoBehaviour
{
    public Cube[] ArrCubePuzzle;
    [Space(15)]
    public GameObject Ui_Interact;
    public GameObject Ui_Puzzle;
    public GameObject Box;

    public void Change_Cube (string NumPos)
    {
        for (int i = 0; i < ArrCubePuzzle.Length; i++)
        {
            if (ArrCubePuzzle[i].Id_ == NumPos)
            {
                ArrCubePuzzle[i].state += 1;
                if (ArrCubePuzzle[i].state > 4)
                {
                    ArrCubePuzzle[i].state = 1;
                }
            }
        }
    }
    void Soled ()
    {
        int check = 0;
        for (int i = 0; i < ArrCubePuzzle.Length; i++)
        {
            if (ArrCubePuzzle[i].state == 1)
            {
                check += 1;
            }
        }
        Debug.Log(check);
        if (check == 9)
        {
            Box.SetActive(true);
            playerCharacter.gameObject.GetComponent<Movement>().enabled = true;
            gameObject.GetComponent<Collider2D>().enabled = false;
            Puzzling = false;
            Trigger = false;
            playerCharacter = null;
            Ui_Puzzle.SetActive(false);
            Ui_Interact.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    void Random_Puzzle ()
    {
        for (int i = 0; i < ArrCubePuzzle.Length; i++)
        {
            ArrCubePuzzle[i].state = Random.Range(1,5);
        }
    }

    void SetImage ()
    {
        for (int i = 0; i < ArrCubePuzzle.Length; i++)
        {
            if (ArrCubePuzzle[i].state == 1)
            {
                ArrCubePuzzle[i].UI.transform.rotation = Quaternion.Euler(0,0,0);
            }
            if (ArrCubePuzzle[i].state == 2)
            {
                ArrCubePuzzle[i].UI.transform.rotation = Quaternion.Euler(0,0,90);
            }
            if (ArrCubePuzzle[i].state == 3)
            {
                ArrCubePuzzle[i].UI.transform.rotation = Quaternion.Euler(0,0,180);
            }
            if (ArrCubePuzzle[i].state == 4)
            {
                ArrCubePuzzle[i].UI.transform.rotation = Quaternion.Euler(0,0,-90);
            }
        }
    }



    GameObject playerCharacter;
    bool Trigger = false;
    bool Puzzling = false;
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
    void Start ()
    {
        Random_Puzzle ();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Trigger == true && Puzzling == false)
            {
                playerCharacter.GetComponent<Movement>().enabled = false;
                Puzzling = true;
                Ui_Puzzle.SetActive(true);
            }else if (Puzzling == true)
            {
                Puzzling = false;
                Ui_Puzzle.SetActive(false); 
                playerCharacter.GetComponent<Movement>().enabled = true;
            }
        }
        if (Puzzling == true)
        {
            SetImage();
            Soled();
        }
    }
}


[System.Serializable]
public class Cube
{
    public string Id_ = "1/1";
    public GameObject UI;
    public int state = 1;
}

using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_System : MonoBehaviour
{
    public GameObject Dialog_Gui_Pefeb;
    public GameObject Dialog_PosDeploy;

    TextMeshProUGUI textComponent;
    public Dialog[] Dialog;
    public float textspeed;

    private int index;


    string old_name;
    bool Chooseing = false;
    trigger_Npc TNP;
    GameObject obj_Dialog;
    void Start ()
    {
        TNP = gameObject.GetComponent<trigger_Npc>();
    }
    void Update ()
    {
        if (TNP.Player_Char != null && Chooseing == false)
        {
            if (TNP.trigger == true && Input.GetKeyDown(KeyCode.E) && TNP.Player_Char.GetComponent<Humanoid_Player>().Chating == false)  //Start Chating by press E
            {
                TNP.Hidde_PopUp();
                TNP.Player_Char.GetComponent<Humanoid_Player>().Chating = true;
                TNP.Player_Char.GetComponent<Movement>().enabled = false;

                if (Dialog[index].name == "Player")
                {
                    StartDialogue_Player();
                    old_name = "Player";
                }
                else
                {
                    StartDialogue_Npc();
                }
            }

            if (Input.GetMouseButtonDown(0) && TNP.Player_Char.GetComponent<Humanoid_Player>().Chating == true)  //Start Chating by press E
            {
                if (Dialog.Length != index + 1)
                {
                    if (textComponent.text == Dialog[index].lines && old_name == Dialog[index + 1].name)
                    {
                        NextLine_Exit();
                    }
                    else if (textComponent.text == Dialog[index].lines && old_name != Dialog[index + 1].name)
                    {
                        if (Dialog[index + 1].name == "Player")
                        {
                            ContinueDialogue_Player();
                            old_name = "Player";
                        }
                        else
                        {
                            ContinueDialogue_Npc();
                            old_name = Dialog[index + 1].name;
                        }
                    }
                    else
                    {
                        StopAllCoroutines();
                        textComponent.text = Dialog[index].lines;
                    }
                }
                else if (textComponent.text == Dialog[index].lines && Dialog.Length == index + 1)
                {
                    NextLine_Exit();
                }
                else if (textComponent.text != Dialog[index].lines && Dialog.Length == index + 1)
                {
                    StopAllCoroutines();
                    textComponent.text = Dialog[index].lines;
                }
            }
        }
    }


    void StartDialogue_Npc ()
    {
        if (obj_Dialog != null)
        {
            Destroy(obj_Dialog);
        }

        obj_Dialog = Instantiate(Dialog_Gui_Pefeb, Dialog_PosDeploy.transform.position, Quaternion.identity);
        textComponent = obj_Dialog.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        textComponent.text = string.Empty;
        index = 0;
        StartCoroutine(Typeline());
    }
    void StartDialogue_Player ()
    {
        if (obj_Dialog != null)
        {
            Destroy(obj_Dialog);
        }

        obj_Dialog = Instantiate(Dialog_Gui_Pefeb, TNP.Player_Char.GetComponent<Humanoid_Player>().Dialog_PosDeploy.transform.position, Quaternion.identity);
        textComponent = obj_Dialog.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        textComponent.text = string.Empty;
        index = 0;
        StartCoroutine(Typeline());
    }

    void ContinueDialogue_Npc ()
    {
        if (obj_Dialog != null)
        {
            Destroy(obj_Dialog);
        }

        obj_Dialog = Instantiate(Dialog_Gui_Pefeb, Dialog_PosDeploy.transform.position, Quaternion.identity);
        textComponent = obj_Dialog.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        textComponent.text = string.Empty;
        index++;
        StartCoroutine(Typeline());
    }

    void ContinueDialogue_Player ()
    {
        if (obj_Dialog != null)
        {
            Destroy(obj_Dialog);
        }

        obj_Dialog = Instantiate(Dialog_Gui_Pefeb, TNP.Player_Char.GetComponent<Humanoid_Player>().Dialog_PosDeploy.transform.position, Quaternion.identity);
        textComponent = obj_Dialog.transform.GetChild(0).transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        textComponent.text = string.Empty;
        index++;
        StartCoroutine(Typeline());
    }

    IEnumerator Typeline()
    {   
        if (Dialog[index].Choose == true)
        {
            Chooseing = true;
            foreach (char c in Dialog[index].lines.ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textspeed);
            }
        }
        else
        {
            foreach (char c in Dialog[index].lines.ToCharArray())
            {
                textComponent.text += c;
                yield return new WaitForSeconds(textspeed);
            }
        }
    }

    void NextLine_Exit ()
    {
        if (index < Dialog.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(Typeline());
        }
        else
        {   
            index = 0;
            old_name = string.Empty;
            TNP.Player_Char.GetComponent<Humanoid_Player>().Chating = false;
            TNP.Player_Char.GetComponent<Movement>().enabled = true;
            Destroy(obj_Dialog);
        }
    }
}

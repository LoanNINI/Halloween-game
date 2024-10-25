using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_Event_Friend : MonoBehaviour
{
    public GameObject Dialog_Gui_Pefeb;
    public GameObject Dialog_PosDeploy;

    public GameObject AreaUnlock;
    public GameObject AreaUnlockTrickortreat;
    public GameObject NPCunlock;
    public string newObjective = "เก็บ ลูกอมให้ครบ10อัน";

    public GameObject PumpkinFriendPrefab;  // Add a reference for the Pumpkin Friend prefab

    TextMeshProUGUI textComponent;
    public Dialog[] Dialog_Start;
    public float textspeed;

    private int index;

    Dialog[] Dialog;

    Button Option1_Buttom;
    Button Option2_Buttom;
    TextMeshProUGUI Option1_Text;
    TextMeshProUGUI Option2_Text;

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
            if (TNP.trigger == true && Input.GetKeyDown(KeyCode.E) && TNP.Player_Char.GetComponent<Humanoid_Player>().Chating == false)
            {
                Dialog = Dialog_Start;
                TNP.Hidde_PopUp();
                TNP.Player_Char.GetComponent<Humanoid_Player>().Chating = true;
                TNP.Player_Char.GetComponent<Movement>().enabled = false;
                ObjSever.objsever.QuestMain.SetActive(false);

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

            if (Input.GetMouseButtonDown(0) && TNP.Player_Char.GetComponent<Humanoid_Player>().Chating == true)
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
                            old_name = Dialog[index].name;
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

        if (obj_Dialog != null)
        {
            if (Chooseing == true)
            {
                obj_Dialog.transform.GetChild(1).gameObject.SetActive(true);

                Option1_Buttom = obj_Dialog.transform.GetChild(1).transform.GetChild(0).GetComponent<Button>();
                Option2_Buttom = obj_Dialog.transform.GetChild(1).transform.GetChild(1).GetComponent<Button>();
                Option1_Text = obj_Dialog.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
                Option2_Text = obj_Dialog.transform.GetChild(1).transform.GetChild(1).transform.GetChild(0).GetComponent<TextMeshProUGUI>();

                Option1_Text.text = Dialog[index].choose_Option.Option1;
                Option1_Buttom.onClick.AddListener(OnCLik_Option1);

                Option2_Text.text = Dialog[index].choose_Option.Option2;
                Option2_Buttom.onClick.AddListener(OnCLik_Option2);

            }
            else
            {
                Option1_Buttom = null;
                Option2_Buttom = null;
                Option1_Text = null;
                Option2_Text = null;
                obj_Dialog.transform.GetChild(1).gameObject.SetActive(false);
            }
        }

    }

    bool db_Click = false;
    void OnCLik_Option1 ()
    {
        if (db_Click == false)
        {
            Chooseing = false;
            StartCoroutine(OnClick_B1());
        }
    }
    void OnCLik_Option2 ()
    {
        if (db_Click == false)
        {
            Chooseing = false;
            StartCoroutine(OnClick_B2());
        }
    }
    IEnumerator OnClick_B1()
    {
        Debug.Log("Click! B1");
        db_Click = true;
        Dialog = Dialog[index].choose_Option.lines1;
        StartDialogue_Npc();
        yield return new WaitForSeconds(.05f);
        db_Click = false;
        Debug.Log("Click! B1 End");
    }
    IEnumerator OnClick_B2()
    {
        Debug.Log("Click! B2");
        db_Click = true;
        Dialog = Dialog[index].choose_Option.lines2;
        StartDialogue_Npc();
        yield return new WaitForSeconds(.05f);
        db_Click = false;
        Debug.Log("Click! B2 End");
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
                SoundAudioManager.soundAudioManager.Play_Sound("SoundText", 1);
                yield return new WaitForSeconds(textspeed);
            }
        }
        else
        {
            foreach (char c in Dialog[index].lines.ToCharArray())
            {
                textComponent.text += c;
                SoundAudioManager.soundAudioManager.Play_Sound("SoundText", 1);
                yield return new WaitForSeconds(textspeed);
            }
        }
    }

    void NextLine_Exit()
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
        TNP.Player_Char.GetComponent<Humanoid_Player>().FriendFollower = true;
        Destroy(obj_Dialog);

        AreaUnlock.SetActive(false);
        NPCunlock.SetActive(true);
        AreaUnlockTrickortreat.SetActive(true);
        Objective_System.objective_System.textObjective = newObjective;
        gameObject.transform.parent.gameObject.SetActive(false);
        ObjSever.objsever.QuestMain.SetActive(true);

        // Spawning the Pumpkin Friend at the Player's position
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Instantiate(PumpkinFriendPrefab, player.transform.position, Quaternion.identity);
        }

    }
}


}

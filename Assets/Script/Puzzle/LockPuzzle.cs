using System.Collections;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class LockPuzzle : MonoBehaviour
{
    public GameObject Ui_Interact;
    public GameObject Ui_Puzzle;
    public RectTransform PosL1;
    public RectTransform PosL2;
    public RectTransform PosL3;
    public RectTransform PosLockPick;
    [Space(15)]
    public bool Lock1;
    public int Lock1_Fix_Max;
    public int Lock1_Fix_Min;
    public bool Lock2;
    public int Lock2_Fix_Max;
    public int Lock2_Fix_Min;
    public bool Lock3;
    public int Lock3_Fix_Max;
    public int Lock3_Fix_Min;
    [Space(15)]
    public int LockPick_in = 1;
    public int LockPick_force = 0;

    GameObject playerCharacter;
    bool Trigger = false;
    bool LockPicking  = false;
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
        Lock1_Fix_Max = Random.Range(20,100);
        Lock2_Fix_Max = Random.Range(20,100);
        Lock3_Fix_Max = Random.Range(20,100);

        Lock1_Fix_Min = Lock1_Fix_Max - 20;
        Lock2_Fix_Min = Lock2_Fix_Max - 20;
        Lock3_Fix_Min = Lock3_Fix_Max - 20;
    }
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Trigger == true && LockPicking == false)
            {
                playerCharacter.GetComponent<Movement>().enabled = false;
                Ui_Puzzle.SetActive(true);
                LockPicking = true;
            }else if (LockPicking == true)
            {
                playerCharacter.GetComponent<Movement>().enabled = true;
                Ui_Puzzle.SetActive(false);
                LockPicking = false;
            }
        }

        if (LockPicking == true)
        {
            ChargeForce ();
            Change_Lockpick_In();


            Ui_Puzzle.GetComponent<Slider>().value = LockPick_force;

            if (LockPick_in == 1)
            {
                PosLockPick.position = PosL1.position;
            }
            if (LockPick_in == 2)
            {
                PosLockPick.position = PosL2.position;
            }
            if (LockPick_in == 3)
            {
                PosLockPick.position = PosL3.position;
            }
        }
    }

    void Change_Lockpick_In ()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            LockPick_in += 1;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            LockPick_in -= 1;
        }

        if (LockPick_in > 3)
        {
            LockPick_in = 3;
        }else if (LockPick_in < 1)
        {
            LockPick_in = 1;
        }
    }


    bool Maxed = false;
    bool Dbcreased = false;
    bool pressed = false;
    void ChargeForce ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            pressed = true;
        }else if (Input.GetMouseButtonUp(0))
        {
            pressed = false;
            LockPick_force = 0;
        }

        if (pressed == true)
        {
            if (Maxed == false && LockPick_force < 100)
            {
                if (Dbcreased == false)
                {
                    StartCoroutine(increased());
                }
            }else if (Maxed == false && LockPick_force >= 100)
            {
                Maxed = true;
            }

            if (Maxed == true && LockPick_force > 0)
            {
                if (Dbcreased == false)
                {
                    StartCoroutine(Decreased());
                }
            }else if (Maxed == true && LockPick_force <= 0)
            {
                Maxed = false;
            }
        }
    }
    IEnumerator increased ()
    {   
        Dbcreased = true;
        LockPick_force += 1;
        yield return new WaitForSeconds(.001f);
        Dbcreased = false;
    }
    IEnumerator Decreased ()
    {   
        Dbcreased = true;
        LockPick_force -= 1;
        yield return new WaitForSeconds(.001f);
        Dbcreased = false;
    }
}

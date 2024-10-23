using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int Candy = 0;
    public bool key_1 = false;
    public bool key_2 = false;
    public bool GateKey_1 = false;
    public bool GateKey_2 = false;
    public bool Basement_Key = false;
    public bool CrowlBar = false;

    public GameObject CastleBarrier;

    public TextMeshProUGUI UI_Candy;

    bool onewtime = false;
    void Update ()
    {
        if (UI_Candy != null)
        {
            UI_Candy.text = Candy.ToString();

            if (Candy >= 10 && onewtime == false)
            {
                onewtime = true;
                Objective_System.objective_System.textObjective = "ดูเหมือนจะได้เวลาละ ไปที่คฤหาสน์ดูดีกว่า";
                SoundAudioManager.soundAudioManager.Play_Sound("Start",10);
                CastleBarrier.SetActive(false);
            }
        }
    }
}

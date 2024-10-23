using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public float Health_HP = 100f;
    public Slider HealthSlider;

    public GameObject restartUI;
    void Update()
    {
        if (Health_HP <= 0)
        {
            restartUI.SetActive(true);
            SoundAudioManager.soundAudioManager.Play_Sound("Scream", 2);
        }
        HealthSlider.value =  Health_HP;
    }
}

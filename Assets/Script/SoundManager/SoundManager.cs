using UnityEngine;
using UnityEngine.Audio;

public class SoundAudioManager : MonoBehaviour
{
    public Sound_ID[] Sound_Manager;
    public GameObject PefebSound;
    public static SoundAudioManager soundAudioManager;

    public void Start()
    {
        if (soundAudioManager == null)
        {
            soundAudioManager = gameObject.GetComponent<SoundAudioManager>();
        }
    }
    public void Play_Sound (string name_Sound, float time)
    {
        int Max = Sound_Manager.Length;
        for (int i = 0; i < Max; i++)
        {
            Debug.Log(i);
            if (Sound_Manager[i].Sound_Id.name == name_Sound)
            {
                GameObject obj = Instantiate(PefebSound, transform.position, Quaternion.identity);
                obj.GetComponent<AudioSource>().resource = Sound_Manager[i].Sound_Id;
                obj.GetComponent<AudioSource>().Play();
                Destroy(obj,time);
            }
        }
    }
}


[System.Serializable]
public class Sound_ID
{
    public AudioClip Sound_Id;
    public AudioMixerGroup Mixer;
}

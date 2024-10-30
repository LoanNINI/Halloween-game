using Cinemachine;
using UnityEngine;

public class Humanoid_Player : MonoBehaviour
{
    public GameObject Dialog_PosDeploy;
    public GameObject Character;
    public GameObject FriendPumkin;   // Reference to the pumpkin GameObject
    public Camera MainCamera;
    public CinemachineConfiner2D MainCameraVirtual;
    [Space(15)]
    public bool State_Game = false;
    public bool FriendFollower = false;
    [Space(15)]
    public bool Chating = false;
    public bool Hidding = false;

    void Start()
    {
        if (MainCamera == null)
        {
            MainCamera = Camera.main;
        }

        // Assign the player reference to the FriendPumkin script
        if (FriendPumkin != null)
        {
            FriendPumkin.GetComponent<FriendPumkin>().player = this.gameObject;
        }
    }

    void Update()
    {
        /*if (FriendFollower)
        {
            FriendPumkin.SetActive(true);
        }
        else
        {
            FriendPumkin.SetActive(false);
        }*/
    }
}

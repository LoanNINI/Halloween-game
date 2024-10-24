using Cinemachine;
using UnityEngine;

public class Humanoid_Player : MonoBehaviour
{
    public GameObject Dialog_PosDeploy;
    public GameObject Character;
    public GameObject FriendPumkin;
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
        MainCamera = Camera.main;
    }

    void Update()
    {
        if (FriendFollower == true)
        {
            FriendPumkin.SetActive(true);
        }else
        {
            FriendPumkin.SetActive(false);
        }
    }
}

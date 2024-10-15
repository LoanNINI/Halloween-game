using Cinemachine;
using UnityEngine;

public class Humanoid_Player : MonoBehaviour
{
    public GameObject Dialog_PosDeploy;
    public GameObject Character;
    public Camera MainCamera;
    public CinemachineConfiner2D MainCameraVirtual;
    [Space(15)]
    public bool State_Game = false;
    [Space(15)]
    public bool Chating = false;


    void Start()
    {
        if (MainCamera == null)
        MainCamera = Camera.main;
    }
}

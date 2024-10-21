using TMPro;
using UnityEngine;

public class Objective_System : MonoBehaviour
{
    public string textObjective = " - ไปร่วมงานที่ คฤหาสน์";
    public TextMeshProUGUI TextMP;
    public static Objective_System objective_System;
    

    void Start()
    {
        objective_System = gameObject.GetComponent<Objective_System>();
    }
    void Update()
    {
        TextMP.text = textObjective;
    }
}

using System;
using UnityEngine;



[System.Serializable]
public class Dialog
{
    public string name;
    public string lines;
    public bool Choose = false;
    [Space(15)]
    public Choose_Option choose_Option;
}




[System.Serializable]
public class Choose_Option
{
    public string Option1;
    public Dialog[] lines1;
    [Space(15)]
    public string Option2;
    public Dialog[] lines2;
}


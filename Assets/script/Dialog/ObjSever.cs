using UnityEngine;

public class ObjSever : MonoBehaviour
{
    public GameObject QuestMain;
    public GameObject NewItem;
    public GameObject Restart;
    public static ObjSever objsever;

    void Start()
    {
        if (objsever == null)
        {
            objsever = gameObject.GetComponent<ObjSever>();
        }
    }
}

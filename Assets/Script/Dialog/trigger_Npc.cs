using UnityEngine;

public class trigger_Npc : MonoBehaviour
{
    public GameObject Gui_interact;
    public GameObject Player_Char;
    public bool trigger = false;
    void OnTriggerEnter2D (Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            Player_Char = col.gameObject;
            trigger = true;
            Pop_up();
        }
    }
    void OnTriggerExit2D (Collider2D col)
    {
        if (col.transform.tag == "Player")
        {
            Player_Char = null;
            trigger = false;
            Hidde_PopUp();
        }
    }

    public void Pop_up()
    {
        Gui_interact.SetActive(true);
    }
    public void Hidde_PopUp()
    {
        Gui_interact.SetActive(false);
    }
}

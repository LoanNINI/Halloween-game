using System.Collections;
using System.Linq;
using UnityEngine;

public class Monster_WayPoint : MonoBehaviour
{
    public Room[] Room_WayPoint;
    public float DelayTime_think = 1;
    public int Room_Id_Living = 1;
    public float Speed = 1f;

    Rigidbody2D RB;
    int ran_ = 0;
    bool Randoming = false;
    bool Walking = false;
    bool Db_CoolDown;
    void Start ()
    {
        RB = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update ()
    {
        if (Randoming == false && Walking == false)
        {
            Randoming = true;   
            ran_ = Random.Range(0,Room_WayPoint[Room_Id_Living].waypoint_inroom.Length);
            //Debug.Log(ran_);
        }
        else if (Walking == false && Randoming == true)
        {
            Randoming = false;
            Walking = true;
        }
        else if (Walking == true && transform.position != new Vector3(Room_WayPoint[Room_Id_Living].waypoint_inroom[ran_].Point.transform.position.x, Room_WayPoint[Room_Id_Living].waypoint_inroom[ran_].Point.transform.position.y, transform.position.z))
        {
            Walk();
        }



        if (transform.position == new Vector3(Room_WayPoint[Room_Id_Living].waypoint_inroom[ran_].Point.transform.position.x, Room_WayPoint[Room_Id_Living].waypoint_inroom[ran_].Point.transform.position.y, transform.position.z))
        {
            Randoming = false;
            Walking = false;
        }
    }

    void Walk()
    {
        transform.position = Vector3.MoveTowards(transform.position, Room_WayPoint[Room_Id_Living].waypoint_inroom[ran_].Point.transform.position, Speed * Time.deltaTime);
        //Debug.Log("Walk_Looping");
    }

}


[System.Serializable]
public class Room 
{
    public string name;
    public GameObject Room_Obj;
    public int Room_ID;
    [Space (10)]
    public Waypoint[] waypoint_inroom;

}

[System.Serializable]
public class Waypoint
{
    public GameObject Point;
    public bool warp = false;
}


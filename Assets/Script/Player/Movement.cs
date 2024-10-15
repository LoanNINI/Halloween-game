using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb; 
    public float Speed = 5;

    Vector2 direction_move;
    bool Facing = false;

    [Space(15)]
    [SerializeField] private Transform rayCastOrigin;
    [SerializeField] private Transform Character;
    [SerializeField] private LayerMask layerMask;
    private RaycastHit2D Hit2D;
    void Update ()
    {
        direction_move.x = Input.GetAxisRaw("Horizontal");
        if (gameObject.GetComponent<Humanoid_Player>().State_Game == true)
        {
            direction_move.y = -1;
            GroundCheckMethod();
        }
        else
        {
            direction_move.y = Input.GetAxisRaw("Vertical");
        }

        Debug.Log(direction_move.x);
        if (direction_move.x > 0 && !Facing)
        {   
            flip_faceing();
        }
        else if (direction_move.x < 0 && Facing)
        {
            flip_faceing();
        }

    }

    void flip_faceing ()
    {
        Facing = !Facing;
        gameObject.GetComponent<Humanoid_Player>().Character.transform.Rotate(0,180,0);
    }

    void FixedUpdate ()
    {
        Vector2 Movement = direction_move.normalized;
        rb.MovePosition(rb.position + Movement * Speed * Time.deltaTime);
    }






    private void GroundCheckMethod()
    {
        Hit2D = Physics2D.Raycast(rayCastOrigin.position, Vector2.up, -.1f,layerMask);

        if (Hit2D != false)
        {
            direction_move.y = 0;
        }
    }

}

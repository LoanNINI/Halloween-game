using UnityEngine;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb; 
    public float Speed = 5;

    Vector2 direction_move;
    void Update ()
    {
        direction_move.x = Input.GetAxisRaw("Horizontal");
        direction_move.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate ()
    {
        Vector2 Movement = direction_move.normalized;
        rb.MovePosition(rb.position + Movement * Speed * Time.deltaTime);
    }

}

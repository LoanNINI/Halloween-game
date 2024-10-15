using UnityEngine;

public class BoxPyshic : MonoBehaviour
{
    Rigidbody2D rb;
    public float Friction = .1f;

    void Start ()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    void Update ()
    {
        Debug.Log(rb.velocity.magnitude);
        if (rb.velocity.magnitude > 0.01)
        {
            if (rb.velocity.x != 0)
            {   
                if (rb.velocity.x > 0)
                {
                    if (rb.velocity.x - Friction < 0)
                    {
                        rb.velocity = new Vector2(0,rb.velocity.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(rb.velocity.x - Friction,rb.velocity.y);
                    }
                }
                if (rb.velocity.x < 0)
                {
                    if (rb.velocity.x + Friction > 0)
                    {
                        rb.velocity = new Vector2(0,rb.velocity.y);
                    }
                    else
                    {
                        rb.velocity = new Vector2(rb.velocity.x + Friction,rb.velocity.y);
                    }
                }
            }
            if (rb.velocity.y != 0)
            {   
                if (rb.velocity.y > 0)
                {
                    if (rb.velocity.y - Friction < 0)
                    {
                        rb.velocity = new Vector2(rb.velocity.x,0);
                    }
                    else
                    {
                        rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y - Friction);
                    }
                }
                if (rb.velocity.y < 0)
                {
                    if (rb.velocity.y + Friction > 0)
                    {
                        rb.velocity = new Vector2(rb.velocity.x,0);
                    }
                    else
                    {
                        rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y + Friction);
                    }
                }
            }
        }
    }
}

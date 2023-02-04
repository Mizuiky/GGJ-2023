using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D Rb;
    public float Speed = 20f;
    public float JumpForce = 2000f;
    public bool Grounded;
    public LayerMask GroundLayers; 

    public void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        VerifyGrounded();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    void Move()
    {
        var getAxys = Input.GetAxisRaw("Horizontal");
        if (getAxys > 0)
            Rb.velocity = new Vector2(Speed, 0);
        else if (getAxys < 0)
            Rb.velocity = new Vector2(-Speed, 0);
        else
            Rb.velocity = Vector2.zero;
    }

    void Jump()
    {
        if (Input.GetButton("Jump") && Grounded)
        {
            Rb.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
        }
    }

    void VerifyGrounded()
    {
        Grounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f),
           new Vector2(transform.position.x + 0.5f, transform.position.y - 51f), GroundLayers).IsTouchingLayers();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 0.505f), new Vector2(1f, 0.01f));
    }
}

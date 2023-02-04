using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D Rb;
    public float Speed = 15f;
    public float JumpForce = 2f;
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
            Rb.velocity = new Vector2(Speed, Rb.velocity.y - 1 );
        else if (getAxys < 0)
            Rb.velocity = new Vector2(-Speed, Rb.velocity.y - 1);
        else
            Rb.velocity = new Vector2(0, Rb.velocity.y);
    }

    void Jump()
    {
        if (IsPressJumpButtons() && Grounded)
        {
            Rb.AddForce(JumpForce * Vector2.up, ForceMode2D.Impulse);
        }
    }

    private bool IsPressJumpButtons()
        => (Input.GetButton("Jump") || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Joystick1Button0));

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

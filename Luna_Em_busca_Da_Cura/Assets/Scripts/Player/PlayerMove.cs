using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D Rb;
    public float Speed = 17f;
    public float JumpForce = 170f;
    public bool Grounded;
    public LayerMask GroundLayers;
    public Animator Animator;

    public void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        Jump();
        VerifyGrounded();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        var getAxys = Input.GetAxisRaw("Horizontal");
        if (getAxys > 0)
        {
            transform.localEulerAngles = new Vector2(0, 0);
            Rb.velocity = new Vector2(Speed, Rb.velocity.y - 1 );
            Animator.SetFloat("Speed", Rb.velocity.x);
            PlayRun();
        }
        else if (getAxys < 0)
        {
            transform.localEulerAngles = new Vector2(0, 180);
            Rb.velocity = new Vector2(-Speed, Rb.velocity.y - 1);
            Animator.SetFloat("Speed", Rb.velocity.x * -1);
            PlayRun();
        }
        else
        {
            Rb.velocity = new Vector2(0, Rb.velocity.y);
            Animator.SetFloat("Speed", 0f);
            StopPlayRunSound();
        }
    }

    public void PlayRun()
    {
        if (Grounded)
            AudioManager.Instance.PlayAudio("PlayerRun");
    }

    public void PlayJumpSound()
    {
        StopPlayRunSound();
        AudioManager.Instance.PlayAudio("PlayerJump");
    }

    public void StopPlayRunSound()
    {
        AudioManager.Instance.StopAudio("PlayerRun");
    }

    void Jump()
    {
        if (IsPressJumpButtons() && Grounded)
        {
            Rb.AddForce(JumpForce * Vector2.up, ForceMode2D.Impulse);
            PlayJumpSound();
        }
    }

    private bool IsPressJumpButtons()
        => (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Joystick1Button0));

    public void OnLanding()
    {
        Animator.SetBool("Grounded", false);
    }

    void VerifyGrounded()
    {
        Grounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f),
           new Vector2(transform.position.x + 0.5f, transform.position.y - 51f), GroundLayers).IsTouchingLayers();
        Animator.SetBool("Grounded", Grounded);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(new Vector2(transform.position.x, transform.position.y - 0.505f), new Vector2(1f, 0.01f));
    }
}

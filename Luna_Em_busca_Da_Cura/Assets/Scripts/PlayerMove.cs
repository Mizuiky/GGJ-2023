using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 20f;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var getAxys = Input.GetAxis("Horizontal");
        if (getAxys > 0)
            rb.velocity = new Vector2(speed, 0);
        else if (getAxys < 0)
            rb.velocity = new Vector2(-speed, 0);
        else
            rb.velocity = Vector2.zero;
    }
}

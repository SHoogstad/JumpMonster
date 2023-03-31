using JetBrains.Annotations;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static int Level = 1;
    private float horizontal;
    private const float jumpingPower = 20f;
    private bool isFacingRight = true;

    [SerializeField] private float speed = 10;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform GroundCheck;
    [SerializeField] private LayerMask GroundLayer;
    [SerializeField] [CanBeNull] private Animator chest;

    private void Start()
    {
        if (chest == null) return;

        chest.enabled = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump") && OnGround())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            var velocity = rb.velocity;
            velocity = new Vector2(velocity.x, velocity.y * 0.5f);
            rb.velocity = velocity;
        }

        flip();
    }

    private void FixedUpdate()
    { 
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    private bool OnGround()
    {
        return Physics2D.OverlapCircle(GroundCheck.position, 0.5f, GroundLayer);
    }

    private void flip()
    {
        if ((!isFacingRight || !(horizontal < 0f)) && (isFacingRight || !(horizontal > 0f))) return;
        
        isFacingRight = !isFacingRight;
        
        var transform1 = transform;
        var localScale = transform1.localScale;
        
        localScale.x *= -1f;
        transform1.localScale = localScale;
    }
}
using UnityEngine;

public class Trampoline : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D col)
    {
        rb.velocity = new Vector2(rb.velocity.x, CalculateVelocityY());
    }

    private float CalculateVelocityY()
    {
        return rb.velocity.y * -1 * 2 > 30 
            ? 25 
            : rb.velocity.y * -1 * 2;
    }
}

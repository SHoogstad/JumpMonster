using UnityEngine;

public class ObjectMoveHorizontal : MonoBehaviour
{
    [SerializeField] private Rigidbody2D Rigidbody2D;
    [SerializeField] private LayerMask wallLayerRight;
    [SerializeField] private LayerMask wallLayerLeft;
    [SerializeField] private Transform wallCheck;


    private void Start()
    {
        Rigidbody2D.velocity = new Vector2(3, Rigidbody2D.velocity.y);
    }

    // Update is called once per frame
    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (!OnWallRight() && OnWallLeft())
        {
            Rigidbody2D.velocity = new Vector2(3f, Rigidbody2D.velocity.y);
            return;
        }

        if (OnWallRight() && !OnWallLeft())
        {
            Rigidbody2D.velocity = new Vector2(-3f, Rigidbody2D.velocity.y);
        }
    }

    private bool OnWallLeft()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 1f, wallLayerLeft);
    }

    private bool OnWallRight()
    {
        return Physics2D.OverlapCircle(wallCheck.position, 1f, wallLayerRight);
    }
}
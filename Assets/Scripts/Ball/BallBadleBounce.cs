using UnityEngine;

public class BallBadleBounce : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayers;

    private Ball ball;
    private Rigidbody2D rb;

    private void Awake()
    {
        ball = GetComponent<Ball>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        if (IsPlayerLayer(collision))
        {
            var paddle = collision.transform;
            Vector2 contactPoint = collision.GetContact(0).point;

            float offset = contactPoint.y - paddle.position.y;
            float halfHeight = paddle.GetComponent<Collider2D>().bounds.size.y / 2f;
            float normalizedOffset = offset / halfHeight;

            float horizontalDir = Mathf.Sign(transform.position.x - paddle.position.x);

            Vector2 newDir = new Vector2(horizontalDir, normalizedOffset).normalized;

            Vector2 oldDir = rb.linearVelocity.normalized;
            Vector2 blendedDir = (oldDir + newDir).normalized;

            rb.linearVelocity = blendedDir * ball.getSpeed;
        }
    }

    private bool IsPlayerLayer(Collision2D collision)
    {
        return ((1 << collision.gameObject.layer) & playerLayers) != 0;
    }
}

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2f;

    protected Rigidbody2D rb;

    private float moveY;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveY = GetPlayerMovement();
    }

    void FixedUpdate()
    {
        if (GameState.Instance && GameState.Instance.gameOver)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        HandleMovementY();
    }

    protected virtual float GetPlayerMovement()
    {
        return Input.GetAxisRaw("Vertical") * CalculateSpeed();
    }

    protected float CalculateSpeed()
    {
        return speed;
    }

    private void HandleMovementY()
    {
        rb.linearVelocity = new Vector2(rb.linearVelocityX, moveY);
    }
}

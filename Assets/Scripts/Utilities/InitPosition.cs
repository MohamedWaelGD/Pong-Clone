using UnityEngine;

public class InitPosition : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 initPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        initPosition = transform.position;
    }

    public void ResetPosition()
    {
        transform.position = initPosition;
        if (rb)
            rb.linearVelocity = Vector2.zero;
    }
}

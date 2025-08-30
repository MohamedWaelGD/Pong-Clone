using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private float speed = 13f;
    public float getSpeed { get => speed; }

    [Header("Difficulty Increase Settings")]
    [SerializeField] private float timerToIncreaseSpeed = 10f;
    [SerializeField] private float speedIncreaseAmount = 2f;
    [SerializeField] private float maxSpeed = 20f;

    private Rigidbody2D rb;
    private float increaseSpeedTimer = 0f;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        LaunchBall();
    }

    private void Update()
    {
        if (increaseSpeedTimer < 0)
        {
            speed = Math.Min(speed + speedIncreaseAmount, maxSpeed);
            increaseSpeedTimer = timerToIncreaseSpeed;
        }
        else
        {
            increaseSpeedTimer -= Time.deltaTime;
        }
    }

    private void LaunchBall()
    {
        // Pick random direction
        float x = UnityEngine.Random.value < 0.5f ? -1 : 1;
        float y = 0;

        Vector2 dir = new Vector2(x, y).normalized;
        rb.linearVelocity = dir * speed;
    }

    void FixedUpdate()
    {
        SetConstantSpeed();
    }

    private void SetConstantSpeed()
    {
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }
}

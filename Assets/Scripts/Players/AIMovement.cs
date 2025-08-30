using UnityEngine;

public class AIMovement : PlayerMovement
{
    public GameObject ball { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        ball = FindFirstObjectByType<Ball>().gameObject;
    }

    public void setBallTarget(GameObject ball)
    {
        this.ball = ball;
    }

    protected override float GetPlayerMovement()
    {
        if (ball != null)
        {
            if (ball.transform.position.y > transform.position.y + 0.5f)
            {
                return CalculateSpeed();
            }
            else if (ball.transform.position.y < transform.position.y - 0.5f)
            {
                return -CalculateSpeed();
            }
        }
        return 0;
    }
}

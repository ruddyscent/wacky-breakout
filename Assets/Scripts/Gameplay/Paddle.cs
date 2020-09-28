using UnityEngine;

public class Paddle : MonoBehaviour
{
    const float BounceAngleHalfRange = 60 * Mathf.PI / 180;

    Rigidbody2D rb2D = null;
    float halfColliderWidth = 0;
    Timer freezeTimer = null;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        halfColliderWidth = GetComponent<BoxCollider2D>().size.x / 2;
        freezeTimer = gameObject.AddComponent<Timer>();
        EventManager.AddFreezerEffectListener(Freeze);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Freeze(float duration) {
        freezeTimer.Duration = duration;
        freezeTimer.Run();
    }

    void FixedUpdate()
    {
        if (freezeTimer.Running) {}
        else {
            float input = Input.GetAxis("Control");
            Vector2 direction = new Vector2(input, 0);
            float speed = ConfigurationUtils.PaddleMoveUnitsPerSecond;
            Vector2 velocity = speed * direction;
            Vector2 new_position = rb2D.position + velocity * Time.fixedDeltaTime;
            new_position.x = CalculateClampedX(new_position.x);
            rb2D.MovePosition(new_position);
        }
    }

    float CalculateClampedX(float x)
    {
        if (x > ScreenUtils.ScreenRight - 2.2f * halfColliderWidth)
        {
            x = ScreenUtils.ScreenRight - 2.2f * halfColliderWidth;
        }
        else if (x < ScreenUtils.ScreenLeft + 2.2f * halfColliderWidth)
        {
            x = ScreenUtils.ScreenLeft + 2.2f * halfColliderWidth;
        }

        return x;
    }

    /// <summary>
    /// Detects collision with a ball to aim the ball
    /// </summary>
    /// <param name="coll">collision info</param>
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            // calculate new ball direction
            float ballOffsetFromPaddleCenter = transform.position.x -
                coll.transform.position.x;
            float normalizedBallOffset = ballOffsetFromPaddleCenter /
                halfColliderWidth;
            float angleOffset = normalizedBallOffset * BounceAngleHalfRange;
            float angle = Mathf.PI / 2 + angleOffset;
            Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            // tell ball to set direction to new direction
            Ball ballScript = coll.gameObject.GetComponent<Ball>();
            ballScript.SetDirection(direction);
        }
    }
}

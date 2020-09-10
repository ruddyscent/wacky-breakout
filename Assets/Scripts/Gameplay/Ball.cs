using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Fields
    Rigidbody2D rb2D = null;
    BoxCollider2D bc2D = null;
    Timer pauseTimer = null;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //float magnitude = ConfigurationUtils.BallImpulseForce;
        //Vector2 direction = new Vector2(Mathf.Cos(20 * Mathf.PI / 180), Mathf.Sin(20 * Mathf.PI / 180));
        rb2D = GetComponent<Rigidbody2D>();
        bc2D = GetComponent<BoxCollider2D>();
        //rb2D.velocity = magnitude * direction;

        pauseTimer = gameObject.AddComponent<Timer>();
        pauseTimer.Duration = ConfigurationUtils.BallPauseTime;
        pauseTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseTimer != null && pauseTimer.Finished)
        {
            Vector2 direction = new Vector2(0, -1);
            rb2D.velocity = direction;
            rb2D.AddForce(ConfigurationUtils.BallImpulseForce * direction, ForceMode2D.Impulse);
            Destroy(pauseTimer);
            pauseTimer = null;
        }

        if (OnBecameInvisible())
        {
            Camera m_MainCamera = Camera.main;
            m_MainCamera.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
        }
    }

    public void SetDirection(Vector2 direction)
    {
        float speed = rb2D.velocity.magnitude;
        rb2D.velocity = speed * direction;
    }

    bool OnBecameInvisible()
    {
        Vector2 position = gameObject.transform.position;
        float radius = bc2D.size.y / 2f;
        if (position.y < ScreenUtils.ScreenBottom - radius)
            return true;
        else
            return false;
    }
}

using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Fields
    Rigidbody2D rb2D = null;
    Timer timer = null;
    Timer pauseTimer = null;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //float magnitude = ConfigurationUtils.BallImpulseForce;
        //Vector2 direction = new Vector2(Mathf.Cos(20 * Mathf.PI / 180), Mathf.Sin(20 * Mathf.PI / 180));
        rb2D = GetComponent<Rigidbody2D>();
        //rb2D.velocity = magnitude * direction;

        pauseTimer = gameObject.AddComponent<Timer>();
        pauseTimer.Duration = ConfigurationUtils.BallLifetime;
        pauseTimer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseTimer.Finished && timer == null)
        {
            SetDirection(new Vector2(0, 1));
            
            timer = gameObject.AddComponent<Timer>();
            timer.Duration = ConfigurationUtils.BallLifetime;
            timer.Run();
        }

        if (timer != null && timer.Finished)
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
}

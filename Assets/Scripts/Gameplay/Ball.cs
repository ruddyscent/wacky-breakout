using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Fields
    Rigidbody2D rb2D = null;
    Timer timer = null;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //float magnitude = ConfigurationUtils.BallImpulseForce;
        //Vector2 direction = new Vector2(Mathf.Cos(20 * Mathf.PI / 180), Mathf.Sin(20 * Mathf.PI / 180));
        rb2D = GetComponent<Rigidbody2D>();
        //rb2D.velocity = magnitude * direction;

        timer = gameObject.AddComponent<Timer>();
        timer.Duration = ConfigurationUtils.BallLifetime;
        timer.Run();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.Finished)
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

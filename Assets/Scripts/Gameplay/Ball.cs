using UnityEngine;

public class Ball : MonoBehaviour
{
    #region Fields
    Rigidbody2D rb2D = null;
    BoxCollider2D bc2D = null;
    Timer pauseTimer = null;
    HUD hud = null;
    Timer speedEffectTimer = null;
    float speedEffectRatio = 0f;
    float originalSpeed = 0;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //float magnitude = ConfigurationUtils.BallImpulseForce;
        //Vector2 direction = new Vector2(Mathf.Cos(20 * Mathf.PI / 180), Mathf.Sin(20 * Mathf.PI / 180));
        rb2D = GetComponent<Rigidbody2D>();
        bc2D = GetComponent<BoxCollider2D>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();

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
            originalSpeed = rb2D.velocity.magnitude;
        }

        if (OnBecameInvisible())
        {
            hud.LooseBall();

            if (hud.BallsLeft > 0)
            {
                Camera m_MainCamera = Camera.main;
                m_MainCamera.GetComponent<BallSpawner>().SpawnBall();
            }

            Destroy(gameObject);
        }

        if (speedEffectTimer != null && speedEffectTimer.Finished)
        {
            rb2D.velocity = originalSpeed * rb2D.velocity.normalized;
            speedEffectTimer = null;
        }
    }

    public void SpeedEffect(float ratio, float seconds)
    {
        if (speedEffectRatio != ratio)
        {
            rb2D.velocity = originalSpeed * rb2D.velocity.normalized;
            rb2D.velocity = (1 + ratio) * rb2D.velocity;
            speedEffectRatio = ratio;
        }

        speedEffectTimer = gameObject.AddComponent<Timer>();
        speedEffectTimer.Duration = seconds;
        speedEffectTimer.Run();
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

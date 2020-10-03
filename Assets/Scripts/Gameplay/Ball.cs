using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    #region Fields
    Rigidbody2D rb2D = null;
    BoxCollider2D bc2D = null;
    Timer pauseTimer = null;
    HUD hud = null;
    Timer effectTimer = null;
    float speedEffectRatio = 0f;
    float originalSpeed = 0;

    LooseBallActivated looseBallEvent = new LooseBallActivated();
    SpawnBallActivated spawnBallEvent = new SpawnBallActivated();
    GameOverActivated gameOverEvent = new GameOverActivated();
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        bc2D = GetComponent<BoxCollider2D>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        
        EventManager.AddLooseBallInvoker(this);
        EventManager.AddSpawnBallInvoker(this);
        EventManager.AddGameOverInvoker(this);
        EventManager.AddGameOverListener(GameOver);

        // A new ball is paused for BallPauseTime seconds.
        pauseTimer = gameObject.AddComponent<Timer>();
        pauseTimer.Duration = ConfigurationUtils.BallPauseTime;
        pauseTimer.AddTimerFinishedListener(PauseTimerFinished);
        pauseTimer.Run();
    }

    void PauseTimerFinished()
    {
        Vector2 direction = new Vector2(0, -1);
        rb2D.velocity = direction;
        rb2D.AddForce(ConfigurationUtils.BallImpulseForce * direction, ForceMode2D.Impulse);
        Destroy(pauseTimer);
        pauseTimer = null;
        originalSpeed = rb2D.velocity.magnitude;
    }

    void EffectTimerFinished()
    {
        AudioManager.Play(AudioClipName.SpeedupEffectDeactivated);
        rb2D.velocity = originalSpeed * rb2D.velocity.normalized;
        effectTimer = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (OnBecameInvisible())
        {
            if (hud.BallsLeft > 0)
            {
                AudioManager.Play(AudioClipName.BallLost);
                looseBallEvent.Invoke();
                spawnBallEvent.Invoke();
            }
            else
            {
                gameOverEvent.Invoke();
            }

            Destroy(gameObject);
        }
    }

    void GameOver()
    {
        MenuManager.GoToMenu(MenuName.GameOver);
    }

    public virtual void Effect(float ratio, float seconds)
    {
        if (speedEffectRatio != ratio)
        {
            rb2D.velocity = originalSpeed * rb2D.velocity.normalized;
            rb2D.velocity = (1 + ratio) * rb2D.velocity;
            speedEffectRatio = ratio;
        }

        effectTimer = gameObject.AddComponent<Timer>();
        effectTimer.Duration = seconds;
        effectTimer.AddTimerFinishedListener(EffectTimerFinished);
        effectTimer.Run();
    }

    public void SetDirection(Vector2 direction)
    {
        float speed = rb2D.velocity.magnitude;
        rb2D.velocity = speed * direction;
    }

    bool OnBecameInvisible()
    {
        // AudioManager.Play(AudioClipName.BallLost);
        Vector2 position = gameObject.transform.position;
        float radius = bc2D.size.y / 2f;
        if (position.y < ScreenUtils.ScreenBottom - radius)
            return true;
        else
            return false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Play(AudioClipName.BallCollision);
    }

    //void OnTriggerEnter(Collider collision)
    //{
    //    AudioManager.Play(AudioClipName.BallCollision);
    //}

    public void AddLooseBallListener(UnityAction handler)
    {
        looseBallEvent.AddListener(handler);
    }

    public void AddSpawnBallListener(UnityAction handler)
    {
        spawnBallEvent.AddListener(handler);
    }

    public void AddGameOverListener(UnityAction handler)
    {
        gameOverEvent.AddListener(handler);
    }
}

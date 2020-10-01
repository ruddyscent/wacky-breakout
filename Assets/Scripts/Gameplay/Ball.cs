﻿using UnityEngine;
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
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        //float magnitude = ConfigurationUtils.BallImpulseForce;
        //Vector2 direction = new Vector2(Mathf.Cos(20 * Mathf.PI / 180), Mathf.Sin(20 * Mathf.PI / 180));
        rb2D = GetComponent<Rigidbody2D>();
        bc2D = GetComponent<BoxCollider2D>();
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
        EventManager.AddLooseBallInvoker(this);
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
        rb2D.velocity = originalSpeed* rb2D.velocity.normalized;
        effectTimer = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (OnBecameInvisible())
        {
            looseBallEvent.Invoke();

            if (hud.BallsLeft > 0)
            {
                Camera m_MainCamera = Camera.main;
                m_MainCamera.GetComponent<BallSpawner>().SpawnBall();
            }

            Destroy(gameObject);
        }
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
        Vector2 position = gameObject.transform.position;
        float radius = bc2D.size.y / 2f;
        if (position.y < ScreenUtils.ScreenBottom - radius)
            return true;
        else
            return false;
    }

    public void AddLooseBallListener(UnityAction handler)
    {
        looseBallEvent.AddListener(handler);
    }
}

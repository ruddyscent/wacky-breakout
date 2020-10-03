using UnityEngine;
using UnityEngine.Events;

public class SpeedupBlock : StandardBlock
{
    SpeedupEffectActivated speedupEvent = new SpeedupEffectActivated();

    // Start is called before the first frame update
    protected override void Start()
    {
        EventManager.AddSpeedupInvoker(this);
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override protected void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            AudioManager.Play(AudioClipName.SpeedupEffectActivated);
            Ball ball = collision.gameObject.GetComponent<Ball>();
            ball.Effect(ConfigurationUtils.SpeedupRatio, ConfigurationUtils.SpeedupTime);
        }
        base.OnCollisionEnter2D(collision);
    }

    public void AddSpeedupEffectListener(UnityAction<float, float> listener) {
        speedupEvent.AddListener(listener);
    }
}

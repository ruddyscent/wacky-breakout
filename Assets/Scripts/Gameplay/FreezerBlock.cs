using UnityEngine;

public class FreezerBlock : StandardBlock
{
    // Start is called before the first frame update
    protected override void  Start()
    {
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
            Ball ball = collision.gameObject.GetComponent<Ball>();
            ball.SpeedEffect(ConfigurationUtils.FreezingRatio, ConfigurationUtils.FreezingTime);
        }
        base.OnCollisionEnter2D(collision);
    }
}

using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D rb2D = null;
    
    // Start is called before the first frame update
    void Start()
    {
        //float magnitude = ConfigurationUtils.BallImpulseForce;
        //Vector2 direction = new Vector2(Mathf.Cos(20 * Mathf.PI / 180), Mathf.Sin(20 * Mathf.PI / 180));
        rb2D = GetComponent<Rigidbody2D>();
        //rb2D.velocity = magnitude * direction;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDirection(Vector2 direction)
    {
        float speed = rb2D.velocity.magnitude;
        rb2D.velocity = speed * direction;
    }
}

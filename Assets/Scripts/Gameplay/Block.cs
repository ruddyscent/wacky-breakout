using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Block : MonoBehaviour
{
    protected int points = 0;
    HUD hud = null;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        hud = GameObject.FindGameObjectWithTag("HUD").GetComponent<HUD>();
    }

    protected virtual void Effect() {

    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            hud.AddPoints(points);
            Destroy(gameObject);
        }
    }
}

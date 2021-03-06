﻿using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    protected int points = 0;
    AddPointsActivated addPointsEvent = new AddPointsActivated();
    BlockDestroyed blockDestroyedEvent = new BlockDestroyed();

    // Start is called before the first frame update
    protected virtual void Start()
    {
        EventManager.AddAddPointsInvoker(this);
        EventManager.AddBlockDestroyedInvoker(this);
    }

    protected virtual void Effect() {

    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            addPointsEvent.Invoke(points);
            Destroy(gameObject);
        }
    }

    public void AddPointsListener(UnityAction<int> listener)
    {
        addPointsEvent.AddListener(listener);
    }

    public void AddBlockDestroyedListener(UnityAction listener)
    {
        blockDestroyedEvent.AddListener(listener);
    }
}

﻿using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabBall = null;

    void Start()
    {
        EventManager.AddSpawnBallListener(SpawnBall);
    }
    
    void SpawnBall()
    {
        Instantiate(prefabBall, new Vector3(0, -1, 0), Quaternion.identity);
    }
}

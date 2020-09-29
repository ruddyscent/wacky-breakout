﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
    }

    public void HandleResumeButtonOnClickEvent()
    {
        Time.timeScale = 1;
        Destroy(gameObject);
    }

    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

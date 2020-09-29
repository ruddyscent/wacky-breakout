﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void HandlePlayButtonOnClickEvent()
    {
        SceneManager.LoadScene("Gameplay");
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

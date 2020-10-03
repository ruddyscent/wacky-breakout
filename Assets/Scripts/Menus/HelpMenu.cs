using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public void HandleBackButtonOnClickEvent()
    {
        AudioManager.Play(AudioClipName.MenuButtonClick);
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}

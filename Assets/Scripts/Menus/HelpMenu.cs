using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpMenu : MonoBehaviour
{
    public void HandleBackButtonOnClickEvent()
    {
        Destroy(gameObject);
        MenuManager.GoToMenu(MenuName.Main);
    }
}

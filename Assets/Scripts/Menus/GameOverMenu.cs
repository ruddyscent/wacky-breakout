using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void HandleQuitButtonOnClickEvent()
    {
        Application.Quit();
    }

    public void HandleBackButtonOnClickEvent()
    {
        SceneManager.LoadScene("MainMenu");
        Destroy(this);
    }
}

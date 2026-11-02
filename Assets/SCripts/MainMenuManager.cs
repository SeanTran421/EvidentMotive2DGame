using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Start button pressed");
    }

    public void QuitGame()
    {
        Debug.Log("Quit button pressed");
        Application.Quit();
    }
}

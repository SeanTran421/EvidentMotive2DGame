using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void StartGame()
    {
        //Debug.Log("Start button pressed");
        SceneManager.LoadScene("LevelSelect");
    }

    public void Instructions()
    {
        SceneManager.LoadScene("Instructions");
    }

    public void QuitGame()
    {
        //Debug.Log("Quit button pressed");
        Application.Quit();
    }
}

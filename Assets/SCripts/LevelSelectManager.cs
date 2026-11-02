using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{

    public void StartTestLevel()
    {
        SceneManager.LoadScene("TestScene");
    }

    public void TutorialLevel()
    {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void Level1Start()
    {
        SceneManager.LoadScene("Level1");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}

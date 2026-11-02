using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCompleteManager : MonoBehaviour
{

    public void backToLevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void TutorialLevel()
    {
        SceneManager.LoadScene("TutorialLevel");
    }

    public void Level1Start()
    {
        SceneManager.LoadScene("Level1");
    }

}

using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void fromInstruToMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

}

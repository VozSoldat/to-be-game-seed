using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void NewGame()
    {
        Debug.Log("New game option clicked.");
        SceneManager.LoadScene("BrewingDemo");
    }

    public void Settings()
    {
        Debug.Log("Settings option clicked.");
        SceneManager.LoadScene("Settings");
    }

    public void ExitGame()
    {
        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
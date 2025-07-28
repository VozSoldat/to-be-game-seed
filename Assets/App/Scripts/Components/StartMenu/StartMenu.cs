using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu
{
    public void Start()
    {
        Debug.Log("Start menu option clicked.");
        SceneManager.LoadScene("");
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
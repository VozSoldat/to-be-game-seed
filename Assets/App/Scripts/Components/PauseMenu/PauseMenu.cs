using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseUI;

    public void OnRestartPress()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnGameResumePress()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
    }

    public void OnGameExitPress()
    {
        Application.Quit();
    }

    public void PausePress()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
    }
}
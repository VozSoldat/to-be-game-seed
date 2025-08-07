using UnityEngine;
using UnityEngine.SceneManagement;

public class MB_CompleteButtonLogic : MonoBehaviour
{
    public void OnCompletedButtonClicked()
    {
        CharacterSceneState.CurrentState = CharacterAnimState.Drink;
        SceneManager.LoadScene("PostBrewScene");
    }
}

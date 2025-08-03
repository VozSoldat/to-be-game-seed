using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterLoader : MonoBehaviour
{
    [SerializeField] private SO_Character characterData;
    [SerializeField] private Animator animator;

    private void Start()
    {
        if (characterData == null || animator == null) return;

        ApplyAnimState(CharacterSceneState.CurrentState);
    }

    private void ApplyAnimState(CharacterAnimState state)
    {
        if (state == CharacterAnimState.Idle)
        {
            animator.Play("Idle");
        }
        else if (state == CharacterAnimState.Drink)
        {
            animator.Play("Drinking");
            Invoke(nameof(ReturnToIdleScene), characterData.drinkAnimation.length);
        }
    }

    private void ReturnToIdleScene()
    {
        CharacterSceneState.CurrentState = CharacterAnimState.Idle;
        SceneManager.LoadScene("Scene_Idle");
    }
}

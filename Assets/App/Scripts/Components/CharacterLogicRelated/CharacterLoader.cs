using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterLoader : MonoBehaviour
{
    [SerializeField] private SO_Character characterData;
    [SerializeField] private Animator animator;

    private void Start()
    {
        if (characterData == null || animator == null) return;

        animator.runtimeAnimatorController = characterData.animatorController;

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
            StartCoroutine(PlayDrinkAnimationWithDelay());
        }
    }

    private IEnumerator PlayDrinkAnimationWithDelay()
    {
        yield return new WaitForSeconds(2f);

        animator.Play("Drinking");

        if (characterData != null && characterData.drinkAnimation != null)
        {
            yield return new WaitForSeconds(characterData.drinkAnimation.length + 1f);
        }

        ReturnToIdleState();
        BackToCustomerScene();
    }

    private void ReturnToIdleState()
    {
        CharacterSceneState.CurrentState = CharacterAnimState.Idle;
    }

    private void BackToCustomerScene()
    {
        SceneManager.LoadScene("CustomerInquiry");
    }
}

using UnityEngine;

public class MB_AnimatorControllerLoader : MonoBehaviour
{
    [SerializeField] Animator characterAnimator;
    [SerializeField] SO_Character characterReference;

    void Start()
    {
        characterAnimator.runtimeAnimatorController = characterReference.animatorController;
    }
}
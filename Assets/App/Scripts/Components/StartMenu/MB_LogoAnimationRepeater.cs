using UnityEngine;

public class MB_LogoAnimationRepeater : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField] Animator logoAnimator;

    void OnEnable()
    {
        timer.OnTimerOutHandler += PlayAnimation;
    }
    void OnDisable()
    {
        timer.OnTimerOutHandler -= PlayAnimation;
    }

    void PlayAnimation()
    {
        logoAnimator.SetTrigger("PlayTrigger");
        // logoAnimator.Play("LogoAnimation");
        // Reset the timer for the next animation
        timer.ResetTime();
    }
}
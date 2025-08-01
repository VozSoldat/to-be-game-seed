using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float RemainingTime;
    public Action OnTimerOutHandler;
    private bool Timeout = false;

    void Update()
    {
        TimerCountdown();
        if (Timeout)
        {
             OnTimerOutHandler?.Invoke();
        }
    }

    public void TimerCountdown()
    {
        if (RemainingTime > 0)
        {
            RemainingTime -= Time.deltaTime;
            if (RemainingTime < 0)
            {
                RemainingTime = 0;
                Timeout = true;
            }
        } 
            int minutes = Mathf.FloorToInt(RemainingTime / 60);
            int Second = Mathf.FloorToInt(RemainingTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, Second);
    }
}

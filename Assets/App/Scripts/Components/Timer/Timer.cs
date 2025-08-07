using UnityEngine;
using System;


public class Timer : MonoBehaviour
{
    // [SerializeField] TextMeshProUGUI timerText;
    float remainingTime;
    [SerializeField] float initialTime = 10f; // Set the initial time for the timer
    public Action OnTimerOutHandler;

    private bool Timeout = false;

    void Start()
    {
        remainingTime = initialTime;
        Timeout = false;
    }
    public void ResetTime()
    {
        Timeout = false;
        remainingTime = initialTime;
    }
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
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            if (remainingTime < 0)
            {
                remainingTime = 0;
                Timeout = true;
            }
        }
        // int minutes = Mathf.FloorToInt(RemainingTime / 60);
        // int Second = Mathf.FloorToInt(RemainingTime % 60);
        // timerText.text = string.Format("{0:00}:{1:00}", minutes, Second);
    }
}

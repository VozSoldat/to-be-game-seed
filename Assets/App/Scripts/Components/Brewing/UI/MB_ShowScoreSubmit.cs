using System;
using TMPro;
using UnityEngine;

public class MB_ShowScoreSubmit : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _scoreText;
    
    public Func<int> OnScoreSubmittedHandler;

    public void ShowScore()
    {
        int score = OnScoreSubmittedHandler?.Invoke() ?? 0;
        _scoreText.text = $"Score: {score}";
    }
}
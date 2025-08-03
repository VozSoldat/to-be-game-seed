using UnityEngine;

public class MB_LeaderboardUI : MonoBehaviour
{
    [SerializeField] GameObject leaderboardPanel;
    [SerializeField] GameObject rowPrefab;

    public void ShowLeaderboard()
    {
        if (leaderboardPanel != null)
        {
            leaderboardPanel.SetActive(true);
        }
    }
    public void HideLeaderboard()
    {
        if (leaderboardPanel != null)
        {
            leaderboardPanel.SetActive(false);
        }
    }

    void OnEnable()
    {
        PopulateLeaderboard();
    }

    void PopulateLeaderboard()
    {
        // Logic to populate the leaderboard with rows
        // Instantiate rowPrefab for each entry in the leaderboard data
        // Set the data for each row
        
    }
}
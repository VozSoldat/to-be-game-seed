using UnityEngine;

public class MB_LeaderboardManager : MonoBehaviour
{
    public void UpdateLeaderboard(int newScore)
    {
        ScoreData previous = ScoreSaver.Load();

        if (newScore > previous.score)
        {
            ScoreSaver.Save(newScore);
            Debug.Log("New high score!");
        }
        else
        {
            Debug.Log("Score not high enough to update leaderboard.");
        }
    }
}
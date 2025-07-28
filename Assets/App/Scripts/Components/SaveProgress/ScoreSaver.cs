using System.IO;
using UnityEngine;

public class ScoreSaver
{
    private static readonly string path = Path.Combine(Application.persistentDataPath, "score.json");

    public static void Save(int score)
    {
        ScoreData scoreData = new() { score = score };
        string json = JsonUtility.ToJson(scoreData, true);
        File.WriteAllText(path, json);
        Debug.Log($"Score saved to {path}.");
    }

    public static ScoreData Load()
    {
        if (!File.Exists(path))
        {
            return new ScoreData();
        }

        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<ScoreData>(json);
    }
}
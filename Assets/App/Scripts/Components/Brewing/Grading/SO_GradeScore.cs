using UnityEngine;

[CreateAssetMenu(fileName = "SO_GradeScore", menuName = "Scriptable Objects/SO_GradeScore")]
public class SO_GradeScore : ScriptableObject
{
    public int scoreBitterness = 0;
    public int scoreSweetness = 0;
    public int scoreTemperature = 0;
    public int scoreBuff = 0;
    public int finalScore = 0;
    
    public void SaveScores(int bitterness, int sweetness, int temperature, int buff)
    {
        scoreBitterness = bitterness;
        scoreSweetness = sweetness;
        scoreTemperature = temperature;
        scoreBuff = buff;
        SaveFinalScore(scoreBitterness + scoreSweetness + scoreTemperature + scoreBuff);
        #if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }

    public void SaveFinalScore(int total)
    {
        finalScore = total;
        #if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
        #endif
    }
    
    public int GetCurrentScore()
    {
       return scoreBitterness + scoreSweetness + scoreTemperature + scoreBuff;
    }
    
    public void ResetScores()
    {
        scoreBitterness = 0;
        scoreSweetness = 0;
        scoreTemperature = 0;
        scoreBuff = 0;
        finalScore = 0;
#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
}

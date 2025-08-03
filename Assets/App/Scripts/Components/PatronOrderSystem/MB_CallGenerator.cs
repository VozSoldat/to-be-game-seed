using UnityEngine;

public class MB_CallGenerator : MonoBehaviour
{
    public MB_PatronOrderGenerator patronOrderGenerator;
    public MB_PatronGenerator patronGenerator;

    void Awake()
    {
        patronGenerator.ApplyRandomPatron();
        patronOrderGenerator.CreateCombinationsWithSources();
    }
}
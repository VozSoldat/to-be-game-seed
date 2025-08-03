using System;
using System.Collections.Generic;
using UnityEngine;

public class MB_PatronGenerator : MonoBehaviour
{
    [SerializeField] private List<PatronDTO> _patrons;

    public void GetRandomPatron()
    {
        if (_patrons == null || _patrons.Count == 0)
        {
            Debug.LogWarning("No patrons available to generate.");
            // return default;
        }
        int randomIndex = UnityEngine.Random.Range(0, _patrons.Count);
        Debug.Log($"Generated patron: {_patrons[randomIndex].Name}");
        // return _patrons[randomIndex];
    }

}
[Serializable]
public struct PatronDTO
{
    public string Name;
    public Sprite PatronSprite;
}
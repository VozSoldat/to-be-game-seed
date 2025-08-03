using System;
using System.Collections.Generic;
using UnityEngine;

public class MB_PatronGenerator : MonoBehaviour
{
    [SerializeField] private List<SO_Character> _characters;

    public SO_Character GetRandomPatron()
    {
        if (_characters == null || _characters.Count == 0)
        {
            Debug.LogWarning("No patrons available to generate.");
            return null;
        }
        int randomIndex = UnityEngine.Random.Range(0, _characters.Count);
        return _characters[randomIndex];
    }

}

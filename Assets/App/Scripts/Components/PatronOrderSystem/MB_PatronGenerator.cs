using System;
using System.Collections.Generic;
using UnityEngine;

public class MB_PatronGenerator : MonoBehaviour
{
    [SerializeField] private List<SO_Character> _characters;

    [SerializeField] SO_CharaDanPesan charaDanPesan;

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

    bool IsPatronRepeated(SO_Character newpatron)
    {
        if (charaDanPesan.character.characterName == newpatron.characterName)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
    public void ApplyRandomPatron()
    {
        SO_Character randomPatron = GetRandomPatron();

        if (IsPatronRepeated(randomPatron))
        {
            ApplyRandomPatron();
        }

        if (randomPatron != null)
        {
            charaDanPesan.character.characterName = randomPatron.characterName;
            charaDanPesan.character.staticSprite = randomPatron.staticSprite;
            charaDanPesan.character.idleAnimation = randomPatron.idleAnimation;
            charaDanPesan.character.drinkAnimation = randomPatron.drinkAnimation;
            charaDanPesan.character.animatorController = randomPatron.animatorController;
            Debug.Log($"Generated Patron: {randomPatron.characterName}");
        }
    }

}

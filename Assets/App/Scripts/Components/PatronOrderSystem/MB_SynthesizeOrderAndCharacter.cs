using System;
using System.Linq;
using UnityEngine;

public class MB_SynthesizeOrderAndCharacter : MonoBehaviour
{
    [SerializeField] MB_PatronGenerator patronGenerator;
    [SerializeField] MB_PatronOrderGenerator orderGenerator;

    [Header("SO References untuk jadi acuan scene lain")]
    [SerializeField] SO_CharaDanPesan charaDanPesan;

    public void SynthesizeOrderAndCharacter()
    {
        // TODO: implement logic to generate a character and an order, then assign them to the SO_CharaDanPesan
        var randomCharacter = patronGenerator.GetRandomPatron();

        var combination = orderGenerator.GetCombinations();
        var randomOrder = combination[UnityEngine.Random.Range(0, combination.Length)];

        if (randomCharacter != null && randomOrder != null)
        {
            charaDanPesan.character = randomCharacter;
            charaDanPesan.characterOrder = randomOrder;
            Debug.Log($"Synthesize successful: {randomCharacter.characterName} with order {randomOrder.itemName}");
        }
    }

}
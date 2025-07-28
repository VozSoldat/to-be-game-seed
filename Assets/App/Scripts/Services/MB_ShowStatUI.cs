using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MB_ShowStatUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI bitternessText;
    [SerializeField] private MB_BrewingStack brewingStack;
    // private Dictionary<StatType, FloatReference> stats;
    private void Update()
    {
        bitternessText.text = brewingStack.TotalBitterness.Value.ToString("F2");
    }
}

public enum StatType
{
    Bitterness,
    Sweetness,
    Temperature
}
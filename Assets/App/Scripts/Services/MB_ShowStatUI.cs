using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MB_ShowStatUI : MonoBehaviour
{
    [SerializeField] private MB_BrewingStack brewingStack;
    [SerializeField] private TextMeshProUGUI sweetnessText;
    [SerializeField] private TextMeshProUGUI bitternessText;
    [SerializeField] private TextMeshProUGUI temperatureText;

    public void Update()
    {
        if (brewingStack != null)
        {
            sweetnessText.text = $"Sweetness: {brewingStack.TotalSweetness}";
            bitternessText.text = $"Bitterness: {brewingStack.TotalBitterness}";
            temperatureText.text = $"Temperature: {brewingStack.TotalTemperature}";
        }
    }
}

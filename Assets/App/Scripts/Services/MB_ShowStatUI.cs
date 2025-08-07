using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MB_ShowStatUI : MonoBehaviour
{
    [SerializeField] private MB_BrewingStack brewingStack;
    [SerializeField] private TextMeshProUGUI sweetnessText;
    [SerializeField] private TextMeshProUGUI bitternessText;
    [SerializeField] private TextMeshProUGUI temperatureText;

    [Header("Bars")]
    [SerializeField] private MB_BarUI sweetnessBar;
    [SerializeField] private MB_BarUI bitternessBar;
    [SerializeField] private MB_BarUI temperatureBar;
    
    public void Update()
    {
        if (brewingStack != null)
        {
            sweetnessText.text = $"Sweetness: {brewingStack.TotalSweetness}";
            bitternessText.text = $"Bitterness: {brewingStack.TotalBitterness}";
            temperatureText.text = $"Temperature: {brewingStack.TotalTemperature}";

            sweetnessBar.UpdateBar(brewingStack.TotalSweetness);
            bitternessBar.UpdateBar(brewingStack.TotalBitterness);
            temperatureBar.UpdateBar(brewingStack.TotalTemperature);

            //rebuild screen
            LayoutRebuilder.ForceRebuildLayoutImmediate(sweetnessBar.transform as RectTransform);
        }
    }
}

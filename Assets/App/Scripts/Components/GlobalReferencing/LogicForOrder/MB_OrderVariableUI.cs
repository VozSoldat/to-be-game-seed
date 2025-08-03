using System;
using TMPro;
using UnityEngine;

public class MB_OrderVariableUI : MonoBehaviour
{
    [SerializeField] private SO_CharaDanPesan charaDanPesan;
    [SerializeField] private TextMeshProUGUI textView;

    private void Start()
    {
        if (charaDanPesan == null || textView == null)
        {
            Debug.LogError("SO_CharaDanPesan or TextMeshProUGUI is not assigned.");
            return;
        }

        // textView.text = charaDanPesan.characterOrder;
        string orderText = String.Concat(
            "Order for: ",
            charaDanPesan.character.characterName,
            "\nItem: ",
            charaDanPesan.characterOrder?.itemName ?? "No item selected"
        );
        textView.text = orderText;
    }

    void Update()
    {
        string orderText = String.Concat(
            "I want ", 
            "\nBitterness: ",
            charaDanPesan.characterOrder.bitterness,
            "\nSweetness: ",
            charaDanPesan.characterOrder.sweetness,
            "\nTemperature: ",
            charaDanPesan.characterOrder.temperature,
            "\nBuffs: ",
            charaDanPesan.characterOrder.itemBuffs != null && charaDanPesan.characterOrder.itemBuffs.Length > 0
                ? String.Join(", ", charaDanPesan.characterOrder.itemBuffs)
                : "No buffs"
        );
        textView.text = orderText;
    }
}

using UnityEngine;
using TMPro;

public class MB_UserOrderUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI orderText;
    [SerializeField] private SO_CharaDanPesan charaDanPesan;

    private void OnEnable()
    {
        UpdateOrderUI();
    }

    public void UpdateOrderUI()
    {
        string buff = "No Buff";
        if (charaDanPesan.characterOrder == null)
        {
            orderText.text = "No order available.";
            return;
        }

        if (charaDanPesan.characterOrder.itemBuffs != null && charaDanPesan.characterOrder.itemBuffs.Length > 0)
        {
            buff = string.Join(", ", System.Array.ConvertAll(charaDanPesan.characterOrder.itemBuffs, b => b.ToString()));
        }

        this.orderText.text = $"I would like a cup of coffee with \n" +
            $"Buffs: {buff}\n" +
            $"Bitterness: {charaDanPesan.characterOrder.bitterness}\n" +
            $"Sweetness: {charaDanPesan.characterOrder.sweetness}\n" +
            $"Temperature: {charaDanPesan.characterOrder.temperature}";
    }

    // Call this method when a new order is generated
    public void OnNewOrder()
    {
        UpdateOrderUI();
    }
}
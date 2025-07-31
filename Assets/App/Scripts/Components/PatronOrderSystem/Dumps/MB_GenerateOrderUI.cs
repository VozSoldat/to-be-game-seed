using UnityEngine;

public class MB_GenerateOrderUI : MonoBehaviour
{
    [SerializeField] MB_PatronOrderGenerator _patronOrderGenerator;

    public void GenerateOrder()
    {
        if (_patronOrderGenerator == null)
        {
            Debug.LogError("Patron Order Generator is not assigned.");
            return;
        }

        ItemData[] combinations = _patronOrderGenerator.GetCombinations();
        DisplayCombinations(combinations);
    }
    private void DisplayCombinations(ItemData[] combinations)
    {
        // Implement UI logic to display the combinations
        foreach (var item in combinations)
        {
            Debug.Log($"Item: {item.itemName}, Sweetness: {item.sweetness}, Bitterness: {item.bitterness}, Temperature: {item.temperature}");
        }
    }
}
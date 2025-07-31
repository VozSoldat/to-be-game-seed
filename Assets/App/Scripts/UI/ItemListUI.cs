using UnityEngine;
using System.Linq;

public class ItemListUI : MonoBehaviour
{
    public Transform contentParent;
    public GameObject itemCardPrefab;
    public ItemData[] items;

    private void Start()
    {
        // Initialize with all items or a default category
        ShowItemsByCategory(ItemCategory.Glass);
    }

    public void ShowItemsByCategory(ItemCategory category)
    {
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }
        var filteredItems = items.Where(item => item.category == category).ToArray();
        
        foreach (var item in filteredItems)
        {
            GameObject card = Instantiate(itemCardPrefab, contentParent);
            card.GetComponent<ItemCardUI>().Setup(item);
        }
    }
}

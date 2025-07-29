using UnityEngine;

public class ItemListUI : MonoBehaviour
{
    public Transform contentParent;
    public GameObject itemCardPrefab;
    public ItemData[] items; 

    private void Start()
    {
        foreach (var item in items)
        {
            GameObject card = Instantiate(itemCardPrefab, contentParent);
            card.GetComponent<ItemCardUI>().Setup(item);
        }
    }
}

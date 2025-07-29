using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ItemCardUI : MonoBehaviour
{
    public Image iconImage;
    public TMP_Text nameText;
    public TMP_Text sweetnessText;
    public TMP_Text bitternessText;
    public TMP_Text temperatureText;

    private ItemData itemData;

    public void Setup(ItemData data)
    {
        itemData = data;
        iconImage.sprite = data.itemIcon;
        nameText.text = data.itemName;
        sweetnessText.text = $"S: {data.sweetness}";
        bitternessText.text = $"B: {data.bitterness}";
        temperatureText.text = $"T: {data.temperature}";

        DraggableItem draggable = iconImage.GetComponent<DraggableItem>();
        if (draggable != null)
        {   
            draggable.itemData = data;
        }

        DraggableItemGhost draggableGhost = GetComponent<DraggableItemGhost>();
        if (draggableGhost != null)
        {
            draggableGhost.itemData = data;
            draggableGhost.iconImage = iconImage;
        }
    }

}

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
    public TMP_Text buffText; // Text to display item buffs

    private ItemData itemData;

    public void Setup(ItemData data)
    {
        itemData = data;
        iconImage.sprite = data.itemIcon;
        nameText.text = data.itemName;
        
        // Handle sweetness value
        if (data.sweetness == 0)
        {
            if (sweetnessText.transform.parent != null)
                Destroy(sweetnessText.transform.parent.gameObject);
        }
        else
        {
            sweetnessText.text = data.sweetness > 0 ? $"+{data.sweetness}" : $"{data.sweetness}";
        }
        
        // Handle bitterness value
        if (data.bitterness == 0)
        {
            if (bitternessText.transform.parent != null)
                Destroy(bitternessText.transform.parent.gameObject);
        }
        else
        {
            bitternessText.text = data.bitterness > 0 ? $"+{data.bitterness}" : $"{data.bitterness}";
        }
        
        // Handle temperature value
        if (data.temperature == 0)
        {
            if (temperatureText.transform.parent != null)
                Destroy(temperatureText.transform.parent.gameObject);
        }
        else
        {
            temperatureText.text = data.temperature > 0 ? $"+{data.temperature}" : $"{data.temperature}";
        }

        // Handle buffs
        if (buffText != null)
        {
            if (data.itemBuffs == null || data.itemBuffs.Length == 0)
            {
                if (buffText.transform.parent != null)
                    Destroy(buffText.transform.parent.gameObject);
            }
            else
            {
                string buffsString = "";
                foreach (ItemBuff buff in data.itemBuffs)
                {
                    if (buffsString.Length > 0)
                        buffsString += ", ";
                    buffsString += buff.ToString();
                }
                buffText.text = buffsString;
            }
        }

        DraggableItemGhost draggableGhost = GetComponent<DraggableItemGhost>();
        if (draggableGhost != null)
        {
            draggableGhost.itemData = data;
            draggableGhost.iconImage = iconImage;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropTarget : MonoBehaviour, IDropHandler
{
    public ItemData itemData;
    public MB_BrewingStack brewingStack;
    public Image glassImage;


    private void Start()
    {
        if (glassImage == null)
        {
            glassImage = GetComponent<Image>();
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        DraggableItemGhost dragged = eventData.pointerDrag?.GetComponent<DraggableItemGhost>();
        if (dragged != null)
        {
            if (brewingStack == null)
            {
                Debug.LogError("BrewingStack is not assigned to PourArea!");
                return;
            }

            if (dragged.itemData == null)
            {
                Debug.LogError("Dragged item has no ItemData assigned!");
                return;
            }

            brewingStack.AddPour(dragged.itemData);
            Debug.Log($"Used item: {dragged.itemData.itemName}");
        }
    }

    public void SetGlassSprite(Sprite glassSprite)
    {
        if (glassImage != null)
        {
            glassImage.sprite = glassSprite;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DropTarget : MonoBehaviour, IDropHandler
{
    public ItemData itemData;
    public MB_BrewingStack brewingStack;

    public void OnDrop(PointerEventData eventData)
    {
        DraggableItem dragged = eventData.pointerDrag?.GetComponent<DraggableItem>();
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

            Debug.Log($"Used item: {dragged.itemData.itemName}");
            brewingStack.AddPour(dragged.itemData);
        }
    }

}

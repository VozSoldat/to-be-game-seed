using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MB_InventorySlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount==0)
        {
            GameObject dropped = eventData.pointerDrag;
            MB_DraggableItem draggableItem = dropped.GetComponent<MB_DraggableItem>();
            draggableItem.parentAfterDrag = transform;
        }
    }
}

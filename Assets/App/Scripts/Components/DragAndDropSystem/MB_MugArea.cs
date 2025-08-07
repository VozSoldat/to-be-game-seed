using UnityEngine;
using UnityEngine.EventSystems;

public class MB_MugArea : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("Mug area dropped on");
    }
}
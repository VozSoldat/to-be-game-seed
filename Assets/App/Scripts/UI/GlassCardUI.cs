using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class GlassCardUI : MonoBehaviour, IPointerClickHandler
{
    public Image iconImage;
    public TMP_Text nameText;

    private GlassData glassData;
    private MB_BrewingStack brewingStack;
    private DropTarget dropTarget;

    private void Start()
    {
        brewingStack = FindAnyObjectByType<MB_BrewingStack>();
        Debug.Log($"BrewingStack found: {brewingStack != null}");
        dropTarget = FindAnyObjectByType<DropTarget>();
        Debug.Log($"DropTarget found: {dropTarget != null}");
    }

    public void Setup(GlassData data)
    {
        glassData = data;
        iconImage.sprite = data.itemIcon;
        nameText.text = data.itemName;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        SelectGlass();
    }

    private void SelectGlass()
    {
        if (brewingStack != null && glassData != null)
        {
            brewingStack.SetMaxPour(glassData.maxCapacity);
            Debug.Log($"Selected {glassData.itemName} with capacity {glassData.maxCapacity}");
            
            if (dropTarget != null && dropTarget.GetComponent<Image>() != null)
            {
                dropTarget.GetComponent<Image>().sprite = glassData.itemIcon;
            }
        }
    }
}
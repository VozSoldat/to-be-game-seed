using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class StackBar : StatBar
{
    [Header("Stack Bar Settings")]
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private MB_BrewingStack brewingStack;
    
    void Start()
    {
        
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        if (brewingStack == null)
        {
            Debug.LogWarning("StackBar: No brewing stack reference assigned.");
            return;
        }
        
        var items = brewingStack.Pours;
        
        if (items == null || items.Count == 0)
        {
            GenerateEmptyBar();
            return;
        }

        GenerateColoredBar(items);
    }


    private void GenerateEmptyBar()
    {
        ClearBar(filledBarRoot.transform);
        ClearBar(emptyBarRoot.transform);
        
        int capacity = brewingStack != null ? brewingStack.GetMaxPour() : 5;

        for (int i = 0; i < capacity; i++)
        {
            Sprite spriteEmpty = GetPartSprite(i, emptyLeft, emptyCenter, emptyRight, capacity);
            CreateImage(emptyBarRoot.transform, spriteEmpty);
        }
    }

    private void GenerateColoredBar(Stack<ItemData> items)
    {
        ClearBar(filledBarRoot.transform);
        ClearBar(emptyBarRoot.transform);
        
        ItemData[] itemArray = items.ToArray();
        int capacity = brewingStack != null ? brewingStack.GetMaxPour() : 5;
        int filledCount = itemArray.Length;

        for (int i = 0; i < capacity; i++)
        {
            Sprite spriteEmpty = GetPartSprite(i, emptyLeft, emptyCenter, emptyRight, capacity);
            CreateImage(emptyBarRoot.transform, spriteEmpty);
        }

        for (int i = 0; i < filledCount; i++)
        {
            Sprite spriteFilled = GetPartSprite(i, filledLeft, filledCenter, filledRight, capacity);
            
            GameObject go = Instantiate(imagePrefab, filledBarRoot.transform);
            Image img = go.GetComponent<Image>();
            img.sprite = spriteFilled;
            
            img.color = itemArray[itemArray.Length - 1 - i].stackColor;
        }
    }

    public new Sprite GetPartSprite(int index, Sprite left, Sprite center, Sprite right, int capacity)
    {
        return base.GetPartSprite(index, left, center, right, capacity);
    }
}

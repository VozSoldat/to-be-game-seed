using System.Collections.Generic;
using UnityEngine;

public class MB_BrewingStack : MonoBehaviour
{
    public Stack<ItemData>  Pours { get; private set; }

    [SerializeField] private int maxPour = -1;
    [SerializeField] private object StackInformation;

    private bool isMagicItemPoured = false;

    void Start()
    {
        Pours = new Stack<ItemData>(maxPour);
    }

    public void SetMaxPour(int newMax)
    {
        maxPour = newMax;
        while (Pours != null && Pours.Count > maxPour)
        {
            var removed = Pours.Pop();
            Debug.Log($"Removed {removed.itemName} due to glass size change.");
        }

        Debug.Log($"Glass size changed. New max capacity: {maxPour}");
    }

    public int GetMaxPour()
    {
        return maxPour;
    }

    public void AddPour(ItemData item)
    {
        Pours ??= new Stack<ItemData>(maxPour);

        if (Pours.Count >= maxPour)
        {
            Debug.LogWarning($"Cannot add item: {item.itemName}. Stack is full with {maxPour} items.");
            return;
        }

        if (isMagicItemPoured)
        {
            Debug.LogWarning($"Cannot add more ingredient after a magic item has been poured.");
            return;
        }

        if (item.category == ItemCategory.MagicItem)
        {
            isMagicItemPoured = true;
            Debug.Log($"Magic item poured: {item.itemName}");
        }

        Pours.Push(item);
        Debug.Log($"Added {item.itemName} to the brewing stack.");

        // logging every stack
        // Debug.Log("Current brewing stack:");
        foreach (var pour in Pours)
        {
            Debug.Log($"- {pour.itemName}");
        }
        // log the total sweetness, bitterness, and temperature
        // Debug.Log($"Total Sweetness: {TotalSweetness}");
        // Debug.Log($"Total Bitterness: {TotalBitterness}");
        // Debug.Log($"Total Temperature: {TotalTemperature}");

        // update text on the scene

        if (StackInformation is MB_ShowStatUI statUI)
        {
            statUI.Update();
        }
        else
        {
            Debug.LogWarning("StackInformation is not set or does not implement MB_ShowStatUI.");
        }
    }

    public void ResetPours()
    {
        Pours.Clear();
        isMagicItemPoured = false;
    }

    public float TotalSweetness
    {
        get
        {
            float total = 0f;
            foreach (var item in Pours)
            {
                total += item.sweetness;
            }
            return total;
        }
    }

    public float TotalBitterness
    {
        get
        {
            float total = 0f;
            foreach (var item in Pours)
            {
                total += item.bitterness;
            }
            return total;
        }
    }

    public float TotalTemperature
    {
        get
        {
            float total = 0f;
            foreach (var item in Pours)
            {
                total += item.temperature;
            }
            return total;
        }
    }
}

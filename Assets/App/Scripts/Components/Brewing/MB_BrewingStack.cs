using System.Collections.Generic;
using UnityEngine;

public class MB_BrewingStack : MonoBehaviour
{
    public Stack<ItemData> Pours { get; private set; }

    [SerializeField] private int maxPour = 0;
    [SerializeField] private MB_ShowStatUI StackInformation;

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

    public int TotalSweetness
    {
        get
        {
            int total = 0;
            if (Pours == null) return total;
            ItemData[] StackPour = Pours.ToArray(); // dibuat array
            for (int i = StackPour.Length - 1; i >= 0; i--) // dihitung dari belakang, ga tau kenapa kalau dari depan malah ga sesuai
            {
                total += StackPour[i].sweetness;
                total = Mathf.Clamp(total, 0, 5);
            }
            return total;
        }
    }

    public int TotalBitterness
    {
        get
        {
            int total = 0;
            if (Pours == null) return total;
            ItemData[] StackPour = Pours.ToArray();
            for (int i = StackPour.Length - 1; i >= 0; i--)
            {
                total += StackPour[i].bitterness;
                total = Mathf.Clamp(total, 0, 5);
            }
            return total;
        }
    }

    public int TotalTemperature
    {
        get
        {
            int total = 0;
            if (Pours == null) return total;
            ItemData[] StackPour = Pours.ToArray();
            for (int i = StackPour.Length - 1; i >= 0; i--)
            {
                total += StackPour[i].temperature;
                total = Mathf.Clamp(total, 0, 5);
            }
            return total;
        }
    }
}

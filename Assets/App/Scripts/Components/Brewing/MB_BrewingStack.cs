using System.Collections.Generic;
using UnityEngine;

public class MB_BrewingStack : MonoBehaviour
{
    public Stack<SO_Pour> Pours { get; set; }
    [SerializeField] int maxPour = 10;
    void Start()
    {
        Pours = new Stack<SO_Pour>(maxPour);
    }
    public void AddPour(SO_Pour pour)
    {
        Pours ??= new Stack<SO_Pour>(maxPour);
        if (Pours.Count >= maxPour)
        {
            Debug.LogWarning($"Cannot add pour: {pour.Name}. Brewing stack is full with {maxPour} pours.");
            return;
        }
        Pours.Push(pour);
        
    }
    public void ResetPours()
    {
        Pours.Clear();
    }
    public FloatReference TotalBitterness
    {
        get
        {
            float total = 0f;
            foreach (var pour in Pours)
            {
                total += pour.Bitterness.Value;
            }
            return new FloatReference(total);
        }
    }
    public FloatReference TotalSweetness
    {
        get
        {
            float total = 0f;
            foreach (var pour in Pours)
            {
                total += pour.Sweetness.Value;
            }
            return new FloatReference(total);
        }
    }
    public FloatReference TotalTemperature
    {
        get
        {
            float total = 0f;
            foreach (var pour in Pours)
            {
                total += pour.Temperature.Value;
            }
            return new FloatReference(total);
        }
    }
}
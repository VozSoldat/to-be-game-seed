using UnityEngine;

public class MB_InsertPourUI : MonoBehaviour
{
    [SerializeField] ItemData pour;
    [SerializeField] MB_BrewingStack brewingStack;

    public void InsertPour()
    {
        if (pour != null && brewingStack != null)
        {
            brewingStack.AddPour(pour);
            Debug.Log($"Inserted pour: {pour.itemName}");
        }
        else
        {
            Debug.LogWarning("Pour or BrewingStack is not set.");
        }
    }
}
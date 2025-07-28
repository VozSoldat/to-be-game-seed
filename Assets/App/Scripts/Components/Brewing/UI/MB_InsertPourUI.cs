using UnityEngine;

public class MB_InsertPourUI : MonoBehaviour
{
    [SerializeField] Pour pour;
    [SerializeField] BrewingStack brewingStack;

    public void InsertPour()
    {
        if (pour != null && brewingStack != null)
        {
            brewingStack.AddPour(pour);
            Debug.Log($"Inserted pour: {pour.Name}");
        }
        else
        {
            Debug.LogWarning("Pour or BrewingStack is not set.");
        }
    }
}
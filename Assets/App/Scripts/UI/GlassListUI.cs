using UnityEngine;
using System.Collections.Generic;

public class GlassListUI : MonoBehaviour
{
    public Transform contentParent;
    public GameObject glassCardPrefab; // Prefab with GlassCardUI component
    
    [SerializeField] public List<GlassData> availableGlasses;

    private void Start()
    {
        PopulateGlassList();
    }

    public void PopulateGlassList()
    {
        Debug.Log("Populating Glass List UI with available glasses.");
        foreach (Transform child in contentParent)
        {
            Destroy(child.gameObject);
        }

        foreach (GlassData glass in availableGlasses)
        {
            GameObject cardObj = Instantiate(glassCardPrefab, contentParent);
            GlassCardUI cardUI = cardObj.GetComponent<GlassCardUI>();
            if (cardUI != null)
            {
                cardUI.Setup(glass);
            }
        }
    }

    public void SetAvailableGlasses(List<GlassData> glasses)
    {
        availableGlasses = glasses;
        PopulateGlassList();
    }
}
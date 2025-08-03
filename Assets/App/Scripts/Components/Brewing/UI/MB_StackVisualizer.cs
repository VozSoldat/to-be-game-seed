using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MB_StackVisualizer : MonoBehaviour
{
    [SerializeField] private MB_BrewingStack brewingStack;
    [SerializeField] private Transform visualizationParent; // Parent transform where all visualizations will be added
    [SerializeField] private GameObject itemVisualPrefab; // Prefab for item visualization
    [SerializeField] private float verticalSpacing = 0.2f; // Space between stacked items
    [SerializeField] private Vector3 basePosition = Vector3.zero; // Starting position for the stack
    
    [Header("Layering")]
    [SerializeField] private Transform layer1Root; // Root for coffee and milk items
    [SerializeField] private Transform layer2Root; // Root for elemental stones
    [Range(0, 255)]
    [SerializeField] private int coffeeOpacity = 240; // Opacity for coffee items
    [Range(0, 255)]
    [SerializeField] private int milkOpacity = 50; // Opacity for milk items

    [Header("Glass Image")]
    [SerializeField] private Sprite smallGlassImage;
    [SerializeField] private Sprite mediumGlassImage; 
    [SerializeField] private Sprite largeGlassImage; 

    private List<GameObject> visualObjects = new List<GameObject>();
    private int lastStackCount = 0;

    private void Start()
    {
        if (brewingStack == null)
        {
            brewingStack = FindAnyObjectByType<MB_BrewingStack>();
            if (brewingStack == null)
            {
                Debug.LogError("No BrewingStack found in the scene!");
                return;
            }
        }

        if (visualizationParent == null)
        {
            visualizationParent = transform;
        }

        if (layer1Root == null)
        {
            GameObject layer1Obj = new GameObject("Layer1_Root");
            layer1Root = layer1Obj.transform;
            layer1Root.SetParent(visualizationParent, false);
            layer1Root.localPosition = Vector3.zero;
        }

        if (layer2Root == null)
        {
            GameObject layer2Obj = new GameObject("Layer2_Root");
            layer2Root = layer2Obj.transform;
            layer2Root.SetParent(visualizationParent, false);
            layer2Root.localPosition = Vector3.zero;
        }

        if (smallGlassImage == null || mediumGlassImage == null || largeGlassImage == null)
        {
            Debug.LogWarning("One or more glass sprites are not assigned in the Inspector. Glass visualization will not work correctly.");
        }

        UpdateVisualization();
    }

    private void Update()
    {
        if (brewingStack.Pours != null && brewingStack.Pours.Count != lastStackCount)
        {
            UpdateVisualization();
        }
    }

    public void UpdateVisualization()
    {
        ClearVisualizations();

        if (brewingStack.Pours == null || brewingStack.Pours.Count == 0)
        {
            lastStackCount = 0;
            UpdateGlassVisibility(brewingStack.GetMaxPour());
            return;
        }

        ItemData[] stackItems = brewingStack.Pours.ToArray();
        lastStackCount = stackItems.Length;

        int cupSize = brewingStack.GetMaxPour();
        
        UpdateGlassVisibility(cupSize);

        for (int i = stackItems.Length - 1; i >= 0; i--)
        {
            ItemData item = stackItems[i];
            if (item.visualRepresentation == null)
            {
                Debug.LogWarning($"Item {item.itemName} has no visual representation.");
                continue;
            }

            GameObject visualObj = Instantiate(itemVisualPrefab, visualizationParent);
            
            Transform targetLayer = visualizationParent;
            Color imageColor = Color.white;
            
            switch (item.category)
            {
                case ItemCategory.Coffee:
                    targetLayer = layer1Root;
                    imageColor = new Color(1, 1, 1, coffeeOpacity / 255f);
                    break;
                case ItemCategory.Milk:
                    targetLayer = layer1Root;
                    imageColor = new Color(1, 1, 1, milkOpacity / 255f);
                    break;
                case ItemCategory.ElementalStone:
                    targetLayer = layer2Root;
                    break;
                default:
                    break;
            }
            
            visualObj.transform.SetParent(targetLayer, false);
            
            int stackPosition = stackItems.Length - 1 - i;
            visualObj.transform.localPosition = basePosition + new Vector3(0, verticalSpacing * stackPosition, 0);
            
            Image spriteImage = visualObj.GetComponent<Image>();
            if (spriteImage != null)
            {
                Sprite visualSprite = GetSpriteForCupSize(item.visualRepresentation, cupSize);
                if (visualSprite != null)
                {
                    spriteImage.sprite = visualSprite;
                    spriteImage.color = imageColor;
                }
                else
                {
                    Debug.LogWarning($"No {cupSize} visual found for item {item.itemName}");
                }
            }

            visualObj.name = $"Visual_{item.itemName}";
            visualObjects.Add(visualObj);
        }
    }

    private Sprite GetSpriteForCupSize(VisualRepresentation visual, int cupSize)
    {
        switch (cupSize)
        {
            case 3:
                return visual.smallCupVisual;
            case 4:
                return visual.mediumCupVisual;
            case 5:
                return visual.largeCupVisual;
            default:
                return visual.mediumCupVisual; 
        }
    }

    private void ClearVisualizations()
    {
        GameObject glassObj = null;
        
        foreach (GameObject obj in visualObjects)
        {
            if (obj != null)
            {
                if (obj.name.StartsWith("GlassVisual_"))
                {
                    glassObj = obj;
                    continue;
                }
                Destroy(obj);
            }
        }
        
        visualObjects.Clear();
        
        if (glassObj != null)
        {
            visualObjects.Add(glassObj);
        }
        
        if (layer1Root != null)
        {
            foreach (Transform child in layer1Root)
            {
                if (child.gameObject != null && child.name.StartsWith("GlassVisual_"))
                {
                    continue;
                }
                Destroy(child.gameObject);
            }
        }
        
        if (layer2Root != null)
        {
            foreach (Transform child in layer2Root)
            {
                Destroy(child.gameObject);
            }
        }
    }

    public void OnGlassSizeChanged()
    {
        UpdateVisualization();
    }
    
    private void UpdateGlassVisibility(int cupSize)
    {
        if (smallGlassImage == null || mediumGlassImage == null || largeGlassImage == null)
        {
            Debug.LogWarning("One or more glass sprites are not assigned in the inspector!");
            return;
        }
        
        GameObject glassObj = null;
        foreach (GameObject obj in visualObjects)
        {
            if (obj.name.StartsWith("GlassVisual_"))
            {
                glassObj = obj;
                break;
            }
        }
        
        if (glassObj == null)
        {
            glassObj = Instantiate(itemVisualPrefab, layer1Root); 
            glassObj.name = "GlassVisual_Glass";
            glassObj.transform.localPosition = basePosition; 
            visualObjects.Add(glassObj);
        }
        else if (glassObj.transform.parent != layer1Root)
        {
            glassObj.transform.SetParent(layer1Root, false);
        }
        
        Image glassImage = glassObj.GetComponent<Image>();
        if (glassImage != null)
        {
            Sprite glassSprite = null;
            
            switch (cupSize)
            {
                case 3:
                    glassSprite = smallGlassImage;
                    break;
                case 4:
                    glassSprite = mediumGlassImage;
                    break;
                case 5:
                    glassSprite = largeGlassImage;
                    break;
                default:
                    glassSprite = mediumGlassImage;
                    break;
            }
            
            glassImage.sprite = glassSprite;
        }
    }
    
    public void SetCoffeeOpacity(int opacity)
    {
        coffeeOpacity = Mathf.Clamp(opacity, 0, 255);
        UpdateVisualization();
    }
    
    public void SetMilkOpacity(int opacity)
    {
        milkOpacity = Mathf.Clamp(opacity, 0, 255);
        UpdateVisualization();
    }
}

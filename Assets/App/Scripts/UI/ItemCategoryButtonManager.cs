using UnityEngine;
using UnityEngine.UI;
using StateMachines.ItemListStateMachine;

public class ItemCategoryButtonManager : MonoBehaviour
{
    [Header("Category Buttons")]
    public Button glassButton;
    public Button coffeeButton;
    public Button elementalStoneButton;
    public Button milkButton;
    public Button magicItemButton;

    [Header("State Context Reference")]
    public MB_ItemListStateContext stateContext;

    [Header("Button Visual Feedback")]
    public Color selectedColor = Color.cyan;
    public Color normalColor = Color.white;

    private Button currentSelectedButton;

    void Start()
    {
        if (stateContext == null)
            stateContext = FindAnyObjectByType<MB_ItemListStateContext>();

        SetupButtons();
        
        // Set initial selected button (Glass by default)
        SetSelectedButton(glassButton);
    }

    void SetupButtons()
    {
        if (glassButton != null)
            glassButton.onClick.AddListener(() => OnCategoryButtonClicked(ItemListStateEnum.Glass, glassButton));
        
        if (coffeeButton != null)
            coffeeButton.onClick.AddListener(() => OnCategoryButtonClicked(ItemListStateEnum.Coffee, coffeeButton));
        
        if (elementalStoneButton != null)
            elementalStoneButton.onClick.AddListener(() => OnCategoryButtonClicked(ItemListStateEnum.ElementalStone, elementalStoneButton));
        
        if (milkButton != null)
            milkButton.onClick.AddListener(() => OnCategoryButtonClicked(ItemListStateEnum.Milk, milkButton));
        
        if (magicItemButton != null)
            magicItemButton.onClick.AddListener(() => OnCategoryButtonClicked(ItemListStateEnum.MagicItem, magicItemButton));
        Debug.Log("Category buttons setup complete");
    }

    void OnCategoryButtonClicked(ItemListStateEnum state, Button clickedButton)
    {
        if (stateContext != null)
        {
            Debug.Log($"Transitioning to {state} state");
            stateContext.TransitionToState(state);
            SetSelectedButton(clickedButton);
        }
        else
        {
            Debug.LogError("State context is null - cannot transition states!");
        }
    }

    void SetSelectedButton(Button selectedButton)
    {
        // Reset previous button color
        if (currentSelectedButton != null)
        {
            currentSelectedButton.GetComponent<Image>().color = normalColor;
        }

        // Set new selected button color
        if (selectedButton != null)
        {
            selectedButton.GetComponent<Image>().color = selectedColor;
            currentSelectedButton = selectedButton;
        }
    }

    void OnDestroy()
    {
        // Clean up listeners
        glassButton?.onClick.RemoveAllListeners();
        coffeeButton?.onClick.RemoveAllListeners();
        elementalStoneButton?.onClick.RemoveAllListeners();
        milkButton?.onClick.RemoveAllListeners();
        magicItemButton?.onClick.RemoveAllListeners();
    }
}
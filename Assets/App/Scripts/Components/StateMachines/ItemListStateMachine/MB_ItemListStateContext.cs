using System;
using System.Collections.Generic;
using StateMachines;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachines.ItemListStateMachine
{
    public class MB_ItemListStateContext : MB_AbstractStateContext<ItemListStateEnum, MB_ItemListStateContext>
    {
        private Dictionary<ItemListStateEnum, AbstractState<MB_ItemListStateContext>> _stateMap;
        public override Dictionary<ItemListStateEnum, AbstractState<MB_ItemListStateContext>> StateMap => _stateMap;

        [SerializeField] private ItemListUI itemListUI;

        [Header("name of current category")]
        private string _currentCategoryName;
        [SerializeField] private TMPro.TextMeshProUGUI categoryText;

        [Header("Buttons to Control its State")]
        public ButtonAndPlace coffeeButtonPlace;
        public ButtonAndPlace elementalStoneButtonPlace;
        public ButtonAndPlace milkButtonPlace;
        public ButtonAndPlace magicItemButtonPlace;


        private readonly Dictionary<ItemCategory, string> _displayNames = new()
        {
            { ItemCategory.Glass, "Glass" },
            { ItemCategory.Coffee, "Coffee Beans" },
            { ItemCategory.ElementalStone, "Gem Stones" },
            { ItemCategory.Milk, "Milk Products" },
            { ItemCategory.MagicItem, "Magic Items" },
        };

        void Start()
        {
            if (itemListUI == null)
                itemListUI = GetComponent<ItemListUI>();

            _stateMap = new Dictionary<ItemListStateEnum, AbstractState<MB_ItemListStateContext>>
            {
                { ItemListStateEnum.Glass, new GlassState() },
                { ItemListStateEnum.Coffee, new CoffeeState() },
                { ItemListStateEnum.ElementalStone, new ElementalStoneState() },
                { ItemListStateEnum.Milk, new MilkState() },
                { ItemListStateEnum.MagicItem, new MagicItemState() },
            };

            // Start with Glass state by default
            TransitionToState(ItemListStateEnum.Glass);
        }

        public void UpdateItemList(ItemCategory category)
        {
            if (itemListUI != null)
            {
                itemListUI.ShowItemsByCategory(category);
            }

            _currentCategoryName = category.ToString();

            if (_displayNames.TryGetValue(category, out var displayName))
            {
                categoryText.text = displayName;
            }
            else
            {
                categoryText.text = category.ToString();
            }
        }

        public override void TransitionToState(ItemListStateEnum newState)
        {
            base.TransitionToState(newState);
        }

        // Public methods to transition to specific states
        public void ShowGlassItems() => TransitionToState(ItemListStateEnum.Glass);
        public void ShowCoffeeItems() => TransitionToState(ItemListStateEnum.Coffee);
        public void ShowElementalStoneItems() => TransitionToState(ItemListStateEnum.ElementalStone);
        public void ShowMilkItems() => TransitionToState(ItemListStateEnum.Milk);
        public void ShowMagicItems() => TransitionToState(ItemListStateEnum.MagicItem);

        /// <summary>
        /// Returns to the Glass state, which is the default state.
        /// </summary>
        /// <remarks>
        /// Useful for the TRASH button
        /// </remarks>
        public void ReturnToGlassState()
        {
            TransitionToState(ItemListStateEnum.Glass);
        }
    }

    [Serializable]
    public class ButtonAndPlace
    {
        public Button button;
        public Image place;
    }
}
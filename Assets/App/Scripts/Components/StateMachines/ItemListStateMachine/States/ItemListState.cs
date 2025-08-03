using StateMachines;
using UnityEngine;

namespace StateMachines.ItemListStateMachine
{
    public abstract class ItemListState : AbstractState<MB_ItemListStateContext>
    {
        protected ItemCategory category;
        private Sprite placeNormalSprite;

        protected ItemListState(ItemCategory itemCategory)
        {
            category = itemCategory;
        }

        public override void Enter(MB_ItemListStateContext context)
        {
            // Debug.Log($"Entering {category} State");
            context.UpdateItemList(category);




        }

        public override void UpdateExecute(MB_ItemListStateContext context)
        {
            // Base update logic if needed
        }

        public override void Exit(MB_ItemListStateContext context)
        {
            // Debug.Log($"Exiting {category} State");

        }

        protected void SetButtonState(MB_ItemListStateContext context, ButtonAndPlace buttonPlace, bool isSelected)
        {
            if (isSelected)
            {
                // Manually set the button and place sprite state ===================================================================;

                placeNormalSprite = buttonPlace.place.sprite;

                buttonPlace.button.interactable = false;
                buttonPlace.place.sprite = buttonPlace.button.spriteState.selectedSprite;
            }
            else
            {
                // Reset the button and place sprite state ===================================================================
                buttonPlace.button.interactable = true;
                buttonPlace.place.sprite = placeNormalSprite;
            }
        }
    }
}
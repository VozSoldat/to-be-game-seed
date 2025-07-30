using StateMachines;
using UnityEngine;

namespace StateMachines.ItemListStateMachine
{
    public abstract class ItemListState : AbstractState<MB_ItemListStateContext>
    {
        protected ItemCategory category;

        protected ItemListState(ItemCategory itemCategory)
        {
            category = itemCategory;
        }

        public override void Enter(MB_ItemListStateContext context)
        {
            Debug.Log($"Entering {category} State");
            context.UpdateItemList(category);
        }

        public override void UpdateExecute(MB_ItemListStateContext context)
        {
            // Base update logic if needed
        }

        public override void Exit(MB_ItemListStateContext context)
        {
            Debug.Log($"Exiting {category} State");
        }
    }
}
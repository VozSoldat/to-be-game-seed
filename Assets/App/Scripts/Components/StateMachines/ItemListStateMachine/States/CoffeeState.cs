using StateMachines;
using UnityEngine;
using UnityEngine.UI;

namespace StateMachines.ItemListStateMachine
{
    public class CoffeeState : ItemListState
    {
        public CoffeeState() : base(ItemCategory.Coffee) { }

        // Temporary save normal sprite for the button place
        public override void Enter(MB_ItemListStateContext context)
        {
            base.Enter(context);
            SetButtonState(context, context.coffeeButtonPlace, true);

        }
        public override void Exit(MB_ItemListStateContext context)
        {
            base.Exit(context);
            SetButtonState(context, context.coffeeButtonPlace, false);
        }
    }
}
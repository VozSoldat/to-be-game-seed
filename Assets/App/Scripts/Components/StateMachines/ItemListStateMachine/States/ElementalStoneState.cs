using StateMachines;

namespace StateMachines.ItemListStateMachine
{
    public class ElementalStoneState : ItemListState
    {
        public ElementalStoneState() : base(ItemCategory.ElementalStone) { }

        public override void Enter(MB_ItemListStateContext context)
        {
            base.Enter(context);
            SetButtonState(context, context.elementalStoneButtonPlace, true);
        }
        public override void Exit(MB_ItemListStateContext context)
        {
            base.Exit(context);
            SetButtonState(context, context.elementalStoneButtonPlace, false);
        }
    }
}
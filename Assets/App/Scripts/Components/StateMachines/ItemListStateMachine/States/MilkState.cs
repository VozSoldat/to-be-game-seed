using StateMachines;

namespace StateMachines.ItemListStateMachine
{
    public class MilkState : ItemListState
    {
        public MilkState() : base(ItemCategory.Milk) { }

        public override void Enter(MB_ItemListStateContext context)
        {
            base.Enter(context);
            SetButtonState(context, context.milkButtonPlace, true);
        }
        public override void Exit(MB_ItemListStateContext context)
        {
            base.Exit(context);
            SetButtonState(context, context.milkButtonPlace, false);
        }
    }
}
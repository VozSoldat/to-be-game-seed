using StateMachines;

namespace StateMachines.ItemListStateMachine
{
    public class MagicItemState : ItemListState
    {
        public MagicItemState() : base(ItemCategory.MagicItem) { }

        public override void Enter(MB_ItemListStateContext context)
        {
            base.Enter(context);
            SetButtonState(context, context.magicItemButtonPlace, true);
        }
        public override void Exit(MB_ItemListStateContext context)
        {
            base.Exit(context);
            SetButtonState(context, context.magicItemButtonPlace, false);
        }
    }
}
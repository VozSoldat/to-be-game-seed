using UnityEngine;

namespace StateMachines
{
    public abstract class AbstractState<Context>
    {
        public virtual string Name => GetType().Name;
        public abstract void Enter(Context context);
        public abstract void UpdateExecute(Context context);
        public abstract void Exit(Context context);

        public virtual void FixedUpdateExecute(Context context) { }
    }
}
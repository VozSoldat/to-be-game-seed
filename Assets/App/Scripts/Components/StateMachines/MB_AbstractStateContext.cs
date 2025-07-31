using UnityEngine;
using System;
using System.Collections.Generic;

namespace StateMachines
{
    public abstract class MB_AbstractStateContext<StateEnum, TContext>
        : MonoBehaviour
            where StateEnum : Enum
            where TContext : MB_AbstractStateContext<StateEnum, TContext>
    {
        public abstract Dictionary<StateEnum, AbstractState<TContext>> StateMap { get; }
        protected AbstractState<TContext> currentState;
        protected StateEnum currentEnum;
        public virtual void TransitionToState(StateEnum newState)
        {
            if (StateMap.TryGetValue(newState, out var newStateInstance))
            {
                currentState?.Exit((TContext)this);
                currentState = newStateInstance;
                currentEnum = newState;
                currentState.Enter((TContext)this);
            }
            else
            {
                Debug.LogError($"State {newState} not found in StateMap.");
            }
        }
        protected virtual void Update()
        {
            currentState?.UpdateExecute((TContext)this);
        }

        protected virtual void FixedUpdate()
        {
            currentState?.FixedUpdateExecute((TContext)this);
        }
    }
}
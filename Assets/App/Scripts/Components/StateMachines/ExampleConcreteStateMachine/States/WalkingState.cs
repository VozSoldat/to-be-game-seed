using StateMachines;
using UnityEngine;

namespace StateMachines.ExampleConcreteStateMachine
{

    public class WalkingState : AbstractState<MB_ExampleConcreteStateContext>
    {
        public override void Enter(MB_ExampleConcreteStateContext context)
        {
            // Logic for entering the Walking state
            Debug.Log("Entering Walking State");
        }

        public override void UpdateExecute(MB_ExampleConcreteStateContext context)
        {
            // Logic for updating in the Walking state
            Debug.Log("Updating Walking State");
        }

        public override void Exit(MB_ExampleConcreteStateContext context)
        {
            // Logic for exiting the Walking state
            Debug.Log("Exiting Walking State");
        }
    }
}
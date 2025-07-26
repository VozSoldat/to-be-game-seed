using StateMachines;
using UnityEngine;

namespace StateMachines.ExampleConcreteStateMachine
{


    public class IdleState : AbstractState<MB_ExampleConcreteStateContext>
    {
        public override void Enter(MB_ExampleConcreteStateContext context)
        {
            // Logic for entering the Idle state
            Debug.Log("Entering Idle State");
        }

        public override void UpdateExecute(MB_ExampleConcreteStateContext context)
        {
            // Logic for updating in the Idle state
            Debug.Log("Updating Idle State");
        }

        public override void Exit(MB_ExampleConcreteStateContext context)
        {
            // Logic for exiting the Idle state
            Debug.Log("Exiting Idle State");
        }
    }
}
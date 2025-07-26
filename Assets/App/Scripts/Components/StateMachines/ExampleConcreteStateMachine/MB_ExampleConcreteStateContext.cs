using System.Collections.Generic;
using StateMachines;

namespace StateMachines.ExampleConcreteStateMachine
{

    public class MB_ExampleConcreteStateContext : MB_AbstractStateContext<ExampleStateEnum, MB_ExampleConcreteStateContext>
    {
        private Dictionary<ExampleStateEnum, AbstractState<MB_ExampleConcreteStateContext>> _stateMap;
        public override Dictionary<ExampleStateEnum, AbstractState<MB_ExampleConcreteStateContext>> StateMap => _stateMap;
        void Start()
        {
            _stateMap = new Dictionary<ExampleStateEnum, AbstractState<MB_ExampleConcreteStateContext>>
            {
                { ExampleStateEnum.Idle, new IdleState() },
                { ExampleStateEnum.Walking, new WalkingState() },
            };
        }
    }
}

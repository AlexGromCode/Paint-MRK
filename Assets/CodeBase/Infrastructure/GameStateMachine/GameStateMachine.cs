using System.Collections.Generic;
using Zenject;
using System;

namespace CodeBase.Infrastructure
{
    public class GameStateMachine : IGameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;

        #region Dependencies 

        private IExitableState _activeState;

        #endregion
        
        [Inject]
        public GameStateMachine(IGameStateFactory gameStateFactory)
        {
            _states = new Dictionary<Type, IExitableState>()
            {
                [typeof(BootstrapState)] = gameStateFactory.CreateGameState<BootstrapState>(this),
                [typeof(LoadLevelState)] = gameStateFactory.CreateGameState<LoadLevelState>(this),
                [typeof(MainMenuState)] = gameStateFactory.CreateGameState<MainMenuState>(this),
                [typeof(GameLoopState)] = gameStateFactory.CreateGameState<GameLoopState>(this),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payload) where TState : class, IPayloadedState<TPayload>
        {
            IPayloadedState<TPayload> payloadedState = ChangeState<TState>();
            payloadedState.Enter(payload);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;

            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}
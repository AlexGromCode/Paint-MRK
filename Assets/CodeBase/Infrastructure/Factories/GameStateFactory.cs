using System.Collections.Generic;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameStateFactory : IGameStateFactory
    {
        #region Dependencies

        private readonly DiContainer _diContainer;

        #endregion
        
        private List<object> _references;

        [Inject]
        public GameStateFactory(DiContainer diContainer) =>
            _diContainer = diContainer;

        public TState CreateGameState<TState>(GameStateMachine gameStateMachine) 
            where TState : class, IExitableState
        {
            _references = new List<object>() { gameStateMachine };
            IEnumerable<object> extraArgs = _references;
            return _diContainer.Instantiate<TState>(extraArgs);
        }
    }
}
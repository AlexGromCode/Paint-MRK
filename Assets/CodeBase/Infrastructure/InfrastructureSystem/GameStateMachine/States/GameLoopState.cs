namespace CodeBase.Infrastructure
{
    public class GameLoopState : IState
    {
        #region Dependencies 
        
        private readonly GameStateMachine _gameStateMachine;

        #endregion
        
        public GameLoopState(GameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}
namespace CodeBase.Infrastructure
{
    public class MainMenuState : IState
    {
        #region Dependencies 
        
        private readonly GameStateMachine _gameStateMachine;

        #endregion
        
        public MainMenuState(GameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        public void Enter()
        {
        }

        public void Exit()
        {
        }
    }
}
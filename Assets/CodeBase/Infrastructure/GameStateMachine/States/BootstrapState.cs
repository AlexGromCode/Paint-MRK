namespace CodeBase.Infrastructure
{
    public class BootstrapState : IState
    {
        #region Dependencies 
        
        private readonly GameStateMachine _gameStateMachine;
        private readonly ISceneNameService _sceneNameService;
        private readonly ISceneLoadService _sceneLoadService;
        private readonly GameConfigSo _gameConfig;
        
        #endregion

        public BootstrapState(
            ISceneLoadService sceneLoadService,
            ISceneNameService sceneNameService,
            GameStateMachine gameStateMachine,
            GameConfigSo gameConfig)
        {
            _gameStateMachine = gameStateMachine;
            _sceneNameService = sceneNameService;
            _sceneLoadService = sceneLoadService;
            _gameConfig = gameConfig;
        }

        public void Enter()
        {
            string initialSceneName = _sceneNameService.GetSceneName(_gameConfig.FirstSceneName);
            _sceneLoadService.Load(initialSceneName, onLoaded: EnterLoadProgressState);
        }

        public void Exit()
        {
        }

        private void EnterLoadProgressState()
        {
            string firstSceneName = _sceneNameService.GetSceneName(_gameConfig.InitialGameScene);
            _gameStateMachine.Enter<LoadLevelState, string>(firstSceneName);
        }
    }
}
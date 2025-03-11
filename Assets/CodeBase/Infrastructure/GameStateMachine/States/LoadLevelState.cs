namespace CodeBase.Infrastructure
{
    public class LoadLevelState : IPayloadedState<string>
    {
        #region Dependencies 
        
        private readonly ILoadingCurtainService _loadingCurtainService;
        private readonly ISceneLoadService _sceneLoadService;
        private readonly GameStateMachine _gameStateMachine;
        
        #endregion

        #region Filds
        
        private string _loadingScene;

        #endregion
        
        public LoadLevelState(
            ILoadingCurtainService loadingCurtainService,
            ISceneLoadService sceneLoadService,
            GameStateMachine gameStateMachine)
        {
            _loadingCurtainService = loadingCurtainService;
            _gameStateMachine = gameStateMachine;
            _sceneLoadService = sceneLoadService;
        }

        public void Enter(string sceneName)
        {
            _loadingScene = sceneName;
            _loadingCurtainService.ShowLoadingCurtain(sceneName, OnShowed);
        }

        public void Exit() => _loadingCurtainService.HideLoadingCurtain();

        private void OnLoaded()
        {
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void OnShowed() => _sceneLoadService.Load(_loadingScene, OnLoaded);
    }
}
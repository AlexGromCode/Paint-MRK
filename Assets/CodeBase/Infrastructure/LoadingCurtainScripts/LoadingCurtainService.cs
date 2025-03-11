using System.Collections.Generic;
using Zenject;
using System;

namespace CodeBase.Infrastructure
{
    public class LoadingCurtainService : ILoadingCurtainService
    {
        public event EventHandler LoadingCurtainHideComplete;
        
        #region Dependencies 
        
        private Dictionary<SceneName, ILoadingCurtain> _loadingCurtains;
        private readonly ISceneNameService _sceneNameService;
        
        private ILoadingCurtain _lastLoadedCurtain;
        private LoadingCurtain _loadingCurtain;
        
        #endregion
        
        [Inject]
        public LoadingCurtainService(
            ISceneNameService sceneNameService,
            IGameFactory gameFactory)
        {
            _loadingCurtain = gameFactory.CreateLoadingCurtain();

            _loadingCurtain.gameObject.SetActive(false);
            _sceneNameService = sceneNameService;

            _loadingCurtains = new()
            {
                [SceneName.GameplayScene] = _loadingCurtain,
            };
        }

        public void ShowLoadingCurtain(string sceneName, Action onShowed = null)
        {
            SceneName sceneNameEnum = _sceneNameService.GetSceneName(sceneName);

            var currentLoadingCurtain = _loadingCurtains.TryGetValue(sceneNameEnum, out var curtain) ? curtain : _loadingCurtain;
            
            _lastLoadedCurtain?.Hide(OnHideComplete);
            _lastLoadedCurtain = currentLoadingCurtain;
            currentLoadingCurtain.Show(onShowed);
        }

        public void HideLoadingCurtain() =>
            _lastLoadedCurtain?.Hide(OnHideComplete);

        private void OnHideComplete() =>
            LoadingCurtainHideComplete?.Invoke(this, EventArgs.Empty);
    }
}
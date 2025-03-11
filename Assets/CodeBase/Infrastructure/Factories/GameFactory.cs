using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameFactory : IGameFactory
    {
        #region Constants
        
        private const string CoroutineRunnerPath = "CoroutineRunner";
        private const string LoadingCurtainPath = "LoadingCurtain";
        private const string BootstrapperPath = "Bootstrapper";
        
        #endregion

        #region Dependencies 

        private readonly IResourcesService _resourcesService;
        private readonly DiContainer _container;
        
        #endregion

        [Inject]
        public GameFactory(
            IResourcesService resourcesService,
            DiContainer diContainer)
        {
            _resourcesService = resourcesService;
            _container = diContainer;
        }

        public ICoroutineRunner CreateCoroutineRunner() => 
            InstantiatePrefab<ICoroutineRunner>(CoroutineRunnerPath);
        
        public LoadingCurtain CreateLoadingCurtain() =>
            InstantiatePrefab<LoadingCurtain>(LoadingCurtainPath);
        
        public Bootstrapper CreateBootstrapper() =>
            InstantiatePrefab<Bootstrapper>(BootstrapperPath);
        
        private TComponent InstantiatePrefab<TComponent>(string path)
        {
            UnityEngine.Object prefab = _resourcesService.GetPrefab(path);
            return _container.InstantiatePrefabForComponent<TComponent>(prefab);
        }
    }
}
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class AppInstaller : MonoInstaller
    {
        #region SerializeFields

        [SerializeField] private GameConfigSo _gameConfigSo;

        #endregion
        
        public override void InstallBindings()
        {
            InstallFactoriesBindings();
            InstallGameStateMachineBindings();
            InstallConfigBindings();
            InstallSceneLoadBindings();
        }

        private void InstallFactoriesBindings()
        {
            Container.Bind<IGameFactory>()
                .To<GameFactory>()
                .AsSingle();

            Container.Bind<IResourcesService>()
                .To<ResourcesService>()
                .AsSingle();

            Container.Bind<IGameStateFactory>()
                .To<GameStateFactory>()
                .AsSingle();
        }

        private void InstallGameStateMachineBindings()
        {
            Container.Bind<IGameStateMachine>()
                .To<GameStateMachine>()
                .AsSingle();
        }

        private void InstallConfigBindings()
        {
            Container.Bind<GameConfigSo>()
                .FromInstance(_gameConfigSo)
                .AsSingle();
        }

        private void InstallSceneLoadBindings()
        {
            Container.Bind<ISceneNameService>()
                .To<SceneNameService>()
                .AsSingle();

            Container.Bind<ISceneLoadService>()
                .To<SceneLoadService>()
                .AsSingle();

            Container.Bind<ILoadingCurtainService>()
                .To<LoadingCurtainService>()
                .AsSingle();

            Container.Bind<ICoroutineRunner>()
                .To<CoroutineRunner>()
                .FromNewComponentOnNewGameObject()
                .WithGameObjectName("CoroutineRunner")
                .AsSingle()
                .NonLazy();
        }
    }
}
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameplayFactory : IGameplayFactory
    {
        #region Dependencies

        private readonly IResourcesService _resourcesService;
        private readonly Transform _characterSpawnPoint;
        private readonly Transform _enemySpawnPoint;
        private readonly DiContainer _container;

        #endregion

        [Inject]
        public GameplayFactory(
            IResourcesService resourcesService,
            DiContainer container)
        {
            _resourcesService = resourcesService;
            _container = container;
        }
    }
}
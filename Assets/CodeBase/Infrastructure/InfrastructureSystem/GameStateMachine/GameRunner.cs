using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        #region Dependencies 

        private IGameFactory _gameFactory;

        #endregion

        [Inject]
        public void Construct(IGameFactory gameFactory) => _gameFactory = gameFactory;

        private void Awake()
        {
            var bootstrapper = FindObjectOfType<Bootstrapper>();

            if (bootstrapper == null)
                _gameFactory.CreateBootstrapper();
        }
    }
}
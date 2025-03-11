using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        private IGameplayFactory _gameplayFactory;
        
        [Inject]
        public void Construct(IGameplayFactory gameplayFactory) =>
            _gameplayFactory = gameplayFactory;

        private void Start()
        {
          
        }
    }
}
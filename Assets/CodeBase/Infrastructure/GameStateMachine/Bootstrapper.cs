using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        #region Dependencies 
        
        private IGameStateMachine _gameStateMachine;
        
        #endregion

        [Inject]
        public void Construct(IGameStateMachine gameStateMachine) =>
            _gameStateMachine = gameStateMachine;

        private void Start() => _gameStateMachine.Enter<BootstrapState>();
    }
}
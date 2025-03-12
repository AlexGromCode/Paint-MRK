using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using Zenject;
using System;

namespace CodeBase.Infrastructure
{
    public class SceneLoadService : ISceneLoadService
    {
        public event EventHandler SceneChanged;

        #region Dependencies

        private readonly ICoroutineRunner _coroutineRunner;

        #endregion
        
        [Inject]
        public SceneLoadService(IGameFactory gameFactory) => 
            _coroutineRunner = gameFactory.CreateCoroutineRunner();

        public void Load(string name, Action onLoaded = null) =>
            _coroutineRunner.StartCoroutine(LoadScene(name, onLoaded));

        private IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            string activeSceneName = SceneManager.GetActiveScene().name;
            
            if (activeSceneName == name)
            {
                onLoaded?.Invoke();
                yield break;
            }

            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync(name);

            while (waitNextScene is { isDone: false })
                yield return null;
            
            OnSceneChanged();
            onLoaded?.Invoke();
        }

        private void OnSceneChanged() => 
            SceneChanged?.Invoke(this, EventArgs.Empty);
    }
}
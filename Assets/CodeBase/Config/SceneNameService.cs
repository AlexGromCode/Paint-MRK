using System.Collections.Generic;
using System.Linq;

namespace CodeBase.Infrastructure
{
    public class SceneNameService : ISceneNameService
    {
        #region Constants
        
        private const string GameplaySceneConst = "GameplayScene";
        private const string MainMenuSceneConst = "MainMenuScene";
        private const string InitialSceneConst = "InitialScene";
        
        #endregion

        private readonly Dictionary<SceneName, string> _sceneNames = new()
        {
            [SceneName.MainMenuScene] = MainMenuSceneConst,
            [SceneName.InitialScene] = InitialSceneConst,
            [SceneName.GameplayScene] = GameplaySceneConst
        };

        public string GetSceneName(SceneName sceneName) => 
            _sceneNames[sceneName];

        public SceneName GetSceneName(string sceneName) =>
            _sceneNames.FirstOrDefault(scene => scene.Value == sceneName).Key;
    }
}
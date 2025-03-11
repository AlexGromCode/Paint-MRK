namespace CodeBase.Infrastructure
{
    public interface ISceneNameService
    {
        public string GetSceneName(SceneName sceneName);
        public SceneName GetSceneName(string sceneName);
    }
}
namespace CodeBase.Infrastructure
{
    public interface IGameFactory
    {
        public Bootstrapper CreateBootstrapper();
        
        public ICoroutineRunner CreateCoroutineRunner();
        
        public LoadingCurtain CreateLoadingCurtain();
    }
}
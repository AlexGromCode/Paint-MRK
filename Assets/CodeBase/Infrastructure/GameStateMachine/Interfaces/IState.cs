namespace CodeBase.Infrastructure
{
    public interface IState : IExitableState
    {
        public void Enter();
    }
}
namespace CodeBase.Infrastructure
{
    public interface IGameStateFactory
    {
        public TState CreateGameState<TState>(GameStateMachine gameStateMachine) 
            where TState : class, IExitableState;
    }
}
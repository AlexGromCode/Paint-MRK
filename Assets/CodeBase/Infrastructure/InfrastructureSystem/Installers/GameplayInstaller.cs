using Zenject;

namespace CodeBase.Infrastructure
{
    public class GameplayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallFactories();
        }

        private void InstallFactories()
        {
            Container.BindInterfacesTo<GameplayFactory>()
                .AsSingle();
        }
    }
}


using ToolsSorter.Service.HoldService;
using ToolsSorter.Service.ThrowService;
using Zenject;

namespace ToolsSorter.Infrastructure
{
    internal class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IContainer>().FromComponentsInHierarchy().AsCached();
            Container.Bind<Holder>().FromComponentsInHierarchy().AsCached();
            Container.Bind<Thrower>().FromComponentsInHierarchy().AsCached();
        }
    }
}

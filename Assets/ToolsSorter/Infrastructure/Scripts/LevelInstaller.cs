using ToolsSorter.Service;
using ToolsSorter.Service.CollideService;
using ToolsSorter.Service.HoldService;
using ToolsSorter.Service.ThrowService;
using ToolsSorter.UI;
using Zenject;

namespace ToolsSorter.Infrastructure
{
    internal class LevelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
           // Container.Bind<Item>().From().AsSingle();
            Container.Bind<IContainer>().FromComponentsInHierarchy().AsCached();
            Container.Bind<Holder>().FromComponentsInHierarchy().AsCached();
            Container.Bind<Thrower>().FromComponentsInHierarchy().AsCached();
            Container.Bind<CollideController>().FromNew().AsSingle();
            Container.Bind<WinWindow>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<LoseWindow>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<ICircle>().FromComponentsInHierarchy().AsSingle();
            Container.Bind<Level>().FromNew().AsSingle();
        }
    }
}

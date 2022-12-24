using Factories.EnemyFactory;
using Factories.EnemyFactory.Impl;
using Services.EnemyStorage;
using Services.EnemyStorage.Impl;
using Services.Spawner;
using VContainer;
using VContainer.Extensions;
using VContainer.Unity;

namespace Scope
{
	public class GameInstaller : MonoInstaller
	{
		public override void Install(IContainerBuilder builder)
		{
			builder.RegisterEntryPoint<EnemySpawner>();
			builder.Register<EnemyFactory>(Lifetime.Singleton).As<IEnemyFactory>();
			builder.Register<EnemyStorage>(Lifetime.Singleton).As<IEnemyStorage>();
		}
	}
}
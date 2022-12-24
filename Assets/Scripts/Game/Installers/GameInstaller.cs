using Game.Factories.EnemyFactory;
using Game.Factories.EnemyFactory.Impl;
using Game.Factories.PlayerFactory;
using Game.Factories.PlayerFactory.Impl;
using Game.Factories.ViewFactory;
using Game.Factories.ViewFactory.Impl;
using Game.Services;
using Game.Services.EnemyStorage;
using Game.Services.EnemyStorage.Impl;
using Game.Services.Initialize;
using Game.Services.PlayerStorage;
using Game.Services.PlayerStorage.Impl;
using Game.Services.Spawner;
using VContainer;
using VContainer.Extensions;
using VContainer.Unity;

namespace Game.Installers
{
	public class GameInstaller : MonoInstaller
	{
		public override void Install(IContainerBuilder builder)
		{
			builder.Register<EnemyFactory>(Lifetime.Singleton).As<IEnemyFactory>();
			builder.Register<PlayerFactory>(Lifetime.Singleton).As<IPlayerFactory>();
			builder.Register<ViewFactory>(Lifetime.Singleton).As<IViewFactory>();
			builder.Register<PlayerStorage>(Lifetime.Singleton).As<IPlayerStorage>();
			builder.Register<EnemyStorage>(Lifetime.Singleton).As<IEnemyStorage>();
			
			
			builder.RegisterEntryPoint<EnemySpawner>();
			builder.RegisterEntryPoint<PlayerInitialize>();
			builder.RegisterEntryPoint<StateMachineUpdateService>();
		}
	}
}
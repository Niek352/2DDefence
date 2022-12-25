using Game.Factories.BulletFactory;
using Game.Factories.BulletFactory.Impl;
using Game.Factories.EnemyFactory;
using Game.Factories.EnemyFactory.Impl;
using Game.Factories.PlayerFactory;
using Game.Factories.PlayerFactory.Impl;
using Game.Factories.ViewFactory;
using Game.Factories.ViewFactory.Impl;
using Game.Services;
using Game.Services.Bullet;
using Game.Services.Bullet.Impl;
using Game.Services.CleanUp.Impl;
using Game.Services.EnemySpawnPointCalculator;
using Game.Services.EnemySpawnPointCalculator.Impl;
using Game.Services.EnemyStorage;
using Game.Services.EnemyStorage.Impl;
using Game.Services.Initialize;
using Game.Services.PlayerStorage;
using Game.Services.PlayerStorage.Impl;
using Game.Services.Spawner;
using UnityEngine;
using VContainer;
using VContainer.Extensions;
using VContainer.Unity;

namespace Game.Installers
{
	public class GameInstaller : MonoInstaller
	{
		[SerializeField] private Camera _camera;
		
		public override void Install(IContainerBuilder builder)
		{
			builder.RegisterInstance(_camera);
			
			builder.Register<EnemyFactory>(Lifetime.Singleton).As<IEnemyFactory>();
			builder.Register<PlayerFactory>(Lifetime.Singleton).As<IPlayerFactory>();
			builder.Register<ViewFactory>(Lifetime.Singleton).As<IViewFactory>();
			builder.Register<PlayerStorage>(Lifetime.Singleton).As<IPlayerStorage>();
			builder.Register<EnemyStorage>(Lifetime.Singleton).As<IEnemyStorage>();
			builder.Register<BulletFactory>(Lifetime.Singleton).As<IBulletFactory>();
			builder.Register<EnemySpawnPointCalculateService>(Lifetime.Singleton).As<IEnemySpawnPointCalculateService>();
			
			
			builder.RegisterEntryPoint<EnemySpawner>();
			builder.RegisterEntryPoint<EnemyCleanUp>().As<IEnemyCleanUp>();
			builder.RegisterEntryPoint<BulletService>().As<IBulletService>();
			builder.RegisterEntryPoint<PlayerControllerUpdateService>();
			builder.RegisterEntryPoint<PlayerInitialize>();
			builder.RegisterEntryPoint<StateMachineUpdateService>();
		}
	}
}
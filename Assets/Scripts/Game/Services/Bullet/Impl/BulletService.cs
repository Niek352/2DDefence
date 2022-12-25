using System;
using System.Collections.Generic;
using System.Linq;
using Db.BulletData;
using Game.EntityContext;
using Game.Factories.BulletFactory;
using Game.Model;
using Game.Services.EnemyStorage;
using Game.Services.PlayerStorage;
using UnityEngine;
using UnityEngine.Pool;
using VContainer.Unity;
using Object = UnityEngine.Object;

namespace Game.Services.Bullet.Impl
{
	public class BulletService : IBulletService, ITickable, IPostTickable
	{
		private readonly IBulletFactory _bulletFactory;
		private readonly IPlayerStorage _playerStorage;
		private readonly IEnemyStorage _enemyStorage;
		private readonly Dictionary<string, BulletModel> _bulletModels;
		private readonly HashSet<BulletController> _bulletControllers = new HashSet<BulletController>();
		private readonly Stack<BulletController> _destroyedBullets = new Stack<BulletController>();
		
		public BulletService(
			IBulletFactory bulletFactory,
			IPlayerStorage playerStorage,
			IEnemyStorage enemyStorage,
			IBulletData bulletData)
		{
			_bulletFactory = bulletFactory;
			_playerStorage = playerStorage;
			_enemyStorage = enemyStorage;
			_bulletModels = bulletData.BulletModels.ToDictionary(model => model.Id);
		}
		
		public void CreateBullet(string id, BulletTarget bulletTarget, Vector3 position, Vector3 velocity)
		{
			var bulletModel = _bulletModels[id];
			var bulletController = _bulletFactory.CreateBullet(bulletModel, bulletModel.View, bulletTarget, position, velocity);
			_bulletControllers.Add(bulletController);
		}
		
		public void Tick()
		{
			foreach (var bulletController in _bulletControllers)
			{
				bulletController.Position += bulletController.Velocity * Time.deltaTime;
				bulletController.View.transform.position = bulletController.Position;
				bulletController.LifeTime -= Time.deltaTime;
				if (bulletController.LifeTime <= 0)
				{
					_destroyedBullets.Push(bulletController);
					continue;
				}
				
				var entityContexts = ListPool<IEntityContext>.Get();
				CollectTargets(bulletController, ref entityContexts);
				
				foreach (var context in entityContexts)
				{
					var sqrMagnitude = (bulletController.Position - context.Transform.position).sqrMagnitude;
					
					if (sqrMagnitude * sqrMagnitude <= 1f)
					{
						context.Health.DecreaseHealth(bulletController.Damage);
						_destroyedBullets.Push(bulletController);
						break;
					}
				}
				
				
				
				ListPool<IEntityContext>.Release(entityContexts);
			}
		}

		public void PostTick()
		{
			while (_destroyedBullets.Count != 0)
			{
				var bulletController = _destroyedBullets.Pop();
				//TODO: Pool
				Object.Destroy(bulletController.View.gameObject);
				_bulletControllers.Remove(bulletController);
			}
		}
		
		public void CollectTargets(BulletController bulletController, ref List<IEntityContext> entityContexts)
		{
			switch (bulletController.BulletTarget)
			{
				case BulletTarget.Player:
					entityContexts.Add(_playerStorage.Player);
					break;
				case BulletTarget.Enemy:
					entityContexts.AddRange(_enemyStorage.Enemies);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
		
	}

}
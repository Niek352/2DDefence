using System;
using Db.EnemyData;
using Game.Enemy;
using Game.Enemy.Attack.Abstract;
using Game.Enemy.Attack.Impl;
using Game.Enemy.Movement.Abstract;
using Game.Enemy.Movement.Impl;
using Game.Enemy.StateMachine;
using Game.Factories.ViewFactory;
using Game.Health.Impl;
using Game.Model;
using Game.Player;
using Game.Services.Bullet;
using Game.Services.PlayerStorage;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Factories.EnemyFactory.Impl
{
	public class EnemyFactory : IEnemyFactory
	{
		private readonly IEnemyData _enemyData;
		private readonly IPlayerStorage _playerStorage;
		private readonly IViewFactory _viewFactory;
		private readonly IBulletService _bulletService;

		public EnemyFactory(
			IEnemyData enemyData, 
			IPlayerStorage playerStorage, 
			IViewFactory viewFactory, 
			IBulletService bulletService)
		{
			_enemyData = enemyData;
			_playerStorage = playerStorage;
			_viewFactory = viewFactory;
			_bulletService = bulletService;
		}
		
		public EnemyContext Create(EnemyModel model, Vector3 position, Quaternion rotation)
		{
			var enemy = Object.Instantiate(_enemyData.EnemyPrefab, position, rotation);
			_viewFactory.CreateView(model.EntityViewPrefab.name, enemy.transform);
			
			var attack = CreateAttack(model.EnemyAttackType, model.Damage, _playerStorage.Player, enemy);
			var movement = CreateMovement(model, enemy, _playerStorage.Player);
			
			var health = new BaseHealth(model.Health);
			var stateMachine = new EnemyStateMachine(enemy, attack, movement);
			
			enemy.Init(stateMachine, health, model);

			return enemy;
		}

		private AbstractAttack CreateAttack(EnemyAttackType attackType, float damage, PlayerContext player, EnemyContext owner) => attackType switch
		{
			EnemyAttackType.Melee => new MeleeAttack(damage, player),
			EnemyAttackType.Range => new RangeAttack(_bulletService, owner, damage),
			_ => throw new ArgumentOutOfRangeException(nameof(attackType), attackType, null)
		};

		private static AbstractMovement CreateMovement(EnemyModel enemyModel, EnemyContext enemyContext, PlayerContext player) => enemyModel.EnemyMovementType switch
		{
			EnemyMovementType.SimpleMovement => new SimpleMovement(enemyContext, player, enemyModel.AttackRange, enemyModel.MovementSpeed),
			_ => throw new ArgumentOutOfRangeException(nameof(enemyModel.EnemyMovementType), enemyModel.EnemyMovementType, null)
		};
	}
}
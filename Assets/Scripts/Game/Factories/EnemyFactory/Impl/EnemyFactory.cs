using System;
using Db.EnemyData;
using Game.Enemy;
using Game.Enemy.Attack.Abstract;
using Game.Enemy.Attack.Impl;
using Game.Enemy.Movement.Abstract;
using Game.Enemy.Movement.Impl;
using Game.Enemy.StateMachine;
using Game.Health.Impl;
using Game.Model;
using Game.Player;
using Game.Services.PlayerStorage;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Factories.EnemyFactory.Impl
{
	public class EnemyFactory : IEnemyFactory
	{
		private readonly IEnemyData _enemyData;
		private readonly IPlayerStorage _playerStorage;

		public EnemyFactory(IEnemyData enemyData, IPlayerStorage playerStorage)
		{
			_enemyData = enemyData;
			_playerStorage = playerStorage;
		}
		
		public EnemyContext Create(EnemyModel model, Vector3 position, Quaternion rotation)
		{
			var enemy = Object.Instantiate(_enemyData.EnemyPrefab, position, rotation);
			var attack = CreateAttack(model.EnemyAttackType, model.Damage, _playerStorage.Player);
			var movement = CreateMovement(model.EnemyMovementType, enemy, _playerStorage.Player);
			
			var health = new BaseHealth(model.Health);
			var stateMachine = new EnemyStateMachine(enemy, attack, movement);
			
			enemy.Init(stateMachine, health);

			return enemy;
		}

		private static AbstractAttack CreateAttack(EnemyAttackType attackType, float damage, PlayerContext player) => attackType switch
		{
			EnemyAttackType.Melee => new MeleeAttack(damage, player),
			_ => throw new ArgumentOutOfRangeException(nameof(attackType), attackType, null)
		};

		private static AbstractMovement CreateMovement(EnemyMovementType movementType, EnemyContext enemyContext, PlayerContext player) => movementType switch
		{
			EnemyMovementType.SimpleMovement => new SimpleMovement(enemyContext, player),
			_ => throw new ArgumentOutOfRangeException(nameof(movementType), movementType, null)
		};
	}
}
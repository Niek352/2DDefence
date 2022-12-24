using System;
using Db.EnemyData;
using Enemy;
using Enemy.Attack.Abstract;
using Enemy.Attack.Impl;
using Enemy.Movement.Abstract;
using Enemy.Movement.Impl;
using Model;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Factories.EnemyFactory.Impl
{
	public class EnemyFactory : IEnemyFactory
	{
		private readonly IEnemyData _enemyData;
		
		public EnemyFactory(IEnemyData enemyData)
		{
			_enemyData = enemyData;
		}
		
		public EnemyContext Create(EnemyModel model, Vector3 position, Quaternion rotation)
		{
			var enemy = Object.Instantiate(_enemyData.EnemyPrefab, position, rotation);

			enemy.Init(
				CreateAttack(model.EnemyAttackType),
				CreateMovement(model.EnemyMovementType), 
				model);

			return enemy;
		}

		private static AbstractAttack CreateAttack(EnemyAttackType attackType) => attackType switch
		{
			EnemyAttackType.Melee => new MeleeAttack(),
			_ => throw new ArgumentOutOfRangeException(nameof(attackType), attackType, null)
		};

		private static AbstractMovement CreateMovement(EnemyMovementType movementType) => movementType switch
		{
			EnemyMovementType.SimpleMovement => new SimpleMovement(),
			_ => throw new ArgumentOutOfRangeException(nameof(movementType), movementType, null)
		};
	}
}
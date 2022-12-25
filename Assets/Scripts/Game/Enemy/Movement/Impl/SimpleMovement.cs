using Db.EnemyData;
using Game.Enemy.Movement.Abstract;
using UnityEngine;

namespace Game.Enemy.Movement.Impl
{
	public class SimpleMovement : AbstractMovement
	{
		private readonly float _attackRange;
		private readonly float _movementSpeed;
		private readonly Transform _cashedOwnerTransform;
		private readonly Transform _cashedPlayerTransform;
		
		public override EnemyMovementType EnemyMovementType => EnemyMovementType.SimpleMovement;
		public override Vector3 TargetPosition => _cashedPlayerTransform.position;
		public override bool ReachedTarget => Vector3.Distance(_cashedOwnerTransform.position, TargetPosition) < _attackRange;

		public SimpleMovement(Component enemyContext, Component playerContext, float attackRange, float movementSpeed)
		{
			_attackRange = attackRange;
			_movementSpeed = movementSpeed;
			_cashedOwnerTransform = enemyContext.transform;
			_cashedPlayerTransform = playerContext.transform;
		}

		public override void Move(float deltaTime)
		{
			var dir = TargetPosition - _cashedOwnerTransform.position;
			_cashedOwnerTransform.position = Vector3.MoveTowards(_cashedOwnerTransform.position, TargetPosition, deltaTime * _movementSpeed);
			_cashedOwnerTransform.rotation = Quaternion.Euler(0,0,Mathf.Atan2(dir.normalized.y, dir.normalized.x) * Mathf.Rad2Deg - 90f);
		}
	}
}
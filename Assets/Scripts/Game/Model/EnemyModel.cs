using System;
using Db.EnemyData;
using Game.View.Impl;

namespace Game.Model
{
	[Serializable]
	public class EnemyModel : AbstractModel
	{
		public float Damage;
		public float Health;
		public float AttackRange;
		public float MovementSpeed;
		public EnemyAttackType EnemyAttackType;
		public EnemyMovementType EnemyMovementType;
		public EntityView EntityViewPrefab;
	}
}
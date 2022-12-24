using System;
using Db.EnemyData;
using Game.Enemy;

namespace Game.Model
{
	[Serializable]
	public class EnemyModel : AbstractModel
	{
		public float Damage;
		public float Health;
		public EnemyAttackType EnemyAttackType;
		public EnemyMovementType EnemyMovementType;
	}
		
	public abstract class AbstractModel
	{
		public string Id;
	}
}
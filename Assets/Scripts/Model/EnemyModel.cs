using System;
using Db.EnemyData;

namespace Model
{
	[Serializable]
	public class EnemyModel : AbstractModel
	{
		public int Damage;
		public int Health;
		public EnemyAttackType EnemyAttackType;
		public EnemyMovementType EnemyMovementType;
	}
		
	public abstract class AbstractModel
	{
		public string Id;
	}
}
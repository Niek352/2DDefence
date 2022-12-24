using Db.EnemyData;

namespace Game.Enemy.Attack.Abstract
{
	public abstract class AbstractAttack
	{
		public abstract EnemyAttackType EnemyAttackType { get; }
		public abstract bool InCoolDown { get; }
		public abstract float CurrentCoolDown { get; set; }
		public abstract void Attack();
	}
}
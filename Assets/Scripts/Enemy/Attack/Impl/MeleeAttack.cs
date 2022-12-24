using Db.EnemyData;
using Enemy.Attack.Abstract;

namespace Enemy.Attack.Impl
{
	public class MeleeAttack : AbstractAttack
	{
		public override EnemyAttackType EnemyAttackType => EnemyAttackType.Melee;
	}
}
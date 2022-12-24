using Db.EnemyData;
using Game.Enemy.Attack.Abstract;
using Game.EntityContext;

namespace Game.Enemy.Attack.Impl
{
	public class MeleeAttack : AbstractAttack
	{
		public override EnemyAttackType EnemyAttackType => EnemyAttackType.Melee;
		private readonly IEntityContext _playerContext;
		private readonly float _damage;
		public static float Cooldown => 1f;
		public override float CurrentCoolDown { get; set; } = Cooldown;

		public override bool InCoolDown => CurrentCoolDown <= Cooldown;

		public MeleeAttack(float damage, IEntityContext playerContext)
		{
			_damage = damage;
			_playerContext = playerContext;
		}
		
		public override void Attack()
		{
			_playerContext.Health.DecreaseHealth(_damage);
		}
	}
}
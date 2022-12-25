using Db.EnemyData;
using Game.Enemy.Attack.Abstract;
using Game.EntityContext;
using Game.Services.Bullet;
using Game.Services.Bullet.Impl;
using UnityEngine;

namespace Game.Enemy.Attack.Impl
{
	public class RangeAttack : AbstractAttack
	{
		private readonly IBulletService _bulletService;
		private readonly IEntityContext _ownerContext;
		private readonly float _damage;
		private const string ENEMY_BULLET_ID = "EnemyBullet";
		public override EnemyAttackType EnemyAttackType => EnemyAttackType.Range;
		public static float Cooldown => 1f;
		public override float CurrentCoolDown { get; set; } = Cooldown;

		public override bool InCoolDown => CurrentCoolDown <= Cooldown;
		
		public RangeAttack(IBulletService bulletService, IEntityContext ownerContext, float damage)
		{
			_bulletService = bulletService;
			_ownerContext = ownerContext;
			_damage = damage;
		}
		
		public override void Attack()
		{
			_bulletService.CreateBullet(
				ENEMY_BULLET_ID,
				BulletTarget.Player,
				_ownerContext.Transform.position + _ownerContext.Transform.rotation * new Vector3(0,1), 
				_ownerContext.Transform.up * 10, _damage);
		}
	}
}
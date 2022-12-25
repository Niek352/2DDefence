using Game.View.Impl;
using UnityEngine;

namespace Game.Services.Bullet.Impl
{
	public class BulletController
	{
		public readonly int Damage;
		public readonly float BonusDamage;
		public readonly EntityView View;
		public readonly BulletTarget BulletTarget;
		public readonly Vector3 Velocity;
		public float LifeTime = 3f;
		public Vector3 Position;
		
		public BulletController(int damage, float bonusDamage, BulletTarget bulletTarget, Vector3 position, EntityView view, Vector3 velocity)
		{
			BulletTarget = bulletTarget;
			Damage = damage;
			BonusDamage = bonusDamage;
			View = view;
			Velocity = velocity;
			Position = position;
		}
	}
}
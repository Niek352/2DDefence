using Game.Model;
using Game.Services.Bullet.Impl;
using UnityEngine;

namespace Game.Factories.BulletFactory
{
	public interface IBulletFactory
	{
		BulletController CreateBullet(BulletModel bulletModel, string modelId, BulletTarget bulletTarget, Vector3 position, Vector3 velocity, float bonusDamage);
	}
}
using Game.Services.Bullet.Impl;
using UnityEngine;

namespace Game.Services.Bullet
{
	public interface IBulletService
	{
		void CreateBullet(string id, BulletTarget bulletTarget, Vector3 position, Vector3 velocity);
	}
}
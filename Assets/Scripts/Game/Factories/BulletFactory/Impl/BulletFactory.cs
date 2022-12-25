using Game.Factories.ViewFactory;
using Game.Model;
using Game.Services.Bullet.Impl;
using UnityEngine;

namespace Game.Factories.BulletFactory.Impl
{
	public class BulletFactory : IBulletFactory
	{
		private readonly IViewFactory _viewFactory;
		private readonly Transform _bulletHolder;

		public BulletFactory(IViewFactory viewFactory)
		{
			_viewFactory = viewFactory;
			_bulletHolder = new GameObject("BulletHolder").transform;
		}

		public BulletController CreateBullet(BulletModel bulletModel, string modelId, BulletTarget bulletTarget, Vector3 position, Vector3 velocity, float bonusDamage)
		{
			var entityView = _viewFactory.CreateView(modelId, _bulletHolder);
			entityView.transform.position = position;
			entityView.transform.rotation = Quaternion.Euler(0,0,Mathf.Atan2(velocity.normalized.y, velocity.normalized.x) * Mathf.Rad2Deg - 90f);
			return new BulletController(bulletModel.Damage, bonusDamage, bulletTarget, position, entityView, velocity);
		}
	}
}
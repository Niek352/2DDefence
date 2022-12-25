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

		public BulletController CreateBullet(BulletModel bulletModel, string modelId, BulletTarget bulletTarget, Vector3 position, Vector3 velocity)
		{
			var entityView = _viewFactory.CreateView(modelId, _bulletHolder);
			entityView.transform.position = position;
			return new BulletController(bulletModel.Damage, bulletTarget, position, entityView, velocity);
		}
	}
}
using Game.Services.Bullet;
using Game.Services.Bullet.Impl;

namespace Game.Player.PlayerServices
{
	public class PlayerShooting : PlayerService, IPlayerUpdateService
	{
		private readonly IBulletService _bulletService;
		private float _currentCooldown;
		private readonly float _cooldown = 0.5f;
		private bool InCooldown => _currentCooldown <= _cooldown;
		public PlayerShooting(PlayerContext playerContext, IBulletService bulletService) : base(playerContext)
		{
			_bulletService = bulletService;
			_currentCooldown = _cooldown;
		}
		
		public void Update(float deltaTime)
		{
			if (InCooldown)
			{
				_currentCooldown += deltaTime;
			}
			else
			{
				_currentCooldown = 0;
				Shoot();
			}
		}

		public void Shoot()
		{
			_bulletService.CreateBullet(
				PlayerContext.PlayerData.BulletId,
				BulletTarget.Enemy,
				PlayerContext.Transform.position, 
				PlayerContext.Transform.up);
		}
	}
}
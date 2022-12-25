using System.Collections.Generic;
using Game.EntityContext;
using Game.Health;
using Game.Health.Impl;
using UnityEngine;

namespace Game.Player
{
	public class PlayerContext : MonoBehaviour, IPlayerContext
	{
		private BaseHealth _health;
		private PlayerController _playerController;
		public IHealth Health => _health;
		private bool _isInited;
		public bool IsAlive => _isInited && !_health.IsDead;
		
		public void Init(BaseHealth baseHealth, PlayerController playerController)
		{
			_health = baseHealth;
			_playerController = playerController;
			_isInited = true;
		}

		private void Update()
		{
			if (!IsAlive)
				return;
			_playerController.Update(Time.deltaTime);
		}
	}

	public class PlayerController
	{
		private readonly List<IPlayerUpdateService> _updateServices = new List<IPlayerUpdateService>();
		public PlayerController(IReadOnlyList<IPlayerService> services)
		{
			foreach (var service in services)
			{
				if (service is IPlayerUpdateService updateService)
				{
					_updateServices.Add(updateService);
				}
			}
		}

		public void Update(float deltaTime)
		{
			foreach (var updateService in _updateServices)
			{
				updateService.Update(deltaTime);
			}
		}
	}

	public interface IPlayerContext : IEntityContext
	{
		
	}

	public interface IPlayerService
	{
		
	}

	public abstract class PlayerService : IPlayerService
	{
		protected readonly PlayerContext PlayerContext;
		protected PlayerService(PlayerContext playerContext)
		{
			PlayerContext = playerContext;
		}
	}
	
	public interface IPlayerUpdateService : IPlayerService
	{
		void Update(float deltaTime);
	}
}
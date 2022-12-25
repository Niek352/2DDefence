using Game.Services.PlayerStorage;
using UnityEngine;
using VContainer.Unity;

namespace Game.Services
{
	public class PlayerControllerUpdateService : ITickable
	{
		private readonly IPlayerStorage _playerStorage;
		
		public PlayerControllerUpdateService(IPlayerStorage playerStorage)
		{
			_playerStorage = playerStorage;
		}
		
		public void Tick()
		{
			if (!_playerStorage.Player.IsAlive)
				return;
			_playerStorage.Player.PlayerController.Update(Time.deltaTime);
		}
	}
}
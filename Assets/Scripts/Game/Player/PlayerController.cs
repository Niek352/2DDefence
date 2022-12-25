using System.Collections.Generic;

namespace Game.Player
{
	public class PlayerController : IPlayerController
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
}
using Game.Factories.PlayerFactory;
using Game.Services.PlayerStorage;
using VContainer.Unity;

namespace Game.Services.Initialize
{
	public class PlayerInitialize : IInitializable
	{
		private readonly IPlayerFactory _playerFactory;
		private readonly IPlayerStorage _playerStorage;

		public PlayerInitialize(IPlayerFactory playerFactory, IPlayerStorage playerStorage)
		{
			_playerFactory = playerFactory;
			_playerStorage = playerStorage;
		}
		
		public void Initialize()
		{
			var player = _playerFactory.Create();
			_playerStorage.SetPlayer(player);
		}
	}
}
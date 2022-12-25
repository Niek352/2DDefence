using Game.Ui;
using VContainer.Unity;

namespace Game.Services.Initialize
{
	public class UiInitialize : IInitializable
	{
		private readonly GameHudWindow _gameHudWindow;
		
		public UiInitialize(GameHudWindow gameHudWindow)
		{
			_gameHudWindow = gameHudWindow;
		}
		
		public void Initialize()
		{
			_gameHudWindow.Show();
		}
	}
}
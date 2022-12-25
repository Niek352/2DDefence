using Menu.Ui;
using VContainer.Unity;

namespace Menu.Initialize
{
	public class MenuInitialize : IInitializable
	{
		private readonly MenuWindow _menuWindow;
		public MenuInitialize(MenuWindow menuWindow)
		{
			_menuWindow = menuWindow;
		}
		
		public void Initialize()
		{
			_menuWindow.Show();
		}
	}
}
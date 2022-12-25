using Game.Ui.Controllers;
using Ui;
using VContainer;

namespace Game.Ui
{
	public class WinWindow : AbstractWindow
	{
		public WinWindow(IObjectResolver resolver) : base(resolver)
		{
		}
		
		public override void AddControllers()
		{
			AddController<SceneLoaderController>();
			AddController<WinController>();
		}
	}

}
using Game.Ui.Controllers;
using Ui;
using VContainer;

namespace Game.Ui
{
	public class LooseWindow : AbstractWindow
	{
		public LooseWindow(IObjectResolver resolver) : base(resolver)
		{
		}
		
		public override void AddControllers()
		{
			AddController<SceneLoaderController>();
			AddController<LooseController>();
		}
	}
}
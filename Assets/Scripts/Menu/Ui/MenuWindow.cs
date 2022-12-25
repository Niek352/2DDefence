using Ui;
using VContainer;

namespace Menu.Ui
{
	public class MenuWindow : AbstractWindow
	{
		public MenuWindow(IObjectResolver resolver) : base(resolver)
		{
		}
		
		public override void AddControllers()
		{
			AddController<MenuController>();
			AddController<MenuInGameParametersController>();
		}
	}
}
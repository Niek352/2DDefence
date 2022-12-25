using Ui;
using VContainer;

namespace Game.Ui
{
	public class GameHudWindow : AbstractWindow
	{
		public GameHudWindow(IObjectResolver resolver) : base(resolver)
		{
		}
		
		public override void AddControllers()
		{
			AddController<HealthController>();	
		}
	}
}
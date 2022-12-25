using Menu.Initialize;
using VContainer;
using VContainer.Extensions;
using VContainer.Unity;

namespace Menu.Installers
{
	public class MenuInstaller : MonoInstaller
	{
		public override void Install(IContainerBuilder builder)
		{
			builder.RegisterEntryPoint<MenuInitialize>();
		}
	}
}
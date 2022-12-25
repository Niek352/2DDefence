using Menu.Ui;
using Ui;
using UnityEngine;
using VContainer;
using VContainer.Extensions;

namespace Menu.Installers
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(MenuUiInstaller), fileName = nameof(MenuUiInstaller))]
	public class MenuUiInstaller : ScriptableObjectInstaller
	{
		[SerializeField] private Canvas _canvas;

		[SerializeField] private MenuView _menuView;
		[SerializeField] private MenuInGameParametersView _menuInGameParametersView;
		
		public override void Install(IContainerBuilder builder)
		{
			var canvas = Instantiate(_canvas);
			builder.RegisterInstance(canvas);
			
			builder.RegisterUi<MenuController, MenuView>(_menuView, canvas.transform);
			builder.RegisterUi<MenuInGameParametersController, MenuInGameParametersView>(_menuInGameParametersView, canvas.transform);

			builder.Register<MenuWindow>(Lifetime.Singleton);
		}
	}
}
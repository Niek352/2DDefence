using Db.GameParameters.Impl;
using UnityEngine;
using VContainer;
using VContainer.Extensions;

namespace Menu.Installers
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(MenuScriptableInstaller), fileName = nameof(MenuScriptableInstaller))]
	public class MenuScriptableInstaller : ScriptableObjectInstaller
	{
		[SerializeField] private GameParameters _gameParameters;

		public override void Install(IContainerBuilder builder)
		{
			builder.RegisterInstance(_gameParameters);
		}
	}
}
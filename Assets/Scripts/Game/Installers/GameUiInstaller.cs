using Game.Ui;
using Ui;
using UnityEngine;
using VContainer;
using VContainer.Extensions;

namespace Game.Installers
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(GameUiInstaller), fileName = nameof(GameUiInstaller))]
	public class GameUiInstaller : ScriptableObjectInstaller
	{
		[SerializeField] private Canvas _canvas;
		[SerializeField] private HealthView _healthView; 
		
		public override void Install(IContainerBuilder builder)
		{
			var canvas = Instantiate(_canvas);
			builder.RegisterInstance(canvas);
			
			builder.RegisterUi<HealthController, HealthView>(_healthView, canvas.transform);

			builder.Register<GameHudWindow>(Lifetime.Singleton).AsSelf();
		}
	}
}
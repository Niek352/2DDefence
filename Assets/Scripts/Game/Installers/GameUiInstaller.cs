using Game.Ui;
using Game.Ui.Controllers;
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
		[SerializeField] private ScoreView _scoreView; 
		[SerializeField] private SceneLoaderView _sceneLoaderView;
		[SerializeField] private LooseView _looseView;
		[SerializeField] private WinView _winView;
		
		public override void Install(IContainerBuilder builder)
		{
			var canvas = Instantiate(_canvas);
			builder.RegisterInstance(canvas);
			
			builder.RegisterUi<HealthController, HealthView>(_healthView, canvas.transform);
			builder.RegisterUi<ScoreController, ScoreView>(_scoreView, canvas.transform);
			builder.RegisterUi<SceneLoaderController, SceneLoaderView>(_sceneLoaderView, canvas.transform);
			builder.RegisterUi<LooseController, LooseView>(_looseView, canvas.transform);
			builder.RegisterUi<WinController, WinView>(_winView, canvas.transform);

			builder.Register<GameHudWindow>(Lifetime.Singleton).AsSelf();
			builder.Register<WinWindow>(Lifetime.Singleton).AsSelf();
			builder.Register<LooseWindow>(Lifetime.Singleton).AsSelf();
		}
	}
}
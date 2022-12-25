using Ui;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Game.Ui.Controllers
{
	public class SceneLoaderController : UiController<SceneLoaderView>, IStartable
	{
		public void Start()
		{
			View.Menu.onClick.AddListener(OnMenuClick);
			View.Restart.onClick.AddListener(OnRestartClick);
		}
		private void OnRestartClick()
		{
			SceneManager.LoadScene(1);
		}
		
		private void OnMenuClick()
		{
			SceneManager.LoadScene(0);
		}
	}
}
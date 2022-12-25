using Ui;
using UnityEditor;
using UnityEngine.SceneManagement;
using VContainer.Unity;

namespace Menu.Ui
{
	public class MenuController : UiController<MenuView>, IInitializable
	{
		public void Initialize()
		{
			View.Play.onClick.AddListener(OnPlay);
			View.Exit.onClick.AddListener(OnExit);
		}
		
		private void OnExit()
		{
#if UNITY_EDITOR
			EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}

		private void OnPlay()
		{
			SceneManager.LoadScene(sceneBuildIndex: 1);
		}
	}
}
using VContainer;

namespace Ui
{
	public abstract class UiController<TView> : IUiController where TView : UiView
	{
		[Inject] protected TView View;

		public void Show()
		{
			View.gameObject.SetActive(true);
		}

		public void Hide()
		{
			View.gameObject.SetActive(false);
		}
	}
}
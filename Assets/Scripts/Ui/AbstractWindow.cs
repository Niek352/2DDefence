using System.Collections.Generic;
using VContainer;

namespace Ui
{
	public abstract class AbstractWindow : IWindow
	{
		private readonly List<IUiController> _controllers = new List<IUiController>();
		private readonly IObjectResolver _resolver;

		public AbstractWindow(IObjectResolver resolver)
		{
			_resolver = resolver;
		}
		
		[Inject] public abstract void AddControllers();

		public void AddController<TController>()
			where TController : class, IUiController
		{
			_resolver.ToString();
			var uiController = (TController)_resolver.Resolve(typeof(TController));
			_controllers.Add(uiController);
		}
		
		public virtual void Show()
		{
			foreach (var controller in _controllers)
			{
				controller.Show();
			}
		}

		public virtual void Hide()
		{
			foreach (var controller in _controllers)
			{
				controller.Hide();
			}
		}
	}
}
using UnityEngine;
using VContainer;

namespace Ui
{
	public static class Extensions
	{
		public static void RegisterUi<TController, TView>(this IContainerBuilder builder, TView viewPrefab, Transform parent)
			where TController : IUiController
			where TView : UiView
		{
			builder.Register<TController>(Lifetime.Singleton)
				.AsImplementedInterfaces().AsSelf();
			
			builder.Register((resolver) =>
				{
					var view = Object.Instantiate(viewPrefab, parent);
					resolver.Inject(view);
					view.gameObject.SetActive(false);
					return view;
				}, Lifetime.Singleton)
				.AsImplementedInterfaces().AsSelf();
		}
	}
}
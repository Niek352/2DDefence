using Game.View.Impl;
using UnityEngine;

namespace Game.Factories.ViewFactory
{
	public interface IViewFactory
	{
		EntityView CreateView(string id, Transform parent);
	}
}
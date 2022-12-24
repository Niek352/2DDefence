using System.Collections.Generic;
using System.Linq;
using Db.ViewData;
using Game.View.Impl;
using UnityEngine;

namespace Game.Factories.ViewFactory.Impl
{
	public class ViewFactory : IViewFactory
	{
		private readonly Dictionary<string, EntityView> _entityViews;
		
		public ViewFactory(IViewData viewData)
		{
			_entityViews = viewData.EntityViews.ToDictionary(view => view.Id, item => item.EntityView);
		}
		
		public EntityView CreateView(string id, Transform parent)
		{
			return Object.Instantiate(_entityViews[id], parent);
		}
	}
}
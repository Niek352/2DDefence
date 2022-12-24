using System;
using System.Collections.Generic;
using Game.View.Impl;

namespace Db.ViewData
{
	public interface IViewData
	{
		IReadOnlyList<EntityViewItem> EntityViews { get; }
	}

	[Serializable]
	public struct EntityViewItem
	{
		public EntityView EntityView;
		public string Id;
	}
}
using System.Collections.Generic;
using UnityEngine;

namespace Db.ViewData.Impl
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(ViewData), fileName = nameof(ViewData))]
	public class ViewData : ScriptableObject, IViewData
	{
		[SerializeField, InspectorName("Id")] private List<EntityViewItem> _entityViews;

		public IReadOnlyList<EntityViewItem> EntityViews => _entityViews;
	}
}
using Game.Ui;
using UnityEngine;

namespace Db.HealthViewData.Impl
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(HealthViewData), fileName = nameof(HealthViewData))]
	public class HealthViewData : ScriptableObject, IHealthViewData
	{
		[SerializeField] private HealthViewElement _healthView;
		public HealthViewElement HealthPrefab => _healthView;
	}
}
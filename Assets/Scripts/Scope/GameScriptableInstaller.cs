using Db.EnemyData;
using Db.EnemyData.Impl;
using UnityEngine;
using VContainer;
using VContainer.Extensions;

namespace Scope
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(GameScriptableInstaller), fileName = nameof(GameScriptableInstaller))]
	public class GameScriptableInstaller : ScriptableObjectInstaller
	{
		[SerializeField] private EnemyData _enemyData;
		public override void Install(IContainerBuilder builder)
		{
			builder.RegisterInstance(_enemyData).As<IEnemyData>();
		}
	}
}
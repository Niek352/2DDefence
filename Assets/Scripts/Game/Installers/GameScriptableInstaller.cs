using Db.EnemyData;
using Db.EnemyData.Impl;
using Db.PlayerData;
using Db.PlayerData.Impl;
using UnityEngine;
using VContainer;
using VContainer.Extensions;

namespace Game.Installers
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(GameScriptableInstaller), fileName = nameof(GameScriptableInstaller))]
	public class GameScriptableInstaller : ScriptableObjectInstaller
	{
		[SerializeField] private EnemyData _enemyData;
		[SerializeField] private PlayerData _playerData;
		public override void Install(IContainerBuilder builder)
		{
			builder.RegisterInstance(_enemyData).As<IEnemyData>();
			builder.RegisterInstance(_playerData).As<IPlayerData>();
		}
	}
}
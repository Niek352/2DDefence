﻿using Db.BulletData;
using Db.BulletData.Impl;
using Db.EnemyData;
using Db.EnemyData.Impl;
using Db.PlayerData;
using Db.PlayerData.Impl;
using Db.ViewData;
using Db.ViewData.Impl;
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
		[SerializeField] private ViewData _viewData;
		[SerializeField] private BulletData _bulletData;
		
		public override void Install(IContainerBuilder builder)
		{
			builder.RegisterInstance(_enemyData).As<IEnemyData>();
			builder.RegisterInstance(_playerData).As<IPlayerData>();
			builder.RegisterInstance(_viewData).As<IViewData>();
			builder.RegisterInstance(_bulletData).As<IBulletData>();
		}
	}
}
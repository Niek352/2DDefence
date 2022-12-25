using System.Collections.Generic;
using Db.HealthViewData;
using Game.Enemy;
using Game.EntityContext;
using Game.Services.CleanUp.Impl;
using Game.Services.EnemyStorage;
using Game.Services.PlayerStorage;
using Ui;
using UnityEngine;
using VContainer.Unity;

namespace Game.Ui
{
	public class HealthController : UiController<HealthView>, ITickable, IStartable
	{
		private readonly Camera _camera;
		private readonly IPlayerStorage _playerStorage;
		private readonly IEnemyStorage _enemyStorage;
		private readonly IEnemyCleanUp _enemyCleanUp;
		private readonly IHealthViewData _healthViewData;
		private readonly Dictionary<IEntityContext, HealthItemView> _uiElements = new Dictionary<IEntityContext, HealthItemView>();

		public HealthController(
			Camera camera, 
			IPlayerStorage playerStorage,
			IEnemyStorage enemyStorage,
			IEnemyCleanUp enemyCleanUp,
			IHealthViewData healthViewData)
		{
			_camera = camera;
			_playerStorage = playerStorage;
			_enemyStorage = enemyStorage;
			_enemyCleanUp = enemyCleanUp;
			_healthViewData = healthViewData;
		}
		
		public void Start()
		{
			_enemyCleanUp.OnCleanUp += OnCleanUp;
			_enemyStorage.OnCreate += AddObserved;
			AddObserved(_playerStorage.Player);
		}
		
		private void OnCleanUp(EnemyContext obj)
		{
			Object.Destroy(_uiElements[obj].HealthViewElement.gameObject);
			_uiElements.Remove(obj);
		}

		private void AddObserved(IEntityContext entityContext)
		{
			var healthView = Object.Instantiate(_healthViewData.HealthPrefab, View.transform);
			healthView.Initialize(entityContext is IEnemyContext, entityContext.Health.MaxHealth);
			var healthItemView = new HealthItemView(entityContext, healthView);
			entityContext.Health.OnHealthChanged += healthView.UpdateHealth;
			_uiElements.Add(entityContext, healthItemView);
		}
        
		public void Tick()
		{
			foreach (var healthElement in _uiElements.Values)
			{
				var screenPoint = RectTransformUtility.WorldToScreenPoint(_camera, healthElement.ObservedEntity.Transform.position);
				healthElement.HealthViewElement.transform.position = screenPoint;
			}
		}
	}
	
	internal class HealthItemView
	{
		public readonly HealthViewElement HealthViewElement;
		public readonly IEntityContext ObservedEntity;
		
		public HealthItemView(IEntityContext entityContext, HealthViewElement healthViewElement)
		{
			ObservedEntity = entityContext;
			HealthViewElement = healthViewElement;
		}
	}

}
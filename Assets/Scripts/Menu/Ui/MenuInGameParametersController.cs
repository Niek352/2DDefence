using System.Globalization;
using Db.GameParameters.Impl;
using Ui;
using UnityEngine;
using UnityEngine.Events;
using VContainer.Unity;

namespace Menu.Ui
{
	public class MenuInGameParametersController : UiController<MenuInGameParametersView>, IStartable
	{
		private readonly GameParameters _gameParameters;
	
		public MenuInGameParametersController(GameParameters gameParameters)
		{
			_gameParameters = gameParameters;
		}
		
		public void Start()
		{
			CreateField(arg0 =>
			{
				if (float.TryParse(arg0, out var value))
				{
					_gameParameters.SpawnDelay = value;
				}
			}, "Spawn Delay", _gameParameters.SpawnDelay);
			
			CreateField(arg0 =>
			{
				if (float.TryParse(arg0, out var value))
				{
					_gameParameters.PlayerData.MaxHealth = value;
				}
			}, "Player Health", _gameParameters.PlayerData.MaxHealth);
			
			CreateField(arg0 =>
			{
				if (float.TryParse(arg0, out var value))
				{
					_gameParameters.PlayerData.BonusDamage = value;
				}
			}, "Player Damage", _gameParameters.PlayerData.BonusDamage);
			
			foreach (var enemy in _gameParameters.EnemyData.EnemyModels)
			{
				CreateField(arg0 =>
				{
					if (float.TryParse(arg0, out var value))
					{
						enemy.Health = value;
					}
				}, $"{enemy.Id} health", enemy.Health);
				
				CreateField(arg0 =>
				{
					if (float.TryParse(arg0, out var value))
					{
						enemy.Damage = value;
					}
				}, $"{enemy.Id} damage", enemy.Damage);
			}
		}

		public void CreateField(UnityAction<string> action, string fieldName, float gameParametersSpawnDelay)
		{
			var newItem = Object.Instantiate(View.ParametersItemPrefab, View.transform);
			newItem.FieldName.text = fieldName;
			newItem.InputField.text = gameParametersSpawnDelay.ToString(CultureInfo.InvariantCulture);
			newItem.InputField.onValueChanged.AddListener(action);
		}
	}

}
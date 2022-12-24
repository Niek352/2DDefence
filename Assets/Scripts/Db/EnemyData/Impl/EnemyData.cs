using System.Collections.Generic;
using Game.Enemy;
using Game.Model;
using UnityEngine;

namespace Db.EnemyData.Impl
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(EnemyData), fileName = nameof(EnemyData))]
	public class EnemyData : ScriptableObject, IEnemyData
	{
		[SerializeField, InspectorName("Id")] private List<EnemyModel> _enemyModels;
		[SerializeField] private EnemyContext _enemyContext;
		
		public List<EnemyModel> EnemyModels => _enemyModels;
		public EnemyContext EnemyPrefab => _enemyContext;
	}
}
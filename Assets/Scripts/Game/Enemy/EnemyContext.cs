using Game.Enemy.StateMachine;
using Game.Health;
using Game.Health.Impl;
using Game.Model;
using Game.StateMachine.Interfaces;
using UnityEngine;

namespace Game.Enemy
{
	public class EnemyContext : MonoBehaviour, IEnemyContext
	{
		private EnemyStateMachine _stateMachine;
		private BaseHealth _baseHealth;
		private EnemyModel _enemyModel;
		public IStateMachine StateMachine => _stateMachine;
		public int ScorePoints => _enemyModel.ScorePoints;
		public IHealth Health => _baseHealth;
		public Transform Transform => transform;
		
		public void Init(EnemyStateMachine stateMachine, BaseHealth baseHealth, EnemyModel enemyModel)
		{
			_enemyModel = enemyModel;
			_stateMachine = stateMachine;
			_baseHealth = baseHealth;
			_stateMachine.Initialize<InitializeState>();
		}
	}
}
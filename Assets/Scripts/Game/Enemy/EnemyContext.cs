using Game.Enemy.StateMachine;
using Game.Health;
using Game.Health.Impl;
using Game.StateMachine.Interfaces;
using UnityEngine;

namespace Game.Enemy
{
	public class EnemyContext : MonoBehaviour, IEnemyContext
	{
		private EnemyStateMachine _stateMachine;
		private BaseHealth _baseHealth;
		public IStateMachine StateMachine => _stateMachine;
		public IHealth Health => _baseHealth;
		
		public void Init(EnemyStateMachine stateMachine, BaseHealth baseHealth)
		{
			_stateMachine = stateMachine;
			_baseHealth = baseHealth;
			_stateMachine.Initialize<InitializeState>();
		}
	}
}
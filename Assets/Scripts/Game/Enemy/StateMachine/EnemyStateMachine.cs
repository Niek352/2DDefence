using System;
using System.Collections.Generic;
using Game.Enemy.Attack.Abstract;
using Game.Enemy.Movement.Abstract;
using Game.StateMachine;
using Game.StateMachine.Abstract;
using Game.StateMachine.Interfaces;

namespace Game.Enemy.StateMachine
{
	public class EnemyStateMachine : AbstractStateMachine
	{
		private readonly Dictionary<Type, IState> _states = new Dictionary<Type, IState>();
		private IState _currentState;
		
		public EnemyStateMachine(EnemyContext owner, AbstractAttack attack, AbstractMovement movement)
		{
			_states.Add(typeof(AttackState), new AttackState(attack, this));
			_states.Add(typeof(MovementState), new MovementState(movement, this));
			_states.Add(typeof(InitializeState), new InitializeState(this));
		}

		public override void Initialize<TState>()
		{
			_currentState = _states[typeof(TState)];
			_currentState.Enter();
		}
		
		public override void Update(float deltaTime)
		{
			_currentState.Update(deltaTime);
		}

		public override void ChangeState<TState>()
		{
			_currentState.Exit();
			_currentState = _states[typeof(TState)];
			_currentState.Enter();
		}
	}
}
using Game.StateMachine.Interfaces;

namespace Game.StateMachine.Abstract
{
	public abstract class AbstractStateMachine : IStateMachine
	{
		public abstract void ChangeState<TState>() where TState : IState;
		public abstract void Initialize<TState>() where TState : IState;
		public abstract void Update(float deltaTime);
	}

}
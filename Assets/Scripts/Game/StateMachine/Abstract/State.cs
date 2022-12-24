using Game.StateMachine.Interfaces;

namespace Game.StateMachine.Abstract
{
	public abstract class State : IState
	{
		protected readonly IStateMachine StateMachine;
		
		protected State(IStateMachine stateMachine)
		{
			StateMachine = stateMachine;
		}
		
		public abstract void Enter();
		public abstract void Update(float deltaTime);
		public abstract void Exit();
	}
}
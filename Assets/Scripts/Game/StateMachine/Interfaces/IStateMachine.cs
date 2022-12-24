namespace Game.StateMachine.Interfaces
{
	public interface IStateMachine
	{
		public void ChangeState<TState>() where TState : IState;
		public void Update(float deltaTime);
	}
}
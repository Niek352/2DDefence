using Game.StateMachine.Abstract;
using Game.StateMachine.Interfaces;

namespace Game.Enemy.StateMachine
{
	public class InitializeState : State
	{
		private float _delay = 1;
		public InitializeState(IStateMachine stateMachine) : base(stateMachine)
		{
			
		}
		
		public override void Enter()
		{
		}
		
		public override void Update(float deltaTime)
		{
			_delay -= deltaTime;
			if (_delay <= 0)
			{
				StateMachine.ChangeState<MovementState>();
			}
		}
		
		public override void Exit()
		{
			
		}
	}
}
using Game.Enemy.Movement.Abstract;
using Game.StateMachine.Abstract;
using Game.StateMachine.Interfaces;

namespace Game.Enemy.StateMachine
{
	public class MovementState : State
	{
		private readonly AbstractMovement _movement;
		public MovementState(AbstractMovement movement, IStateMachine stateMachine) : base(stateMachine)
		{
			_movement = movement;
		}
		
		public override void Enter()
		{
			
		}
		
		public override void Update(float deltaTime)
		{
			if (_movement.ReachedTarget)
			{
				StateMachine.ChangeState<AttackState>();
				return;
			}
			
			_movement.Move(deltaTime);			
		}
		
		public override void Exit()
		{
		}
	}
}
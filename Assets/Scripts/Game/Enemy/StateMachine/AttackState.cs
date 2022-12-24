using Game.Enemy.Attack.Abstract;
using Game.StateMachine.Abstract;
using Game.StateMachine.Interfaces;

namespace Game.Enemy.StateMachine
{
	public class AttackState : State
	{
		private readonly AbstractAttack _attack;

		public AttackState(AbstractAttack attack, IStateMachine stateMachine) : base(stateMachine)
		{
			_attack = attack;
		}
		
		public override void Enter()
		{

		}

		public override void Update(float deltaTime)
		{
			if (_attack.InCoolDown)
			{
				_attack.CurrentCoolDown += deltaTime;
			}
			else
			{
				_attack.CurrentCoolDown = 0;
				_attack.Attack();
			}
		}

		public override void Exit()
		{
		}
	}
}
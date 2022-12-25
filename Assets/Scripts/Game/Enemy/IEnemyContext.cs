using Game.EntityContext;
using Game.StateMachine.Interfaces;

namespace Game.Enemy
{
	public interface IEnemyContext : IEntityContext
	{
		IStateMachine StateMachine { get; }
		int ScorePoints { get; }
	}
}
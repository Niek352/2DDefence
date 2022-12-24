using Game.Health;

namespace Game.EntityContext
{
	public interface IEntityContext
	{
		IHealth Health { get; }
	}
}
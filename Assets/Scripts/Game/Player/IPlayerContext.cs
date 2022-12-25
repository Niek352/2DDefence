using Game.EntityContext;

namespace Game.Player
{
	public interface IPlayerContext : IEntityContext
	{
		IPlayerController PlayerController { get; }
	}
}
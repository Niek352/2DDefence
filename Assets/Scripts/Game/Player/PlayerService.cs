namespace Game.Player
{
	public abstract class PlayerService : IPlayerService
	{
		protected readonly PlayerContext PlayerContext;
		protected PlayerService(PlayerContext playerContext)
		{
			PlayerContext = playerContext;
		}
	}
}
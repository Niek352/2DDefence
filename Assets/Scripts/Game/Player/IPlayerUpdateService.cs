namespace Game.Player
{
	public interface IPlayerUpdateService : IPlayerService
	{
		void Update(float deltaTime);
	}
}
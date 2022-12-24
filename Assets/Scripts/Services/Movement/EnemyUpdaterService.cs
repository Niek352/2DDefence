using Services.EnemyStorage;
using VContainer.Unity;

namespace Services.Movement
{
	public class EnemyUpdaterService : ITickable
	{
		private readonly IEnemyStorage _enemyStorage;
		
		public EnemyUpdaterService(IEnemyStorage enemyStorage)
		{
			_enemyStorage = enemyStorage;
		}
		
		public void Tick()
		{
			foreach (var enemyContext in _enemyStorage.Enemies)
			{
				
			}			
		}
	}
}
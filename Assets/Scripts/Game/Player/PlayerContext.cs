using Game.EntityContext;
using Game.Health;
using Game.Health.Impl;
using UnityEngine;

namespace Game.Player
{
	public class PlayerContext : MonoBehaviour, IPlayerContext
	{
		private BaseHealth _health;
		public IHealth Health => _health;

		public void Init(BaseHealth baseHealth)
		{
			_health = baseHealth;
		}
	}

	public interface IPlayerContext : IEntityContext
	{
		
	}
}
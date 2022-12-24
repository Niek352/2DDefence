using System;

namespace Game.Health
{
	public interface IHealth
	{
		public float CurrentHealth { get; set; }
		public float MaxHealth { get; set; }
		public bool IsDead { get; set; }
		
		public event Action<Impl.BaseHealth> OnDead;
		void DecreaseHealth(float damage);
	}
}
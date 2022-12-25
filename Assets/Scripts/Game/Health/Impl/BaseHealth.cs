using System;
using UnityEngine;

namespace Game.Health.Impl
{
	public class BaseHealth : IHealth
	{
		public float CurrentHealth { get; set; }
		public float MaxHealth { get; set; }
		public bool IsDead { get; set; }
		
		public event Action<IHealth> OnDead; 
		public event Action<IHealth> OnHealthChanged; 

		public BaseHealth(float maxHealth)
		{
			CurrentHealth = maxHealth;
			MaxHealth = maxHealth;
		}

		public void DecreaseHealth(float damage)
		{
			CurrentHealth -= damage;
			CurrentHealth = Mathf.Clamp(CurrentHealth,0, MaxHealth);
			OnHealthChanged?.Invoke(this);
			if (CurrentHealth == 0 && !IsDead)
			{
				IsDead = true;
				OnDead?.Invoke(this);
				OnDead = null;
				OnHealthChanged = null;
			}
		}
	}
}
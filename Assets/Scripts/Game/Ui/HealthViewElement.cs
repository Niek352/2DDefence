using Game.Health;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Ui
{
	public class HealthViewElement : MonoBehaviour
	{
		public Image HealthBar;
		public float MaxHealth;
		
		public void Initialize(bool isEnemy, float maxHealth)
		{
			HealthBar.fillAmount = 1;
			MaxHealth = maxHealth;
			HealthBar.color = isEnemy ? Color.red : Color.green;
		}

		public void UpdateHealth(IHealth health)
		{
			HealthBar.fillAmount = 1f / MaxHealth * health.CurrentHealth;
		}
	}
}
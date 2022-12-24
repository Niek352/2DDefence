using Enemy.Attack.Abstract;
using Enemy.Movement.Abstract;
using Model;
using UnityEngine;

namespace Enemy
{
	public class EnemyContext : MonoBehaviour
	{
		private AbstractAttack _attack;
		private AbstractMovement _movement;
		private EnemyModel _enemyModel;
		
		public void Init(AbstractAttack attack, AbstractMovement movement, EnemyModel enemyModel)
		{
			_attack = attack;
			_movement = movement;
			_enemyModel = enemyModel;
		}
	}
}
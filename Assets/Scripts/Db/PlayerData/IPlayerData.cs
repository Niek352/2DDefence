using Game.Player;
using UnityEngine;

namespace Db.PlayerData
{
	public interface IPlayerData
	{
		Vector3 PlayerSpawnPoint { get; }
		PlayerContext PlayerPrefab { get; } 
		float MaxHealth { get; } 
		float RotationSpeed { get; }
		float BonusDamage { get; }
		string BulletId { get; }
	}
}
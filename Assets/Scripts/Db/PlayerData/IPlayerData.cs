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
		string BulletId { get; }
	}
}
using System;
using Game.Extensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Game.Services.EnemySpawnPointCalculator.Impl
{
	public class EnemySpawnPointCalculateService : IEnemySpawnPointCalculateService
	{
		private readonly Camera _camera;
		private const float ENEMY_SIZE = 1f;
		
		public EnemySpawnPointCalculateService(Camera camera)
		{
			_camera = camera;
		}

		public Vector3 GetEnemySpawnPoint()
		{
			var side = (Side)Random.Range(0, Enum.GetValues(typeof(Side)).Length);
			var point = CenterBySide(side) + RandomizePoint(side);
			return point;
		}

		private Vector3 RandomizePoint(Side side)
		{
			return side switch
			{
				Side.Left => new Vector3(0, Random.Range(-CameraExtensions.GetHighestPoint(_camera), CameraExtensions.GetHighestPoint(_camera))),
				Side.Right => new Vector3(0, Random.Range(-CameraExtensions.GetHighestPoint(_camera), CameraExtensions.GetHighestPoint(_camera))),
				Side.Up => new Vector3(Random.Range(-CameraExtensions.GetWidthestPoint(_camera), CameraExtensions.GetWidthestPoint(_camera)), 0),
				Side.Down => new Vector3(Random.Range(-CameraExtensions.GetWidthestPoint(_camera), CameraExtensions.GetWidthestPoint(_camera)), 0),
				_ => throw new ArgumentOutOfRangeException(nameof(side), side, null)
			};
		}
		private Vector3 CenterBySide(Side side)
		{
			return side switch
			{
				Side.Left => new Vector3(-CameraExtensions.GetWidthestPoint(_camera) - ENEMY_SIZE, 0),
				Side.Right => new Vector3(CameraExtensions.GetWidthestPoint(_camera) + ENEMY_SIZE, 0),
				Side.Up => new Vector3(0, CameraExtensions.GetHighestPoint(_camera) + ENEMY_SIZE),
				Side.Down => new Vector3(0, -CameraExtensions.GetHighestPoint(_camera) - ENEMY_SIZE),
				_ => throw new ArgumentOutOfRangeException(nameof(side), side, null)
			};
		}
		
		
		private enum Side : byte
		{
			Left,
			Right,
			Up,
			Down
		}
	}
}
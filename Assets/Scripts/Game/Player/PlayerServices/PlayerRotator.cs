using UnityEngine;

namespace Game.Player.PlayerServices
{
	public class PlayerRotator : PlayerService, IPlayerUpdateService
	{
		private readonly Camera _camera;
		private readonly Transform _playerContextTransform;
		public PlayerRotator(PlayerContext playerContext, Camera camera) : base(playerContext)
		{
			_camera = camera;
			_playerContextTransform = PlayerContext.transform;
		}
		
		public void Update(float deltaTime)
		{
			RotateToMouse(deltaTime);
		}

		private void RotateToMouse(float deltaTime)
		{
			var dir = _camera.ScreenToWorldPoint(Input.mousePosition) - _playerContextTransform.position;
			var targetRotation = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90f;
			
			_playerContextTransform.rotation = Quaternion.RotateTowards(
				_playerContextTransform.rotation, 
				Quaternion.Euler(0,0,targetRotation), 
				deltaTime * (360f * PlayerContext.PlayerData.RotationSpeed));
		}
	}
}
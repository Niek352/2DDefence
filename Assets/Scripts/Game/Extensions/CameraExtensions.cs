using UnityEngine;

namespace Game.Extensions
{
	public static class CameraExtensions
	{
		public static float GetHighestPoint(Camera camera) 
			=> camera.orthographicSize;
		
		public static float GetWidthestPoint(Camera camera) 
			=> (float)Screen.width / Screen.height * camera.orthographicSize;
	}
}
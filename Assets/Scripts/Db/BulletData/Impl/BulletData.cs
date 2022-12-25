using System.Collections.Generic;
using Game.Model;
using UnityEngine;

namespace Db.BulletData.Impl
{
	[CreateAssetMenu(menuName = "Settings/" + nameof(BulletData), fileName = nameof(BulletData))]
	public class BulletData : ScriptableObject, IBulletData
	{
		[SerializeField] private List<BulletModel> _bulletModels;

		public List<BulletModel> BulletModels => _bulletModels;
	}
}
using System.Collections.Generic;
using Game.Model;

namespace Db.BulletData
{
	public interface IBulletData
	{
		List<BulletModel> BulletModels { get; }
	}
}
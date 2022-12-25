using Game.Health;
using UnityEngine;

namespace Game.EntityContext
{
	public interface IEntityContext
	{
		IHealth Health { get; }
		Transform Transform { get; }
	}
}
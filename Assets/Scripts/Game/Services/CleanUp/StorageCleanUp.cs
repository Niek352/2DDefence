using System;
using System.Collections.Generic;
using Game.EntityContext;
using VContainer.Unity;

namespace Game.Services.CleanUp
{

	public abstract class StorageCleanUp<TContext> : ILateTickable
		where TContext : IEntityContext
	{
		private readonly Stack<TContext> _contexts = new Stack<TContext>();
		public event Action<TContext> OnCleanUp;
		
		public void LateTick()
		{
			while (_contexts.Count != 0)
			{
				var entityContext = _contexts.Pop();
				OnCleanUp?.Invoke(entityContext);
				Cleanup(entityContext);
			}
		}

		public abstract void Cleanup(TContext context);
		
		public void ObserveEntityDeath(TContext entityContext)
		{
			entityContext.Health.OnDead += health => OnDead(entityContext);
		}
		
		private void OnDead(TContext entityContext)
		{
			_contexts.Push(entityContext);
		}
	}
}
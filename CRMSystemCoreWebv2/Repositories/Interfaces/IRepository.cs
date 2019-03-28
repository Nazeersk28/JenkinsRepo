using System;
using System.Collections.Generic;

namespace Yokogawa.Libraries.Repositories.Interfaces
{
    public interface IRepository<Entity, EntityKey> : IDisposable
    {
        IEnumerable<Entity> GetEntities();
        Entity GetEntityByKey(EntityKey entityKey);
        bool AddEntity(Entity entity);
    }
}

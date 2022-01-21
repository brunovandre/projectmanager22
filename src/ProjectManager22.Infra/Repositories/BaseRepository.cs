using ProjectManager22.Domain.Entities;
using ProjectManager22.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager22.Infra.Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : Entity
    {
        protected ProjectManager22DbContext Context { get; private set; }

        public BaseRepository(ProjectManager22DbContext context)
        {
            Context = context;
        }
        
        public virtual async Task<T> InsertAndSaveChangesAsync(T entity)
        {
            await Context.AddAsync<T>(entity);

            await Context.SaveChangesAsync();

            return entity;
        }

        public virtual async Task UpdateAndSaveChangesAsync(T entity)
        {
            Context.Update<T>(entity);

            await Context.SaveChangesAsync();
        }

        public virtual async Task RemoveAndSaveChangesAsync(T entity)
        {
            Context.Remove<T>(entity);

            await Context.SaveChangesAsync();
        }
    }
}

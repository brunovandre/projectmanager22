using ProjectManager22.Domain.Entities;
using System.Threading.Tasks;

namespace ProjectManager22.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T : Entity
    {
        Task<T> InsertAndSaveChangesAsync(T entity);
        Task UpdateAndSaveChangesAsync(T entity);
        Task RemoveAndSaveChangesAsync(T entity);
    }
}

using System.Linq.Expressions;

namespace Authentication.Application.Persistance;

public interface IRepository<TItem, in TId> where TItem : class
{
    Task<TItem> Get(TId id);
    
    Task<IEnumerable<TItem>> GetAll();
    
    Task Create(TItem item);
    
    Task Update(TItem item);
    
    Task Delete(TId id);

    // Flexible querying
    Task<IEnumerable<TItem>> GetBy(Expression<Func<TItem, bool>> predicate);
}
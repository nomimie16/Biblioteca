using Microsoft.EntityFrameworkCore;

public class GenericRepository<T> : IGenericRepository<T> where T : class, IEntity
{
    private readonly LibraryContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(LibraryContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();  // Set<T> : Accès générique à la table
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T Get(int id)
    {
        return _dbSet.Find(id);
    }

    public T Add(T entity)
    {
        _dbSet.Add(entity);
        _context.SaveChanges();
        return entity;
    }

    IEntity IGenericRepository<T>.Add(IEntity entity)
    {
        return Add((T)entity);
    }

    public IEnumerable<T> GetMultiple(Func<T, bool>? filter = null, params string[] includes)
    {
        IQueryable<T> query = _dbSet;
        foreach (var include in includes)
        {
            query = query.Include(include);
        }
        if (filter != null)
        {
            return query.AsEnumerable().Where(filter);
        }

        return query.ToList();
    }
}
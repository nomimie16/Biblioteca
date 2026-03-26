public interface IGenericRepository<T> where T : IEntity
{
    
    IEntity Add(IEntity entity);

    IEnumerable<T> GetMultiple(Func<T, bool>? filter = null, params string[] includes);
}


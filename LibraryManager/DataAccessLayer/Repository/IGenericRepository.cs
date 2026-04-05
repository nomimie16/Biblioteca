// Interface générique : fonctionne avec n'importe quel type d'entité
public interface IGenericRepository<T> where T : IEntity
{
    T Add(T entity);
    IEnumerable<T> GetMultiple(Func<T, bool>? filter = null, params string[] includes);
    void Delete(int id);
}

// Utilisation :
// IGenericRepository<Book>   → GetAll() retourne IEnumerable<Book>
// IGenericRepository<Author> → GetAll() retourne IEnumerable<Author>
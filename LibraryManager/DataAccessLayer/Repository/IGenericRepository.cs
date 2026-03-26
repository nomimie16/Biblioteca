// Interface générique : fonctionne avec n'importe quel type d'entité
public interface IGenericRepository<T> where T : IEntity
{
    IEnumerable<T> GetAll();
    T Get(int id);
    T Add(T entity);
    IEnumerable<T> GetMultiple(Func<T, bool>? filter = null, params string[] includes);
}

// Utilisation :
// IGenericRepository<Book>   → GetAll() retourne IEnumerable<Book>
// IGenericRepository<Author> → GetAll() retourne IEnumerable<Author>
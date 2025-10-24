namespace Repository;

public class Repository<T>
{
    private readonly List<T> _entities = [];
    public void Create(T entity)
    {
        _entities.Add(entity);
    }

    public T? GetById(int id)
    {
        // Implementation for retrieving an object by its ID
        var prop = typeof(T).GetProperty("Id");
        return _entities.FirstOrDefault(e => (int)prop?.GetValue(e)! == id);
    }

    public void Update(T entity)
    {
        var prop = typeof(T).GetProperty("Id");
        var id = (int)prop?.GetValue(entity)!;
        var existingEntity = GetById(id);
        _entities.Remove(existingEntity!);
        _entities.Add(entity);
    }

    public void Delete(int id)
    {
        var entity = GetById(id);
        _entities.Remove(entity!);
    }
}

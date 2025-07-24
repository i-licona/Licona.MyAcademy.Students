namespace Licona.MyAcademy.Students.Domain.Ports.Repositories;

public interface IDatabaseRepository<T>
{
    public Task<Guid> Create(T entity);
    public Task<int> Update(Guid id, T entity);
    public Task<int> Delete(Guid id);
    public Task<List<T>> GetAll();
    public Task<T> GetById(Guid id);
}

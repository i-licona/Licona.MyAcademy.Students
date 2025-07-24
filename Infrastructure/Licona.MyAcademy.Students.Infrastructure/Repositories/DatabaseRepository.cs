using Microsoft.EntityFrameworkCore;
using Licona.MyAcademy.Students.Domain.Entities.Tables;
using Licona.MyAcademy.Students.Infrastructure.Database;
using Licona.MyAcademy.Students.Domain.Ports.Repositories;

namespace Licona.MyAcademy.Students.Infrastructure.Repositories;

public class DatabaseRepository(
     StudentsDbContext _context
) : IDatabaseRepository<Student>
{
    public async Task<Guid> Create(Student entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
        return entity.Id;
    }

    public async Task<int> Delete(Guid id)
    {
        _context.Remove(id);
        return await _context.SaveChangesAsync();
    }

    public async Task<List<Student>> GetAll()
    {
        return await _context.Students.ToListAsync();
    }

    public async Task<Student> GetById(Guid id)
    {
        return await _context.Students.FirstOrDefaultAsync( x => x.Id.Equals(id) );
    }

    public Task<int> Update(Guid id, Student entity)
    {
        throw new NotImplementedException();
    }
}

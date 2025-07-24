using Microsoft.EntityFrameworkCore;
using Licona.MyAcademy.Students.Domain.Entities.Tables;

namespace Licona.MyAcademy.Students.Infrastructure.Database;

public class StudentsDbContext : DbContext
{
    public StudentsDbContext(
        DbContextOptions<StudentsDbContext> options
    ) : base(options)
    {
    }
    public DbSet<Student> Students { get; set; }
}

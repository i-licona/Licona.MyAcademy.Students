namespace Licona.MyAcademy.Students.Domain.Entities.Tables;

public record Student(
    Guid Id,
    string Name,
    string Lastname,
    DateTime BirthDate
);

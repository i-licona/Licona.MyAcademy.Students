namespace Licona.MyAcademy.Students.Application.Commands;

public record CreateStudentCommand(
    Guid Id,
    string Name,
    string Lastname,
    DateTime BirthDate
);

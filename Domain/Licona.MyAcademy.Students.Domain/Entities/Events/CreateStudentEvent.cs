using Licona.MyAcademy.Students.Domain.Entities.Common;
using Licona.MyAcademy.Students.Domain.Entities.Tables;
namespace Licona.MyAcademy.Students.Domain.Entities.Events;

public record CreateStudentEvent(
Guid Id,
DateTime OccurredOn,
Student Event
) : EventBase<Student>(Id, OccurredOn, Event);

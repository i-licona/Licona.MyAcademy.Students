namespace Licona.MyAcademy.Students.Domain.Entities.Common;

public interface IEventBase
{
    Guid Id { get; }
    DateTime OccurredOn { get; }
    object Event { get; }
}
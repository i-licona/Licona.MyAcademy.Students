namespace Licona.MyAcademy.Students.Domain.Entities.Common;

public record EventBase<T>(
    Guid Id,
    DateTime OccurredOn,
    T Event
);

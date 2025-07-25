using Licona.MyAcademy.Students.Domain.Entities.Common;
using Licona.MyAcademy.Students.Domain.Entities.Tables;

namespace Licona.MyAcademy.Students.Domain.Ports.Store;

public interface IEventStore
{
    Task SaveEvent(IEventBase @event);
}

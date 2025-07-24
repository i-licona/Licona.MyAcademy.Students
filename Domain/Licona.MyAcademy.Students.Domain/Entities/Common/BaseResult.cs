namespace Licona.MyAcademy.Students.Domain.Entities.Common;

public class BaseResult
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
    public int Code { get; set; }
}

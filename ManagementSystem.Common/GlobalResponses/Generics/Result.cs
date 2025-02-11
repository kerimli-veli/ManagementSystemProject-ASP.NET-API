
namespace ManagementSystem.Common.GlobalResponses.Generics;

public class Result<T> :Result
{
    public T Data { get; set; }

    public Result()
    {
        
    }

    public Result(List<string> errors) : base(errors)
    {

    }
}
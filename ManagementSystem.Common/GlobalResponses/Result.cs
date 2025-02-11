namespace ManagementSystem.Common.GlobalResponses;

public class Result
{
    public bool IsSuccess { get; set; }
    public List<string> Errors { get; set; }

    public Result(List<string> errors)
    {
        Errors = errors;
        IsSuccess = false;
    }

    public Result()
    {
        IsSuccess = true;
        Errors = [];
    }
}

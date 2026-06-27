namespace HW10.Services;
public class Result
{
    public bool IsSuccess { get; set; }
    public string Message { get; set; }

    public Result(bool isSuccess, string message = null!)
    {
        IsSuccess = isSuccess;
        Message = message;
    }
}

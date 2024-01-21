namespace Framework.Application;

public class OperationResult
{
    public string Message { get; set; }
    public bool IsSucceeded { get; set; }

    public OperationResult()
    {
        IsSucceeded = false;
    }

    public OperationResult Succeeded(string message = "Operation Succeeded")
    {
        IsSucceeded = true;
        Message = message;
        return this;
    }
    
    public OperationResult Failed(string message = "Operation Failed")
    {
        IsSucceeded = false;
        Message = message;
        return this;
    }
}
namespace ChatNext.Data.Model;

public class ResultDto
{
    public string Code { get; set; }

    public string Message { get; set; }

    public object Data { get; set; }

    public static ResultDto Success(object data)
    {
        return new ResultDto
        {
            Code = "200",
            Message = "成功",
            Data = data
        };
    }

    public static ResultDto Fail(string code, string message)
    {
        return new ResultDto
        {
            Code = code,
            Message = message
        };
    }

    public static ResultDto Fail(string message)
    {
        return new ResultDto
        {
            Code = "500",
            Message = message
        };
    }
}

public class ResultDto<T>
{
    public string Code { get; set; }

    public string Message { get; set; }

    public T Data { get; set; }

    public static ResultDto<T> Success(T data)
    {
        return new ResultDto<T>
        {
            Code = "200",
            Message = "成功",
            Data = data
        };
    }

    public static ResultDto<T> Fail(string code, string message)
    {
        return new ResultDto<T>
        {
            Code = code,
            Message = message
        };
    }

    public static ResultDto<T> Fail(string message)
    {
        return new ResultDto<T>
        {
            Code = "500",
            Message = message
        };
    }
}
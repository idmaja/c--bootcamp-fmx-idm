public readonly struct ResultReponse<T>
{
    public bool Success { get; }
    public string Error { get; }
    public T Value { get; }

    private ResultReponse(bool success, T value, string error)
    {
        Success = success;
        Value = value;
        Error = error;
    }

    public static ResultReponse<T> Ok(T value)
    {
        return new ResultReponse<T>(true, value, string.Empty);
    }

    public static ResultReponse<T> Failed(string error)
    {
        return new ResultReponse<T>(false, default!, error);
    }
}

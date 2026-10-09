namespace CampusTour.Network
{
    public enum ApiError
    {
        None,
        Network,
        Timeout,
        Http
    }

    public class ApiResult<T>
    {
        public bool Success { get; private set; }
        public T Data { get; private set; }
        public ApiError Error { get; private set; }
        public string Message { get; private set; }

        private ApiResult()
        {
        }

        public static ApiResult<T> Ok(T data)
        {
            ApiResult<T> result = new ApiResult<T>();
            result.Success = true;
            result.Data = data;
            result.Error = ApiError.None;
            return result;
        }

        public static ApiResult<T> Fail(ApiError error, string message)
        {
            ApiResult<T> result = new ApiResult<T>();
            result.Success = false;
            result.Error = error;
            result.Message = message;
            return result;
        }
    }
}

namespace HR_System.DataAccessLayer.DTOs
{
    public class GeneralResponse
    {
        public bool IsSuccess { get; }
        public dynamic Data { get; }
        public string Message { get; }
        public string Error { get; }

        public GeneralResponse(bool isSuccess, dynamic data, string message, string error)
        {
            IsSuccess = isSuccess;
            Data = data;
            Message = message;
            Error = error;
        }

        public static GeneralResponse Success(dynamic data, string message) => new(true, data, message, null);
        public static GeneralResponse Failure(string error) => new(false, default!, null, error);
    }
}

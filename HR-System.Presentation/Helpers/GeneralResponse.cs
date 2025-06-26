namespace HR_System.Presentation.Helpers
{
    internal class GeneralResponse
    {
        public bool IsSuccess { get; }
        public string Message { get; }
        public string Error { get; }
        public dynamic Data { get; }

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

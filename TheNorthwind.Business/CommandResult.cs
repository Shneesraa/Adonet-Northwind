namespace TheNorthwind.Business
{
    public class CommandResult
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public string ErrorMessage { get; set; }

        public static CommandResult Success()
        {
            return Success("İşlem başarılı");
        }

        public static CommandResult Success(string message)
        {
            return new CommandResult()
            {
                IsSuccess = true,
                Message = message
            };
        }

        public static CommandResult Failure(Exception exception)
        {
            return Failure("İşlem başarısız", exception);
        }

        public static CommandResult Failure(string message, Exception exception)
        {
            return new CommandResult()
            {
                IsSuccess = false,
                Message = message,
                ErrorMessage = exception.ToString()
            };
        }
    }
}

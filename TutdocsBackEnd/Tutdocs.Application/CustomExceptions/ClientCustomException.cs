namespace Tutdocs.Applications.CustomExceptions
{
    public class ClientCustomException : Exception
    {
        private readonly Dictionary<string, object> _errorData;

        public ClientCustomException(
            string message,
            Dictionary<string, object>? errorData = null
        ) : base(message)
        {
            _errorData = errorData ?? new Dictionary<string, object>();
        }

        public Dictionary<string, object> GetErrorData()
        {
            return _errorData;
        }
    }
}
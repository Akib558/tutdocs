namespace Tutdocs.Applications.CustomExceptions.Users
{
    public class AgentRegistrationException : ClientCustomException
    {
        public AgentRegistrationException(
            string message,
            Dictionary<string, object>? errorData = null
        ) : base(message, errorData)
        {
        }
    }
}

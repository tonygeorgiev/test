namespace ProjectManager.Core.Common.Exceptions
{
    public class UserValidationException : Exception
    {
        public UserValidationException(string message) 
            : base(message)
        {
        }
    }
}

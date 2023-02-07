namespace CrossCutting.Exception.v1
{
    public class UserExistsException : System.Exception
    {
        public UserExistsException(string message) : base(message) { }
    }
}

namespace Task4.Exceptions
{
    public class DueDateInPastException:Exception
    {
        public DueDateInPastException(string message):base(message)
        {
        }
    }
}

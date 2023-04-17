namespace IdentityAuthentication.Domain.Exceptions
{
    public static class ExceptionBase
    {
        public static void When(bool condition, string error)
        {
            if (condition)
                throw new Exception(error);
        }
    }
}

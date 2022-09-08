namespace JWTBasedAuth.Apis.JWT
{
    public interface IJWTAutheticationManager
    {
        public string Authenticate(string username, string password);
    }
}
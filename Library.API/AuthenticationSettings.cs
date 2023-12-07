namespace Library.API
{
    public class AuthenticationSettings
    {
        public string JwtKey { get; set; } = String.Empty;
        public int JwtExpireDays { get; set; }
        public string JwtIssuer { get; set; } = String.Empty;
    }
}

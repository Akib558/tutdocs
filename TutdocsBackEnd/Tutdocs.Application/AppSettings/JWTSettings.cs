namespace Tutdocs.Application.AppSettings
{
    public class JWTSettings
    {
        public string SecretKey { get; set; } = null!;
        public string Issuer { get; set; } = null!;
        public string Audience { get; set; } = null!;
        public string Subject { get; set; } = null!;
    }
}

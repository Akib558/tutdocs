namespace Tutdocs.Application.AppSettings
{
    public class MailSettings
    {
        public string EmailId { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Host { get; set; } = null!;
        public byte Port { get; set; }
        public bool EnableSsl { get; set; }
        public bool EnableMailService { get; set; }
    }
}

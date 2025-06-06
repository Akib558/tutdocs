using System.Text.Json;

namespace Tutdocs.Applications.CustomExceptions
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public dynamic? Errors { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}

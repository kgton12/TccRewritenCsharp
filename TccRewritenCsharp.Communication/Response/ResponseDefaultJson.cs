namespace TccRewritenCsharp.Communication.Response
{
    public class ResponseDefaultJson(string message, string status, int statusCode)
    {
        public string Message { get; set; } = message;
        public string Status { get; set; } = status;
        public int StatusCode { get; set; } = statusCode;
    }
}

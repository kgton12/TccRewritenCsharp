namespace TccRewritenCsharp.Communication.Response
{
    public class ResponseIdJson(string message, string status, int statusCode) : ResponseDefaultJson(message, status, statusCode)
    {
        public Guid Id { get; set; }
    }
}

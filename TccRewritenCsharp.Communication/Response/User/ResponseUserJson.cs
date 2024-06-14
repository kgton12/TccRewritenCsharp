namespace TccRewritenCsharp.Communication.Response.User
{
    public class ResponseUserJson(string message, string status, int statusCode) : ResponseDefaultJson(message, status, statusCode)
    {
        public UserJson? User { get; set; }
    }
}

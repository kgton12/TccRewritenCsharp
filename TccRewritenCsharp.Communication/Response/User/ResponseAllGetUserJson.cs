namespace TccRewritenCsharp.Communication.Response.User
{
    public class ResponseAllGetUserJson(string message, string status, int statusCode) : ResponseDefaultJson(message, status, statusCode)
    {
        public List<UserJson> Users { get; set; } = [];
    }
}

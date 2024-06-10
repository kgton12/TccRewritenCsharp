namespace TccRewritenCsharp.Communication.Response.User
{
    public class ResponseAllGetUserJson
    {
        public string Status { get; set; } = string.Empty;
        public List<ResponseGetUserJson> Users { get; set; } = [];
    }
}

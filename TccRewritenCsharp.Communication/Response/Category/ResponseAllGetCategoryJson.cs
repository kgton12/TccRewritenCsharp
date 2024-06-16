namespace TccRewritenCsharp.Communication.Response.Category
{
    public class ResponseAllGetCategoryJson(string message, string status, int statusCode) : ResponseDefaultJson(message, status, statusCode)
    {
        public List<CategoryJson> Category { get; set; } = [];
    }
}

namespace TccRewritenCsharp.Communication.Response.Category
{
    public class ResponseCategoryJson(string message, string status, int statusCode) : ResponseDefaultJson(message, status, statusCode)
    {
        public CategoryJson? Category { get; set; }
    }
}

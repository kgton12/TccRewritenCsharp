namespace TccRewritenCsharp.Communication.Requests
{
    public class RequestUserJson
    {
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Admin { get; set; }
        public string Telephone { get; set; } = string.Empty;
    }
}

namespace TccRewritenCsharp.Communication.Response.User
{
    public class ResponseOrderUserJson
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Admin { get; set; }
        public string Telephone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
    }
}

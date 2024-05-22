using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TccRewritenCsharp.Communication.Response
{
    public class ResponseGetUserJson
    {
        public Guid Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Login { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public bool Admin { get; set; }
        public string Telephone { get; set; } = string.Empty;
    }
}

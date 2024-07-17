using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.DTOs
{
    public class UserRequest
    {      
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public long? Phonenumber { get; set; }
        public string? Password { get; set; }

    }
}

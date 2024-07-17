using System;
using System.Collections.Generic;

namespace RepositoryLayer.Entity
{
    public partial class User
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public int? Phonenumber { get; set; }
        public string? Password { get; set; }
    }
}

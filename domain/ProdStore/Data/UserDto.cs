using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProdStore.Data
{
    public class UserDto
    {
        public int Id { get; set; }
        
        public string Email { get; set; }
        public string Password { get; set; }
        public int? RoleId { get; set; }
        public RoleDto Role { get; set; }
    }
}

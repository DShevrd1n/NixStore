using System;
using System.Collections.Generic;
using System.Text;

namespace ProdStore.Data
{
   public class RoleDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<UserDto> Users { get; set; }
        public RoleDto()
        {
            Users = new List<UserDto>();
        }
    }
}

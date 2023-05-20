
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UserRoles
    {
        public int UserRolesId { get; set; }


        [ForeignKey("User")]
        public int UserId { get; set; }


        [ForeignKey("Role")]

        public int RoleId { get; set; }



        public User User { get; set; }

        public Role Role { get; set; }
    }
}

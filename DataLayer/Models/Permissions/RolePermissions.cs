using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class RolePermissions
    {
        [Key]
        public int RolePermissionsId { get; set; }

        public int RoleId { get; set; }

        public int PermissionId { get; set; }

        [ForeignKey("RoleId")]
        public Role Role { get; set; }


        [ForeignKey("PermissionId")]

        public Permission Permission { get; set; }

    }
}

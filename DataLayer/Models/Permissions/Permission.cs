using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Permission
    {
        [Key]
        public int PermissionId { get; set; }

        [Display(Name ="نام دسترسی")]
        [Required(ErrorMessage ="لطفا نام را وارد کنید")]
        [MaxLength(100)]
        public string PermissionTitle { get; set; }

       

      

        public List<RolePermissions> RolePermissions { get; set; }

    }
}

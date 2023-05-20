using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }


        [Display(Name = "نام نقش")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(20)]
        public string Name { get; set; }


        public List<UserRoles> UserRoles { get; set; }

        public List<RolePermissions> RolePermissions { get; set; }
    }
}

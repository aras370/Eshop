using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Category
    {

        [Key]
        public int CategoryId { get; set; }

        [Display(Name = "دسته بندی")]
        [Required(ErrorMessage = "لطفا{0} را وارد کنید")]
        [MaxLength(20)]
        public string Name { get; set; }


        public List<Product> Products { get; set; }
    }
}

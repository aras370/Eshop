using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }


        [ForeignKey("Order")]
        [Display(Name = "شماره سفارش")]
        public int OrderId { get; set; }


        [Display(Name = "محصول")]
        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [Display(Name = "تعداد")]
        public int Count { get; set; }

        [Display(Name = "قیمت")]
        public int Price { get; set; }


        public Order Order { get; set; }    

        public Product Product { get; set; }
    }
}

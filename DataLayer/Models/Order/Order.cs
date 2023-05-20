using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }


        [ForeignKey("User")]

        public int UserId { get; set; }


        public DateTime CreationDate { get; set; }


        public bool IsFinal { get; set; }


        #region Relations

        public User User { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        #endregion
    }
}

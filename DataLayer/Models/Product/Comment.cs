using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }


        [ForeignKey("Product")]

        public int ProductId { get; set; }

        [Display(Name ="نظر")]
        [Required(ErrorMessage ="لطفا نظر خود را وارد کنید")]
        [MaxLength(300)]
        public string  CommentText { get; set; }


        
        public DateTime DateTime { get; set; }


        #region Relations

        public User User { get; set; }

        public Product Product { get; set; }

        #endregion

    }
}

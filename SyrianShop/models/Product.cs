using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SyrianShop.models
{
    public class Product
    {

        public Product()
        {
            this.CreationDate = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public String Title { get; set; }

        public String Description { get; set; }

        public long Price { get; set; }

        public int Quantity { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}

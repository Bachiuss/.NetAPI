using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Order
    {
        [Key]
        [Description("Unique identifier for the order")]
        public int Id { get; set; }

        [Description("Name of the product in the order")]
        public string Product { get; set; }

        [Description("Price of the product in the order.")]
        public decimal Price { get; set; }

        [Description("Identifier indicating the customer who placed the order")]
        public int CustomerId { get; set; }
    }
}

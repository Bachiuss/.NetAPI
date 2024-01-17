using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Domain
{
    public class Customer
    {
        [Key]
        [Description("Unique identifier for the customer")]

        public int Id { get; set; }
        [Description("Name of the customer")]

        public string Name { get; set; }
        [Description("Email address of the customer.")]
        public string Email { get; set; }
    }
}

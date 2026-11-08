using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example_database.Models.CodeFirst
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }

        public int RentalId { get; set; }
        [ForeignKey("RentalId")]
        public Rental Rental { get; set; }
    }
}

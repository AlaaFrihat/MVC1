using System.ComponentModel.DataAnnotations;

namespace Example_database.Models.CodeFirst
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public List<Rental> Rentals { get; set; }
    }
}

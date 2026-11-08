using Example_database.Models.DBFirst;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Example_database.Models.CodeFirst
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string ModelName { get; set; }
        public decimal DailyRate { get; set; }

        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        public List<Rental> Rentals { get; set; }
    }
}

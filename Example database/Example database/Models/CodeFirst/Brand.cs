using System.ComponentModel.DataAnnotations;

namespace Example_database.Models.CodeFirst
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}

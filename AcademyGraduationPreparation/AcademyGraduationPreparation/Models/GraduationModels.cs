using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcademyGraduationPreparation.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Supplier> Suppliers { get; set; }
    }

  
    public class Supplier
    {
       
        public int Id { get; set; }
        public string Name { get; set; }

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        public List<Offer> Offers { get; set; }
    }

    public class Offer
    {
        public int Id { get; set; }
        public string OfferName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public int SupplierId { get; set; }
     
        public Supplier Supplier { get; set; }
    }
}


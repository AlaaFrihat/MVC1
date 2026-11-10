using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity; 
namespace Task3.Models
{
    public class SupplyRequest
    {
        [Key]
        public int Id { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public decimal TotalPrice { get; set; }

        public string Status { get; set; } = "Pending";

        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public List<RequestItem> RequestItems { get; set; }
    }
}

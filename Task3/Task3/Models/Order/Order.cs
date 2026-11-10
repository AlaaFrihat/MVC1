using System;
using System.ComponentModel.DataAnnotations;

namespace Task3.Models
{
    public class Order
    {
     
        public int Id { get; set; }

       
        public string CustomerName { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }
    }
}
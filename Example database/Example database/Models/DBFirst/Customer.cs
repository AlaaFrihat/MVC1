using System;
using System.Collections.Generic;

namespace Example_database.Models.DBFirst;

public partial class Customer
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public string? PhoneNumber { get; set; }

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}

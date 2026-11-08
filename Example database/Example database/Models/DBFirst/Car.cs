using System;
using System.Collections.Generic;

namespace Example_database.Models.DBFirst;

public partial class Car
{
    public int Id { get; set; }

    public string ModelName { get; set; } = null!;

    public decimal DailyRate { get; set; }

    public int BrandId { get; set; }

    public virtual Brand Brand { get; set; } = null!;

    public virtual ICollection<Rental> Rentals { get; set; } = new List<Rental>();
}

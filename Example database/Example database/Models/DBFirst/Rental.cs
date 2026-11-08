using System;
using System.Collections.Generic;

namespace Example_database.Models.DBFirst;

public partial class Rental
{
    public int Id { get; set; }

    public DateTime? RentDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public int CustomerId { get; set; }

    public int CarId { get; set; }

    public virtual Car Car { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}

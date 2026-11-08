using System;
using System.Collections.Generic;

namespace Example_database.Models.DBFirst;

public partial class Payment
{
    public int Id { get; set; }

    public decimal Amount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public int RentalId { get; set; }

    public virtual Rental Rental { get; set; } = null!;
}

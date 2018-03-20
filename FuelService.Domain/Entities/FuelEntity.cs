using System;

namespace FuelService.Domain.Entities
{
    public class FuelEntity : BaseEntity
    {
        public DateTime Date { get; set; }
        public Decimal Price { get; set; }
    }
}

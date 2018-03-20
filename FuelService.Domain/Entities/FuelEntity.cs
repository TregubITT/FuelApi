using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuelService.Domain.Entities
{
    public class FuelEntity : BaseEntity
    {
        public DateTime Date { get; set; }
        public Decimal Price { get; set; }
    }
}

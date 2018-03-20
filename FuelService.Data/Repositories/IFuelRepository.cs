using FuelService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelService.Data.Repositories
{
    public interface IFuelRepository
    {
        void BulkCreate(IEnumerable<FuelEntity> fuelList);
        IEnumerable<FuelEntity> RetriveAllIntersections(IEnumerable<DateTime> dateList);
    }
}

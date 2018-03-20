using FuelService.Data.Contexts;
using FuelService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelService.Data.Repositories
{
    public class FuelRepository : IFuelRepository
    {
        private readonly DataContext _context;

        public FuelRepository(DataContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void BulkCreate(IEnumerable<FuelEntity> fuelList)
        {
            _context.FuelList.AddRange(fuelList);
            _context.SaveChanges();
        }     
        
        public IEnumerable<FuelEntity> RetriveAllIntersections(IEnumerable<DateTime> dateList)
        {
            var result = from fuel in _context.FuelList
                         join data in dateList
                         on fuel.Date equals data
                         select fuel;            

            return result.ToList();
        }
    }
}

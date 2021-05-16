using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Data.Models;

namespace Test.Data.Repositories
{
    public class MeasurementPointRepository : IMeasurementPointRepository
    {
        private DataContext _context;
        public MeasurementPointRepository(DataContext context)
        {
            _context = context;
        }
        public IQueryable<MeasurementPoint> GetMeasurementPoints()
        {
            return _context.MeasurementPoints;
        }
    }
}

using System;
using Test.Data;
using Test.Data.Models;
using System.Linq;

namespace Test.Data.Repositories
{
	public class MeasurementRepository: IMeasurementRepository
	{
		private DataContext _context;
		public MeasurementRepository(DataContext context)
		{
			_context = context;
		}

		public IQueryable<Measurement> GetMeasurements(DateTime startDate, DateTime endDate, string jsn = null, int? shopId = null, int? measurementPointId = null)
        {
			var result = _context.Measurements.Join(_context.Vehicles, m => m.VehicleId, v => v.VehicleId, (m, v) => m.SetVehicle(v))
				.Join(_context.MeasurementPoints, m => m.MeasurementPointId, mp => mp.MeasurementPointId, (m, mp) => m.SetMeasurementPoint(mp));
			return result;
        }
	}
}

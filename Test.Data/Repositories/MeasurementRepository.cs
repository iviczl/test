using System;
using Test.Data;
using Test.Data.Models;
using System.Linq;
using System.Collections.Generic;

namespace Test.Data.Repositories
{
	public class MeasurementRepository: IMeasurementRepository
	{
		private DataContext _context;
        private IList<Measurement> _queryable;
		public MeasurementRepository(DataContext context)
		{
			_context = context;
            _queryable = _context.Measurements.Join(_context.Vehicles, m => m.VehicleId, v => v.VehicleId, (m, v) => m.SetVehicle(v))
                .Join(_context.MeasurementPoints, m => m.MeasurementPointId, mp => mp.MeasurementPointId, (m, mp) => m.SetMeasurementPoint(mp)).ToList();
        }

        public Measurement GetMeasurement(int measurementId)
        {
            return _queryable.FirstOrDefault(m => m.Id == measurementId);
        }

        public List<Measurement> GetMeasurements(DateTime startDate, DateTime endDate, string jsn = null, int? shopId = null, int? measurementPointId = null)
        {
			var queryable = _queryable.Where(m => m.Date >= startDate && m.Date <= endDate);
			if(jsn != null)
            {
				queryable = queryable.Where(m => m.Vehicle.Jsn == jsn);
            }
			if(shopId != null)
            {
				queryable = queryable.Where(m => m.ShopId == shopId);
            }
			if(measurementPointId != null)
            {
				queryable = queryable.Where(m => m.MeasurementPointId == measurementPointId);
            }

			return queryable.ToList();
        }

        public bool RemoveMeasurement(int measurementId)
        {
            var item = _context.Measurements.FirstOrDefault(m => m.Id == measurementId);
            if(item == null)
            {
                return false;
            }
            _context.Measurements.Remove(item);
            return true;
        }

        public bool UpdateMeasurement(Measurement measurement)
        {
            var item = _context.Measurements.FirstOrDefault(m => m.Id == measurement.Id);
            if (item == null)
            {
                return false;
            }
            item.MeasurementPointId = measurement.MeasurementPointId;
            item.ShopId = measurement.ShopId;
            item.VehicleId = measurement.VehicleId;
            item.Date = measurement.Date;
            item.Gap = measurement.Gap;
            item.Flush = measurement.Flush;
            return true;
        }
    }
}

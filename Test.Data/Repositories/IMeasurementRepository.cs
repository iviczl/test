using System;
using Test.Data.Models;
using System.Linq;
using System.Collections.Generic;

namespace Test.Data.Repositories
{
	public interface IMeasurementRepository
	{
		IQueryable<Measurement> GetMeasurements(DateTime startDate, DateTime endDate, string jsn = null, int? shopId = null, int? measurementPointId = null);

		Measurement GetMeasurement(int measurementId);

		bool UpdateMeasurement(Measurement measurement);

		bool RemoveMeasurement(int measurementId);
	}
}

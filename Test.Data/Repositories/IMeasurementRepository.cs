using System;
using Test.Data.Models;
using System.Linq;

namespace Test.Data.Repositories
{
	public interface IMeasurementRepository
	{
		IQueryable<Measurement> GetMeasurements(DateTime startDate, DateTime endDate, string jsn = null, int? shopId = null, int? measurementPointId = null);
	}
}

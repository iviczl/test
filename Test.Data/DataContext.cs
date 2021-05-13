using System;
using System.Collections.Generic;
using Test.Data.Models;
using System.Linq;

namespace Test.Data
{
	public class DataContext
	{
		private List<Vehicle> _vehicles { get; set; }
		private List<MeasurementPoint> _measurementPoints { get; set; }
		private List<Shop> _shops { get; set; }

		public DataContext()
		{

		}

		public IQueryable<Vehicle> Vehicles { get; set; }
		public IQueryable<MeasurementPoint> MeasurementPoints { get; set; }
		public IQueryable<Shop> Shops { get; set; }
	}
}
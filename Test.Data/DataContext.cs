using System;
using System.Collections.Generic;
using Test.Data.Models;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.IO;

namespace Test.Data
{
	public class DataContext
	{
        private List<Vehicle> _vehicles { get; set; }
		private List<MeasurementPoint> _measurementPoints { get; set; }
		private List<Shop> _shops { get; set; }
		private List<Measurement> _measurements { get; set; }

		public DataContext()
		{
			string vehiclesPath = null;
			var vehiclesJson = JArray.Parse(File.ReadAllText(vehiclesPath));
            string measurementPointPath = null;
            var measurementPointJson = JArray.Parse(File.ReadAllText(measurementPointPath));
            string shopPath = null;
            var shopJson = JArray.Parse(File.ReadAllText(shopPath));
            string measurementPath = null;
            var measurementJson = JArray.Parse(File.ReadAllText(measurementPath));

		}

		public IQueryable<Vehicle> Vehicles { get; set; }
		public IQueryable<MeasurementPoint> MeasurementPoints { get; set; }
		public IQueryable<Shop> Shops { get; set; }
		public IQueryable<Measurement> Measurements { get; set; }
	}
}
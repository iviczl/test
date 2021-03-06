using System;
using System.Collections.Generic;
using Test.Data.Models;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.IO;
using Newtonsoft.Json;

namespace Test.Data
{
	public class DataContext
	{
        private List<Vehicle> _vehicles { get; set; }
        private List<MeasurementPoint> _measurementPoints { get; set; }
        private List<Shop> _shops { get; set; }
        private List<Measurement> _measurements { get; set; }

        public DataContext(string path)
		{
			var vehiclesJson = JArray.Parse(File.ReadAllText(path + @"\vehicle.json"));
			_vehicles = vehiclesJson.Select(v => JsonConvert.DeserializeObject<Vehicle>(v.ToString())).ToList();
            var measurementPointJson = JArray.Parse(File.ReadAllText(path + @"\measurementPoint.json"));
			_measurementPoints = measurementPointJson.Select(mp => JsonConvert.DeserializeObject<MeasurementPoint>(mp.ToString())).ToList();
            var shopJson = JArray.Parse(File.ReadAllText(path + @"\shop.json"));
			_shops = shopJson.Select(s => JsonConvert.DeserializeObject<Shop>(s.ToString())).ToList();
            var measurementJson = JArray.Parse(File.ReadAllText(path + @"\measurement.json"));
			_measurements = measurementJson.Select(m => JsonConvert.DeserializeObject<Measurement>(m.ToString())).ToList();
		}

        public IQueryable<Vehicle> Vehicles => _vehicles.AsQueryable();
        public IQueryable<MeasurementPoint> MeasurementPoints => _measurementPoints.AsQueryable();
        public IQueryable<Shop> Shops => _shops.AsQueryable();
        public IQueryable<Measurement> Measurements => _measurements.AsQueryable();
		public bool MeasurementRemove(int measurementId)
        {
            var item = _measurements.FirstOrDefault(m => m.Id == measurementId);
            if (item == null)
            {
                return false;
            }
            _measurements.Remove(item);
            return true;
        }
	}
}
using System;
using System.Collections.Generic;
using System.Text;
using Test.Data.Models;

namespace Test.Services.Responses
{
    public class MeasurementItem
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal? Gap { get; set; }
        public decimal? Flush { get; set; }
        public string Jsn { get; set; }
        public int VehicleId { get; set; }
        public string VehicleModel { get; set; }
        public int ShopId { get; set; }
        public string ShopName { get; set; }
        public int MeasurementPointId { get; set; }
        public string MeasurementPointName{ get; set; }

        public static implicit operator MeasurementItem(Measurement measurement)
        {
            return new MeasurementItem
            {
                Id = measurement.Id,
                MeasurementPointId = measurement.MeasurementPointId,
                MeasurementPointName = measurement.MeasurementPoint.Name,
                ShopId = measurement.ShopId,
                ShopName = measurement.Shop.Name,
                VehicleId = measurement.VehicleId,
                VehicleModel = measurement.Vehicle.VehicleModel,
                Jsn = measurement.Vehicle.Jsn,
                Date = measurement.Date,
                Flush = measurement.Flush,
                Gap = measurement.Gap
            };
        }
    }
}

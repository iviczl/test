using System;
namespace Test.Data.Models
{
    /// <summary>
    /// Summary description for Class1
    /// </summary>
    public class Measurement
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public int ShopId { get; set; }
        public int MeasurementPointId { get; set; }
        public DateTime Date { get; set; }
        public decimal Gap { get; set; }
        public decimal Flush { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual Shop Shop { get; set; }
        public virtual MeasurementPoint MeasurementPoint { get; set; }

    }

    public static class MeasurementHelper
    {
        public static Measurement SetVehicle(this Measurement measurement, Vehicle vehicle)
        {
            measurement.Vehicle = vehicle;
            return measurement;
        }

        public static Measurement SetShop(this Measurement measurement, Shop shop)
        {
            measurement.Shop = shop;
            return measurement;
        }

        public static Measurement SetMeasurementPoint(this Measurement measurement, MeasurementPoint measurementPoint)
        {
            measurement.MeasurementPoint = measurementPoint;
            return measurement;
        }
    }
}

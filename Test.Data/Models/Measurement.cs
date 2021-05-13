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
    }
}

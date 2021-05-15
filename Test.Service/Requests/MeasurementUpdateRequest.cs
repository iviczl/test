using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Service.Requests
{
    public class MeasurementUpdateRequest
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

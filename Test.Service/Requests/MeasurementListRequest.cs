using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Service.Requests
{
    public class MeasurementListRequest
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public string jsn { get; set; }
        public int? shopId { get; set; }
        public int? measurementPointId { get; set; }
    }
}

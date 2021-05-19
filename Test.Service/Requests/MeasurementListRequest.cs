using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Service.Requests
{
    public class MeasurementListRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Jsn { get; set; }
        public int? ShopId { get; set; }
        public int? MeasurementPointId { get; set; }
        public PaginationRequest Pagination { get; set; }
    }
}

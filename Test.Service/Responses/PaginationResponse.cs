using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Service.Responses
{
    public class PaginationResponse
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int TotalItemCount { get; set; }
        public string OrderBy { get; set; }
    }
}

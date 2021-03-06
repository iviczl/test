using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Service.Requests
{
    public class PaginationRequest
    {
        public int PageSize { get; set; }
        public int Page { get; set; }
        public int CurrentPage { get; set; }
        public int TotalItemCount { get; set; }
        public string OrderBy { get; set; }
    }
}

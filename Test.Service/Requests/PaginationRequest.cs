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
        public int CurrentPageSize { get; set; }
        public int TotalItemCount { get; set; }
        public int TotalPageCount { get; set; }
        public string OrderBy { get; set; }
    }
}

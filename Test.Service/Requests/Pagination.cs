using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Service.Requests
{
    public class Pagination<T, TKey>
    {
        public int PageLength { get; set; }
        public int RequestedPage { get; set; }
        public int CurrentPage { get; set; }
        public int CurrentPageLength { get; set; }
        public int TotalItemCount { get; set; }
        public int TotalPageCount { get; set; }
        public Func<T, TKey> OrderFunction { get; set; }
    }
}

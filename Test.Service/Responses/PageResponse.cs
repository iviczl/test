using System.Collections.Generic;

namespace Test.Service.Responses
{
    public class PageResponse<T> where T: class
    {
        public List<T> Data { get; set; }
        public PaginationResponse Pagination { get; set; }
    }
}

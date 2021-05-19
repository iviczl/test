using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Service.Requests;
using Test.Service.Responses;

namespace Test.Service.Services
{
    public class PaginationHandler<T, TKey>
    {
        public static List<T> GetPage(IQueryable<T> queryable, Pagination<T, TKey> pagination, out PaginationResponse paginationResponse)
        {
            var itemCount = queryable.Count();
            var wholePages = itemCount / pagination.PageLength;
            var chunkPage = itemCount % pagination.PageLength;
            var totalPages = wholePages + (chunkPage > 0 ? 1 : 0);
            var currentPage = pagination.RequestedPage <= totalPages ? pagination.RequestedPage : pagination.CurrentPage;
            var itemsToTake = currentPage == totalPages ? chunkPage : pagination.PageLength;
            paginationResponse = new PaginationResponse { Page = currentPage, PageSize = pagination.PageLength, TotalItemCount = itemCount };
            if(pagination.OrderFunction != null)
            {
                return queryable.OrderBy(pagination.OrderFunction).Skip((currentPage - 1) * pagination.PageLength).Take(pagination.PageLength).ToList();
            }
            return queryable.Skip((currentPage - 1) * pagination.PageLength).Take(itemsToTake).ToList();
        }
    }
}

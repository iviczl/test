using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Data.Models;

namespace Test.Data.Repositories
{
    public class ShopRepository : IShopRepository
    {
        private DataContext _context;

        public ShopRepository(DataContext context)
        {
            _context = context;
        }
        public IQueryable<Shop> GetShops()
        {
            return _context.Shops;
        }
    }
}

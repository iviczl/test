using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Data.Models;

namespace Test.Data.Repositories
{
    public interface IShopRepository
    {
        IQueryable<Shop> GetShops();
    }
}

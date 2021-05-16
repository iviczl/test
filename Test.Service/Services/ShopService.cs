using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Data.Models;
using Test.Data.Repositories;

namespace Test.Service.Services
{
    public class ShopService : IShopService
    {
        private IShopRepository _shopRepository;

        public ShopService(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }
        public List<Shop> GetShops()
        {
            return _shopRepository.GetShops().ToList();
        }
    }
}

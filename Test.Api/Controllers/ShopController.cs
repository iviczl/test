using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Data.Models;
using Test.Service.Services;

namespace Test.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private IShopService _shopService;

        public ShopController(IShopService shopService)
        {
            _shopService = shopService;
        }
        [HttpGet("list")]
        public IActionResult List()
        {
            List<Shop> result = null;
            try
            {
                result = _shopService.GetShops();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

            return Ok(result);
        }

    }
}

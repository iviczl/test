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
    public class MeasurementPointController : ControllerBase
    {
        private IMeasurementPointService _measurementPointService;

        public MeasurementPointController(IMeasurementPointService measurementPointService)
        {
            _measurementPointService = measurementPointService;
        }

        [HttpGet("list")]
        public IActionResult List()
        {
            List<MeasurementPoint> result = null;
            try
            {
                result = _measurementPointService.GetMeasurementPoints();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }

            return Ok(result);
        }
    }
}

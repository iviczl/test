using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Service;
using Test.Service.Requests;
using Test.Services.Responses;

namespace Test.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private IMeasurementService _measurementService;

        public MeasurementController(IMeasurementService measurementService)
        {
            _measurementService = measurementService;
        }

        [HttpPost("list")]
        public IActionResult List(MeasurementListRequest request)
        {
            List<MeasurementItem> result = null;
            try
            {
                result = _measurementService.GetMeasurementList(request);
            }
            catch(Exception ex)
            {
                BadRequest(ex);
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Item(int id)
        {
            MeasurementItem item = null;
            try
            {
                item = _measurementService.GetMeasurement(id);
            }
            catch(Exception ex)
            {
                BadRequest(ex);
            }
            return Ok(item);
        }
    }
}

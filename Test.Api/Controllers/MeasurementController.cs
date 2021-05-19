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
            try
            {
                return Ok(_measurementService.GetMeasurementList(request));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
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
                return StatusCode(500, ex);
            }
            return Ok(item);
        }

        [HttpPost("update")]
        public IActionResult Update(MeasurementUpdateRequest request)
        {
            bool result;
            try
            {
                result = _measurementService.UpdateMeasurement(request);
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex);
            }
            return Ok(result);
        }

        [HttpPost("remove")]
        public IActionResult Remove(int measurementId)
        {
            bool result;
            try
            {
                result = _measurementService.RemoveMeasurement(measurementId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
            return Ok(result);
        }
    }
}

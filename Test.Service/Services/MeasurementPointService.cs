using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Data.Models;
using Test.Data.Repositories;

namespace Test.Service.Services
{
    public class MeasurementPointService : IMeasurementPointService
    {
        private IMeasurementPointRepository _measurementPointRepository;

        public MeasurementPointService(IMeasurementPointRepository measurementPointRepository)
        {
            _measurementPointRepository = measurementPointRepository;
        }
        public List<MeasurementPoint> GetMeasurementPoints()
        {
            return _measurementPointRepository.GetMeasurementPoints().ToList();
        }
    }
}

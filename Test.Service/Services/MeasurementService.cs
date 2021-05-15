using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Data.Models;
using Test.Data.Repositories;
using Test.Service.Requests;
using Test.Services.Responses;

namespace Test.Service.Services
{
    public class MeasurementService : IMeasurementService
    {
        private IMeasurementRepository _measurementRepository;

        public MeasurementService(IMeasurementRepository measurementRepository)
        {
            _measurementRepository = measurementRepository;
        }
        public MeasurementItem GetMeasurement(int measurementId)
        {
            return _measurementRepository.GetMeasurement(measurementId);
        }

        public List<MeasurementItem> GetMeasurementList(MeasurementListRequest request)
        {
            return _measurementRepository.GetMeasurements(request.startDate, request.endDate, request.jsn, request.shopId, request.measurementPointId).Select(m => (MeasurementItem) m).ToList();
        }

        public bool RemoveMeasurement(int measurementId)
        {
            return _measurementRepository.RemoveMeasurement(measurementId);
        }

        public bool UpdateMeasurement(MeasurementUpdateRequest request)
        {
            return _measurementRepository.UpdateMeasurement(new Measurement
            { 
                Id = request.Id, 
                MeasurementPointId = request.MeasurementPointId,
                ShopId = request.ShopId,
                VehicleId = request.VehicleId,
                Date = request.Date,
                Flush = request.Flush,
                Gap = request.Gap
            });
        }
    }
}

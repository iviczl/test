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
    public class MeasurementService : PaginationHandler<MeasurementItem, int>, IMeasurementService
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
            var queryable = _measurementRepository.GetMeasurements(request.StartDate, request.EndDate, request.Jsn, request.ShopId, request.MeasurementPointId).Select(m => (MeasurementItem)m);
            if(request.Pagination != null)
            {
                return GetPage(queryable,
                    new Pagination<MeasurementItem, int>
                    {
                        CurrentPage = request.Pagination.CurrentPage,
                        PageLength = request.Pagination.PageLength,
                        RequestedPage = request.Pagination.RequestedPage,
                        OrderFunction  = Order
                    }); 
            }
            return queryable.ToList();
        }

        private int Order(MeasurementItem measurementItem)
        {
            return measurementItem.Id;
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

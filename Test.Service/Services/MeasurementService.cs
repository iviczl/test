using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Data.Models;
using Test.Data.Repositories;
using Test.Service.Requests;
using Test.Service.Responses;
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

        public PageResponse<MeasurementItem> GetMeasurementList(MeasurementListRequest request)
        {
            PageResponse<MeasurementItem> response = new PageResponse<MeasurementItem>();
            var queryable = _measurementRepository.GetMeasurements(request.Query.StartDate, request.Query.EndDate, request.Query.Jsn, request.Query.ShopId, request.Query.MeasurementPointId).Select(m => (MeasurementItem)m);
            if(request.Pagination != null)
            {
                Func<MeasurementItem, int> orderFunction = null;
                if(request.Pagination.OrderBy == "id")
                {
                    orderFunction = OrderById;
                }
                PaginationResponse paginationResponse;
                response.Data = GetPage(queryable,
                    new Pagination<MeasurementItem, int>
                    {
                        CurrentPage = request.Pagination.CurrentPage,
                        PageLength = request.Pagination.PageSize,
                        RequestedPage = request.Pagination.Page,
                        OrderFunction  = orderFunction
                    }, out paginationResponse);
                response.Pagination = paginationResponse;
                response.Pagination.OrderBy = request.Pagination.OrderBy;
                return response;
            }
            response.Data = queryable.ToList();
            return response;
        }

        private int OrderById(MeasurementItem measurementItem)
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

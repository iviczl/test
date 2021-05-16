﻿using System;
using System.Collections.Generic;
using System.Text;
using Test.Data;
using Test.Data.Repositories;
using Test.Service.Requests;
using Test.Service.Services;
using Xunit;

namespace Test.UnitTest
{
    public class MeasurementServiceTest
    {
        private DataContext _context = new DataContext(@"c:\source\test\test.data\json");
        private MeasurementService _measurementService;

        public MeasurementServiceTest()
        {
            var measurementRepository = new MeasurementRepository(_context);
            _measurementService = new MeasurementService(measurementRepository);
        }

        [Fact]
        public void GetMeasurementItems()
        {
            var measurements = _measurementService.GetMeasurementList(new MeasurementListRequest { startDate = DateTime.Today.AddDays(-10000), endDate = DateTime.Today });
            Assert.True(measurements.Count == 1000); 
        }

        [Fact]
        public void GetMeasurementItem()
        {
            var measurement = _measurementService.GetMeasurement(32);
            Assert.NotNull(measurement);
        }

        [Fact]
        public void UpdateMeasurement()
        {
            var measurementItem = _measurementService.GetMeasurement(32);
            var measurement = _measurementService.UpdateMeasurement(
                new MeasurementUpdateRequest
                {
                    Id = measurementItem.Id,
                    MeasurementPointId = measurementItem.MeasurementPointId,
                    ShopId = measurementItem.ShopId,
                    VehicleId = measurementItem.VehicleId,
                    Date = measurementItem.Date,
                    Flush = measurementItem.Flush,
                    Gap = (decimal)1111.11
                });
            measurementItem = _measurementService.GetMeasurement(32);
            Assert.Equal(measurementItem.Gap, (decimal)1111.11);
        }

        [Fact]
        public void RemoveMeasurement()
        {
            var originalCount = _measurementService.GetMeasurementList(new MeasurementListRequest { startDate = DateTime.Today.AddDays(-10000), endDate = DateTime.Today }).Count;
            var success = _measurementService.RemoveMeasurement(44);
            var reducedCount = _measurementService.GetMeasurementList(new MeasurementListRequest { startDate = DateTime.Today.AddDays(-10000), endDate = DateTime.Today }).Count;
            Assert.True(originalCount == 1000);
            Assert.True(reducedCount == 999);
        }
    }
}
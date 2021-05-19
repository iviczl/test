using System;
using System.Collections.Generic;
using System.Text;
using Test.Service.Requests;
using Test.Service.Responses;
using Test.Services.Responses;

namespace Test.Service
{
    public interface IMeasurementService
    {
        PageResponse<MeasurementItem> GetMeasurementList(MeasurementListRequest request);
        MeasurementItem GetMeasurement(int measurementId);
        bool UpdateMeasurement(MeasurementUpdateRequest measurement);
        bool RemoveMeasurement(int measurementId);
    }
}

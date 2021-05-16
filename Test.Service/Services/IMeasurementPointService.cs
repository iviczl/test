using System;
using System.Collections.Generic;
using System.Text;
using Test.Data.Models;

namespace Test.Service.Services
{
    public interface IMeasurementPointService
    {
        List<MeasurementPoint> GetMeasurementPoints();
    }
}

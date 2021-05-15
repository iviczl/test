using System;
using System.Collections.Generic;
using System.Text;
using Test.Data;
using Xunit;

namespace Test.UnitTest
{
    public class MeasurementRepositoryTest
    {
        [Fact]
        public void GetMeasurementList()
        {
            var context = new DataContext(@"c:\source\test\test.data\json");
        }
    }
}

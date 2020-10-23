using ModelLayer;
using System;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IQuantityMeasurementService
    {
        List<String> getMainUnit();
        List<String> getSubUnits(string unit);
    }
}
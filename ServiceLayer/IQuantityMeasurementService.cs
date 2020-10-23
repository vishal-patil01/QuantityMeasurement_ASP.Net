using ModelLayer.DTO;
using System;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface IQuantityMeasurementService
    {
        List<String> getMainUnit();
        List<String> getSubUnits(string unit);
        public UnitResponseDTO getConvertedValue(UnitsConversionDTO unit);

    }
}
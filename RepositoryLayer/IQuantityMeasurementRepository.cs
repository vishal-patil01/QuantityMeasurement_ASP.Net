using ModelLayer;
using ModelLayer.DTO;
using System;
using System.Collections.Generic;

namespace RepositoryLayer
{
    public interface IQuantityMeasurementRepository
    {
        public List<String> getMainUnit();
        public List<String> getSubUnits(string unit);
        public UnitResponseDTO getConvertedValue(UnitsConversionDTO unit);
    }
}

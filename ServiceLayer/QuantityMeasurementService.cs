using ModelLayer.DTO;
using RepositoryLayer;
using System;
using System.Collections.Generic;

namespace ServiceLayer
{
    public class QuantityMeasurementService : IQuantityMeasurementService
    {
        IQuantityMeasurementRepository QuantityMeasurementRepository;
        public QuantityMeasurementService(IQuantityMeasurementRepository  quantityMeasurementRepository)
        {
            this.QuantityMeasurementRepository = quantityMeasurementRepository;
        }

        public List<String> getMainUnit()
        {
            return this.QuantityMeasurementRepository.getMainUnit();
        }

        public List<String> getSubUnits(string unit)
        {
            return this.QuantityMeasurementRepository.getSubUnits(unit);
        }

        public UnitResponseDTO getConvertedValue(UnitsConversionDTO unit)
        {
            return this.QuantityMeasurementRepository.getConvertedValue(unit);
        }
    }
}

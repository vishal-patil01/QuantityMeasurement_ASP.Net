using Microsoft.EntityFrameworkCore;
using ModelLayer;
using ModelLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepositoryLayer
{
    public class QuantityMeasurementRepository:IQuantityMeasurementRepository
    {
        QuantityMeasurementDBContext ApplicationDbContext;
        public QuantityMeasurementRepository(QuantityMeasurementDBContext quantityMeasurementDBContext) 
        {
            this.ApplicationDbContext = quantityMeasurementDBContext;
        }

        List<String> IQuantityMeasurementRepository.getMainUnit()
        {
            return ApplicationDbContext.MainUnits.Select(p => p.MainUnitName).ToList();
        }

        List<String> IQuantityMeasurementRepository.getSubUnits(string unit)
        {
            return ApplicationDbContext.MainUnits.
                Where(p => p.MainUnitName.Equals(unit.ToUpper()))
                .Select(A => A.SubUnits.Select(a => a.SubunitName))
                .ToList()
                .Cast<List<String>>()
                .First();
        }

        public UnitResponseDTO getConvertedValue(UnitsConversionDTO unit)
        {
            String firstMainUnit =ApplicationDbContext.Subunits.
                Where(p => p.SubunitName.Equals(unit.firstUnitType))
                .Select(a => a.MainUnits.MainUnitName).FirstOrDefault();
            String secondMainUnit = ApplicationDbContext.Subunits.
              Where(p => p.SubunitName.Equals(unit.secondUnitType))
              .Select(a => a.MainUnits.MainUnitName).FirstOrDefault();
            if (firstMainUnit!=null && secondMainUnit!=null && firstMainUnit.Equals(secondMainUnit))
            {
                var firstUnitValue = ApplicationDbContext.Subunits.
                   Where(p => p.SubunitName.Equals(unit.firstUnitType))
                   .Select(a => a.SubUnitsValue).FirstOrDefault();
                var SecondUnitValue =ApplicationDbContext.Subunits.
                   Where(p => p.SubunitName.Equals(unit.secondUnitType))
                   .Select(a => a.SubUnitsValue).FirstOrDefault();
                if (firstMainUnit == "Temperature" && secondMainUnit == "Temperature")
                {
                    if (unit.firstUnitType == "CELSIUS" && unit.secondUnitType == "FAHRENHEIT")
                    {
                        return new UnitResponseDTO((unit.value / firstUnitValue )+32, "Unit Converted Successfully", 200);
                    }
                    else if (unit.firstUnitType == "FAHRENHEIT" && unit.secondUnitType == "CELSIUS")
                    {
                        return new UnitResponseDTO((unit.value -32) / firstUnitValue, "Unit Converted Successfully", 200);
                    }
                }
                return new UnitResponseDTO(unit.value * firstUnitValue / SecondUnitValue, "Unit Converted Successfully", 200);
            }
            return new UnitResponseDTO(0,"INVALID UNITS",200);
        }
    }
}
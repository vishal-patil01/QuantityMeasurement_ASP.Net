using Microsoft.EntityFrameworkCore;
using ModelLayer;
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
                Where(p => p.MainUnitName.Equals(unit))
                .Select(A => A.SubUnits.Select(a => a.SubunitName))
                .ToList()
                .Cast<List<String>>()
                .First();
        }
    }
}
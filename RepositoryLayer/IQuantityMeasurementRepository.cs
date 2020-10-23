using ModelLayer;
using System;
using System.Collections.Generic;

namespace RepositoryLayer
{
    public interface IQuantityMeasurementRepository
    {
        public List<String> getMainUnit();
        public List<String> getSubUnits(string unit);
    }
}

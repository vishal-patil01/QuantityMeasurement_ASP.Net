using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.DTO
{
    public class UnitsConversionDTO
    {
        private Double value { get; set; }
        private Subunit firstUnitType { get; set; }
        private Subunit secondUnitType { get; set; }

        public UnitsConversionDTO(double value, Subunit firstUnitType, Subunit secondUnitType)
        {
            this.value = value;
            this.firstUnitType = firstUnitType;
            this.secondUnitType = secondUnitType;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer.DTO
{
    public class UnitsConversionDTO
    {
        [Required]
        public String firstUnitType { get; set; }
        [Required]
        public String secondUnitType { get; set; }
        public double value { get; set; }


        public UnitsConversionDTO(float value, String firstUnitType, String secondUnitType)
        {
            this.firstUnitType = firstUnitType;
            this.secondUnitType = secondUnitType;
            this.value = value;
        }
        public UnitsConversionDTO()
        {
        }
    }
}

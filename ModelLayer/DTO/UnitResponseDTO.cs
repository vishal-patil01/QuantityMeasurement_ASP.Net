using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.DTO
{
    public class UnitResponseDTO
    {
        public Object value { get; set; }
        public String message { get; set; }
        public int statusCode { get; set; }

        public UnitResponseDTO(double value, String message, int statusCode)
        {
            this.value = value;
            this.message = message;
            this.statusCode = statusCode;
        }
    }
}

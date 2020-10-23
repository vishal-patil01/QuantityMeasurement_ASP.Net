using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLayer.DTO
{
    public class UnitResponseDTO
    {
        private Object value { get; set; }
        private String message { get; set; }
        private int statusCode { get; set; }

        public UnitResponseDTO(double value, String message, int statusCode)
        {
            this.value = value;
            this.message = message;
            this.statusCode = statusCode;
        }
    }
}

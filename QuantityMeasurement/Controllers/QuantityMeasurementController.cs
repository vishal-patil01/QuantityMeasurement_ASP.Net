using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLayer;
using ModelLayer.DTO;
using ServiceLayer;

namespace QuantityMeasurement.Controllers
{
    [ApiController]
    [EnableCors("MyPolicy")]
    [Route("[controller]")]
    public class QuantityMeasurementController : ControllerBase
    {
        private readonly ILogger<QuantityMeasurementController> _logger;
        IQuantityMeasurementService quantityMeasurementService;

        public QuantityMeasurementController(ILogger<QuantityMeasurementController> logger, IQuantityMeasurementService  quantityMeasurementService)
        {
            _logger = logger;
            this.quantityMeasurementService = quantityMeasurementService;
        }

        [HttpGet]
        [Route("/unit/type")]
        public List<String> GetMainUnits()
        {
           return this.quantityMeasurementService.getMainUnit();
        }

        [HttpGet]
        [Route("/unit/type/{unit}")]
        public List<String> GetSubUnits(String unit)
        {
            return this.quantityMeasurementService.getSubUnits(unit);
        }

        [HttpPost]
        [Route("/unit/converter")]
        public UnitResponseDTO GetSubUnits([FromBody] UnitsConversionDTO unit)
        {
            return this.quantityMeasurementService.getConvertedValue(unit);
        }
    }
}

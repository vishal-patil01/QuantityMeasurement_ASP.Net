using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLayer;
using ServiceLayer;

namespace QuantityMeasurement.Controllers
{
    [ApiController]
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
    }
}

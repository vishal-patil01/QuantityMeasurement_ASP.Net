using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ModelLayer
{
    public class MainUnits
    {
        public int MainUnitsId { get; set; }

        [Column(TypeName = "varchar(200)"), MaxLength(50), Required]
        public String MainUnitName { get; set; }
        public List<Subunit> SubUnits { get; set; }
    }
}

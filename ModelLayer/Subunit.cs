using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelLayer
{
    public class Subunit
    {
        public int SubunitId { get; set; }
        public int MainUnitId{ get; set; }

        [ForeignKey("MainUnitId")]
        public MainUnits MainUnit { get; set; }

        [Column(TypeName = "varchar(200)"), MaxLength(50), Required]
        public String SubunitName { get; set; }

        [Required]
        public float SubUnitsValue { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APISalasEveris.Models
{
    public class Building
    {
        [Key]
        public int BuildingId { get; set; }
       
        public int OfficeId { get; set; }
        [ForeignKey("OfficeId")]
        public virtual Office Office { get; set; }

        public string BuildingName { get; set; }
        public string Street { get; set; }
        public int NumberOfStreet { get; set; }
    }
}

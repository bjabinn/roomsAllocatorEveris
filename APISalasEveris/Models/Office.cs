using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APISalasEveris.Models
{
    public class Office
    {
        [Key]
        public int OfficeId { get; set;}
        public string Alias { get; set; }
        public string OfficeName { get; set; }
    }
}

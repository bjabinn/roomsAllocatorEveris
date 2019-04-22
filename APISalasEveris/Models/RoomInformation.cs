using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APISalasEveris.Models
{
    public class RoomInformation
    {
        [Key]
        public int RoomId { get; set; }

        public int BuildingId { get; set; }
        [ForeignKey("BuildingId")]
        public virtual Building Building { get; set; }

        public string RoomName { get; set; }
        public int Floor { get; set; }
        public string NumRoom { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace APISalasEveris.Models
{
    public class RoomInformation
    {
        [Key]
        public int RoomId { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }
        public string NumRoom { get; set; }

    }
}

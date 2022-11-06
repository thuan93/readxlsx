using System.ComponentModel.DataAnnotations.Schema;

namespace MECEList.Entities.Models
{
    public class Datearrrib
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public short Year { get; set; }
        public short Month { get; set; }
        public short Day { get; set; }
        public string Attrib { get; set; }
        public int DatearrribId { get; set; }
    }
}

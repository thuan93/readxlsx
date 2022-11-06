using System.ComponentModel.DataAnnotations.Schema;

namespace MECEList.Entities.Models
{
    public class Attrib
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int AttribId { get; set; }
        public int Rootid { get; set; }
        public string Name { get; set; }
    }
}

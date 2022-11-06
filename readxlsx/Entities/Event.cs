using System.ComponentModel.DataAnnotations.Schema;

namespace MECEList.Entities.Models
{
    public partial class Event
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Name { get; set; }
        public int EventId { get; set; }
    }
}

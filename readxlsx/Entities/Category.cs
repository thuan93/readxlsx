using System.ComponentModel.DataAnnotations.Schema;

namespace MECEList.Entities.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Categoryid { get; set; }
        public string Name { get; set; }
        public int Rootid { get; set; }
    }
}

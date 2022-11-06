using System.ComponentModel.DataAnnotations.Schema;

namespace MECEList.Entities.Models
{
    public partial class Root
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int RootId { get; set; }

        public string RootName { get; set; }

        public Root() { }

        public Root(int rootId, string rootName)
        {
            RootId = rootId;
            RootName = rootName;
        }
    }
}

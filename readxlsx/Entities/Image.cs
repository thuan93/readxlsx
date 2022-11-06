using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MECEList.Entities.Models
{
    public class Image
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ItemId { get; set; }

        public string Title { get; set; }

        public DateTime Acquired { get; set; }

        public string Description { get; set; }

        public string Path { get; set; }

        public Image() { }

        public Image(int id, int itemId, string title, DateTime acquired, string description, string path)
        {
            Id = id;
            ItemId = itemId;
            Title = title;
            Acquired = acquired;
            Description = description;
            Path = path;
        }
    }
}

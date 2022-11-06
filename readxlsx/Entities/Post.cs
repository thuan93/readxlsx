using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MECEList.Entities.Models
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ListId { get; set; }

        public string ListName { get; set; }

        public DateTime PostedDateTime { get; set; }

        public Post() { }
    }
}

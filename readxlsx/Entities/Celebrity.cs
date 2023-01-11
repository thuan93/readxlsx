﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace MECEList.Entities.Models
{
    public partial class Celebrity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public string Name { get; set; }
        public int CelebrityId { get; set; }
    }
}

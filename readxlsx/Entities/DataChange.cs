using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MECEList.Entities.Models
{
    public class DataChange
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int DataChangeId { get; set; }
        public string TableName { get; set; }
        public string Process { get; set; }
        public int RecordId { get; set; }
        public DateTime ProcessDatetime { get; set; }
        public bool Processed { get; set; } = false;
    }
}

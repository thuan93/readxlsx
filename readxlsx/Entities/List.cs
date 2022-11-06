using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MECEList.Entities.Models
{
    public partial class List
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int ListId { get; set; }

        public string ListName { get; set; }

        public int RootId { get; set; }

        public bool HasDeadline { get; set; } = false;

        public bool IsMyList { get; set; } = false;

        public DateTime LastUpdated { get; set; } = DateTime.Now;

        public DateTime VersionDate { get; set; }

        public int Categoryid { get; set; }

        public string CategoryName { get; set; }

        public int SortOrder { get; set; }

        public bool IsEditting { get; set; } = false;

        public string Itemsrankname1 { get; set; }

        public string Itemsrankname2 { get; set; }

        public string Contributor { get; set; } = string.Empty;

        public List() { }

        public List(int listId, string listName, int rootId)
        {
            ListId = listId;
            ListName = listName;
            RootId = rootId;
            VersionDate = new DateTime(2021, 6, 13);    // この日を基準にサーバー側で更新されたか否かを判断する
        }
    }
}

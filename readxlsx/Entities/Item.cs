using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MECEList.Entities.Models
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string GUid { get; set; }

        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public int Attrib { get; set; }

        public bool Prepare { get; set; } = false;

        public bool Done { get; set; } = false;

        public bool HasDeadline { get; set; } = false;

        public DateTime Deadline { get; set; } = DateTime.Today;

        public DateTime DeadlineEnd { get; set; } = DateTime.Today;

        public bool IsFinished { get; set; }

        public int DisplayTiming { get; set; } = 14;

        // 追加 2021/9/18
        public bool IsEditting { get; set; }

        // カウントダウン定期イベントの場合、第nX曜日の数値が入る
        public string Info { get; set; }

        // カウントダウン定期イベントに対応
        public int Type { get; set; }

        public DateTime LastUpdated { get; set; }

        public int ListId { get; set; }

        public bool IsFromShareLink { get; set; }

        public bool IsCompleted { get; set; }

        public Item() {
            GUid = Guid.NewGuid().ToString("N");
        }

        public Item(int itemId, string itemName, int attrib, int listId)
        {
            GUid = Guid.NewGuid().ToString("N");
            ItemId = itemId;
            ItemName = itemName;
            Attrib = attrib;
            ListId = listId;
        }

        public Item(Item item)
        {
            GUid = Guid.NewGuid().ToString("N");
            Id = item.Id;
            ItemId = item.ItemId;
            ItemName = item.ItemName;
            Attrib = item.Attrib;
            Prepare = item.Prepare;
            Done = item.Done;
            HasDeadline = item.HasDeadline;
            Deadline = item.Deadline;
            DisplayTiming = item.DisplayTiming;
            ListId = item.ListId;
        }
    }
}

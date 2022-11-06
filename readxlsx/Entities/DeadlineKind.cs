using System.ComponentModel.DataAnnotations.Schema;

namespace MECEList.Entities.Models
{
    public class DeadlineKind
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int KindId { get; set; }

        public bool IsMustDeadline { get; set; }

        public bool IsGroupHeader { get; set; }

        public string GroupName { get; set; }

        public string KindName { get; set; }

        public string BackgroundColor { get; set; } 

        public DeadlineKind() { }

        public DeadlineKind(int kindId, bool isMustDeadline, bool isGroupHeader,string groupName, string kindName)
        {
            KindId = kindId;
            IsMustDeadline = isMustDeadline;
            IsGroupHeader = isGroupHeader;
            GroupName = groupName;
            KindName = kindName;
        }

        public DeadlineKind(DeadlineKind source)
        {
            Id = source.Id;
            KindId = source.KindId;
            IsMustDeadline = source.IsMustDeadline;
            IsGroupHeader = source.IsGroupHeader;
            GroupName = source.GroupName;
            KindName = source.KindName;
        }
    }
}

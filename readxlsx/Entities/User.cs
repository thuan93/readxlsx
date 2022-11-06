using System;
namespace MECEList.Entities.Models
{
    public class User
    {
        public int Id { get; set; }

        public string NickName { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Postcode { get; set; }
    }
}

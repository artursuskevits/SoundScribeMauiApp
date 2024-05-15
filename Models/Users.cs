using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundScribe.Models
{
    [Table("Users")]
    public class Users
    {
        [PrimaryKey,AutoIncrement,Column("_id")]
        public int Id { get; set; }
        [MaxLength(35)]
        public string Email { get; set; }
        [Unique, MaxLength(35)]
        public string Nickanme { get; set; }
        [MaxLength(65)]
        public string Password { get; set; }
        public string Reason { get; set; }
        public bool On_Admin { get; set; }
    }
}

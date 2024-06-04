using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundScribe.Models
{
    [Table("Songs")]
    public class Songs
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(35)]
        public string Artist { get; set; }
        [MaxLength(35)]
        public string Song_Name { get; set; }
        [MaxLength(999)]
        public string Image { get; set; }
        [MaxLength(999)]
        public string Mp3 { get; set; }
        public int Rhymes { get; set; }
        public int Structure { get; set; }
        public int Style_realization {get; set; }
        public int Individuality { get; set; }
        public int Atmosphere { get; set; }
        public int Trendiness { get; set; }
       
    }
}

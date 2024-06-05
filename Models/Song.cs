using System.ComponentModel;
using System.Runtime.CompilerServices;
using SQLite;

namespace SoundScribe.Models
{
    [Table("Songs")]
    public class Songs : INotifyPropertyChanged
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
        public string Link { get; set; }

        [MaxLength(999)]
        public string Mp3 { get; set; }

        public int Rhymes { get; set; }
        public int Structure { get; set; }
        public int Style_realization { get; set; }
        public int Individuality { get; set; }
        public int Atmosphere { get; set; }
        public int Trendiness { get; set; }

        private double _c;
        public double C
        {
            get => _c;
            set
            {
                _c = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

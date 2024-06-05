using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SoundScribe.ViewModels
{
    public class RatePageViewModel : INotifyPropertyChanged
    {
        private double _rhymes;
        private double _structure;
        private double _styleRealization;
        private double _individuality;
        private double _atmosphere;
        private double _trendiness;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public double Rhymes
        {
            get => _rhymes;
            set
            {
                if (_rhymes != value)
                {
                    _rhymes = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Structure
        {
            get => _structure;
            set
            {
                if (_structure != value)
                {
                    _structure = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Style_realization
        {
            get => _styleRealization;
            set
            {
                if (_styleRealization != value)
                {
                    _styleRealization = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Individuality
        {
            get => _individuality;
            set
            {
                if (_individuality != value)
                {
                    _individuality = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Atmosphere
        {
            get => _atmosphere;
            set
            {
                if (_atmosphere != value)
                {
                    _atmosphere = value;
                    OnPropertyChanged();
                }
            }
        }

        public double Trendiness
        {
            get => _trendiness;
            set
            {
                if (_trendiness != value)
                {
                    _trendiness = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}

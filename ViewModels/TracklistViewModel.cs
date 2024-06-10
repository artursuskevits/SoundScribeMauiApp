using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using SoundScribe.Models;

namespace SoundScribe.ViewModels
{
    public class TracklistViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Songs> _tracks;
        private SoundScribeReprisitory _repository;

        public ObservableCollection<Songs> Tracks
        {
            get { return _tracks; }
            set
            {
                _tracks = value;
                OnPropertyChanged();
            }
        }

        public TracklistViewModel()
        {
            // Initialize the repository with the database path
            string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "soundscribe.db3");
            _repository = new SoundScribeReprisitory(databasePath);

            // Load tracks from the repository
            LoadTracks();
        }

        private void LoadTracks()
        {
            // Simulating data for testing purposes
            Tracks = new ObservableCollection<Songs>
            {
                new Songs { Song_Name = "Song 1", Artist = "Artist 1", Image = "song1.png" },
                new Songs { Song_Name = "Song 2", Artist = "Artist 2", Image = "song2.png" }
            };

            // Uncomment the following lines to load from the repository
            // var songs = _repository.GetItemsSongs();
            // Tracks = new ObservableCollection<Songs>(songs);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

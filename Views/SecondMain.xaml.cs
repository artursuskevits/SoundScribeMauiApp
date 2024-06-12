using Microsoft.Maui.Controls;
using SoundScribe.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using System.Linq;

namespace SoundScribe.Views
{
    public partial class SecondMain : ContentPage
    {
        int conuter = 0;
        public ObservableCollection<Songs> Songs2 { get; set; }
        public ObservableCollection<Songs> Song { get; set; }
        public ObservableCollection<Songs> Last { get; set; }
        private SoundScribeReprisitory Database => App.Database;

        public SecondMain()
        {
            InitializeComponent();

            Songs2 = new ObservableCollection<Songs>(Database.GetSortedSongs());
            Song = new ObservableCollection<Songs>(Database.GetBestSong());
            Last = new ObservableCollection<Songs>(Database.GetLastSong());

            BindingContext = this;
        }


        private void OnSearchTextChanged(object sender, TextChangedEventArgs e)

        {
            conuter += 1;
            var entry = sender as Entry;
            if (conuter == 1)
            {
                entry.Text = string.Empty;
            }
            if (Database == null)
            {
                throw new Exception("Database is not initialized.");
            }

            string searchText = e.NewTextValue;

            try
            {
                var filteredSongs = Database.GetItemsSongs()
                    .Where(song => song.Song_Name != null && song.Song_Name.StartsWith(searchText, StringComparison.OrdinalIgnoreCase) ||
                                   song.Artist != null && song.Artist.StartsWith(searchText, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                Songs2.Clear();
                foreach (var song in filteredSongs)
                {
                    Songs2.Add(song);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred during search: " + ex.Message);
            }

        }

        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Songs selectedSong = (Songs)e.SelectedItem;
                RatePage NewTrackPage = new RatePage
                {
                    BindingContext = selectedSong
                };
                await Navigation.PushAsync(NewTrackPage);
            }
        }
    }
}

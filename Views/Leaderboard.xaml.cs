using SoundScribe.Models;
using System.Collections.ObjectModel;
namespace SoundScribe.Views;

public partial class Leaderboard : ContentPage
{
    public ObservableCollection<Songs> Songs2 { get; set; }

    public Leaderboard()
    {
        InitializeComponent();
        LoadSortedSongs();
        BindingContext = this;
    }

    private void LoadSortedSongs()
    {
        var sortedSongs = App.Database.GetSortedSongs();
        Songs2 = new ObservableCollection<Songs>(sortedSongs);
    }
    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            Songs selectedSong = (Songs)e.SelectedItem;
            RatePage newTrackPage = new RatePage
            {
                BindingContext = selectedSong
            };
            await Navigation.PushAsync(newTrackPage);
        }
    }
}


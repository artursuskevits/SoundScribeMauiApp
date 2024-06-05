using SoundScribe.Models;
using System.Collections.ObjectModel;
namespace SoundScribe.Views;

public partial class Leaderboard : ContentPage
{
    public ObservableCollection<Songs> Songs2 { get; set; }
    public Leaderboard()
	{
        InitializeComponent();
        Songs2 = new ObservableCollection<Songs>(App.Database.GetSortedSongs());
        BindingContext = this;
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
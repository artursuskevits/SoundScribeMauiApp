using SoundScribe.Models;

namespace SoundScribe.Views;

public partial class Tracklist : ContentPage
{
    public Tracklist()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        SongList.ItemsSource = App.Database.GetItemsSongs();
        base.OnAppearing();
    }

    private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            Songs selectedSong = (Songs)e.SelectedItem;
            Add_track NewTrackPage = new Add_track
            {
                BindingContext = selectedSong
            };
            await Navigation.PushAsync(NewTrackPage);
        }
    }
}

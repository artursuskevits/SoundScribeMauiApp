using SoundScribe.Models;
namespace SoundScribe.Views;

public partial class Leaderboard : ContentPage
{
	public Leaderboard()
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
        Songs selectedSong = (Songs)e.SelectedItem;
        Add_track NewTrackPage = new Add_track();
        NewTrackPage.BindingContext = selectedSong;
        await Navigation.PushAsync(NewTrackPage);
    }
}
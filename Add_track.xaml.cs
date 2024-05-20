using SoundScribe.Models;
namespace SoundScribe;

public partial class Add_track : ContentPage
{
    public Add_track()
    {
        InitializeComponent();
    }
    private void SaveFriend(object sender, EventArgs e)
    {
        var song = (Songs)BindingContext;
        if (!String.IsNullOrEmpty(song.Song_Name))
            App.Database.SaveItemSongs(song);
        this.Navigation.PopAsync();
    }
    private void DeleteFriend(object sender, EventArgs e)
    {
        var song = (Songs)BindingContext;
        App.Database.DeleteItemSongs(song.Id);
        this.Navigation.PopAsync();
    }
    private void Cancel(object sender, EventArgs e)
    {
        this.Navigation.PopAsync();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {

    }
}
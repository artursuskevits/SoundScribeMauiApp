using SoundScribe.Models;
using SoundScribe.ViewModels;
using System.ComponentModel;

namespace SoundScribe.Views;

public partial class RatePage : ContentPage
{
    public RatePage()
    {
        InitializeComponent();
        BindingContext = new RatePageViewModel();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var song = (Songs)BindingContext;
        if (!String.IsNullOrEmpty(song.Artist))
            App.Database.SaveItemSongs(song);
        this.Navigation.PopAsync();
    }

    private void Cancel(object sender, EventArgs e)
    {
        this.Navigation.PopAsync();
    }
}

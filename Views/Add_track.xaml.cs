using SoundScribe.Models;
using MediaManager;
namespace SoundScribe.Views;

public partial class Add_track : ContentPage
{
    string imagePath = null;
    string songPath = null;
    public Add_track()
    {
        InitializeComponent();
        BindingContext = new Songs();
    }


    private async void SaveFriend(object sender, EventArgs e)
    {
        try
        {

            var photo = await MediaPicker.PickPhotoAsync();
            if (photo != null)
            {
                imagePath = photo.FullPath;
                ImageSource vlad = ImageSource.FromFile(photo.FullPath);
            }


            var customFileType = new FilePickerFileType(new Dictionary<DevicePlatform, IEnumerable<string>>
        {
            { DevicePlatform.Android, new[] { "audio/*" } },
            { DevicePlatform.WinUI, new[] { ".mp3", ".wav", ".wma" } },
            { DevicePlatform.MacCatalyst, new[] { "public.audio" } },
        });

            var options = new PickOptions
            {
                PickerTitle = "Pick a song",
                FileTypes = customFileType
            };


            var songFile = await FilePicker.PickAsync(options);
            if (songFile != null)
            {
                songPath = songFile.FullPath;
            }
        }
        catch (Exception ex)
        {

        }

        var song = (Songs)BindingContext;
        if (!String.IsNullOrEmpty(song.Artist))
        {
            song.Image = imagePath;
            song.Mp3 = songPath;
        }
        App.Database.SaveItemSongs(song);
        await this.Navigation.PopAsync();
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
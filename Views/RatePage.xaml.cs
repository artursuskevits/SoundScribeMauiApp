using MediaManager;
using MediaManager.Playback;
using MediaManager.Library;
using SoundScribe.Models;
using SoundScribe.ViewModels;
using Microsoft.Maui.Dispatching;

namespace SoundScribe.Views
{
    public partial class RatePage : ContentPage
    {
        public RatePage()
        {
            InitializeComponent();
            BindingContext = new RatePageViewModel();
            string soundCloudTrackUrl = "https://soundcloud.com/artur-met/ya-inogda-tebya-byu?si=a3781a083b65486bbeda4fb351d1e5c9&utm_source=clipboard&utm_medium=text&utm_campaign=social_sharing";

            SoundCloudWebView.Source = soundCloudTrackUrl;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var song = (Songs)BindingContext;
            if (!String.IsNullOrEmpty(song.Artist))
            {
                App.Database.SaveItemSongs(song);
            }
            await this.Navigation.PopAsync();
        }

        private async void PlayButton_Clicked(object sender, EventArgs e)
        {
            var song = (Songs)BindingContext;
            if (!String.IsNullOrEmpty(song.Mp3))
            {
                await Dispatcher.DispatchAsync(async () =>
                {
                    await CrossMediaManager.Current.Play(song.Mp3);

                });
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}

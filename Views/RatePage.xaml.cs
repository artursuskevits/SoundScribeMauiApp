using MediaManager;
using MediaManager.Playback;
using MediaManager.Library;
using SoundScribe.Models;
using SoundScribe.ViewModels;
using Microsoft.Maui.Dispatching;
using System.Xml.Linq;

namespace SoundScribe.Views
{ Label RhymesValueLabel, StructureValueLabel, StyleRealizationValueLabel, IndividualityValueLabe, AtmosphereValueLabel, TrendinessValueLabel;
    public partial class RatePage : ContentPage
    {
        public RatePage()
        {
            InitializeComponent();
            BindingContext = new RatePageViewModel();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var song = (Songs)BindingContext;
            if (!string.IsNullOrEmpty(song.Artist))
            {
                App.Database.SaveItemSongs(song);
            }
            await Navigation.PopAsync();
        }

        private async void PlayButton_Clicked(object sender, EventArgs e)
        {
            //var song = (Songs)BindingContext;
            //if (!string.IsNullOrEmpty(song.Mp3))
            //{
            Task.Run(async () =>
            {
                await CrossMediaManager.Current.Play("https://audio.jukehost.co.uk/MzKUcBxYhbxdRC1Ob2NPABrzsvZ0y40Z");
            });
            //}
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Flyuot2());
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (true)
            {

            }


        }
    }
}



using MediaManager;
using MediaManager.Playback;
using MediaManager.Library;
using SoundScribe.Models;
using SoundScribe.ViewModels;
using Microsoft.Maui.Dispatching;
using System.Xml.Linq;

namespace SoundScribe.Views
{
    public partial class RatePage : ContentPage
    {
        public RatePage()
        {
            InitializeComponent();
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
            // Task.Run(async () =>
            //{
            //  await CrossMediaManager.Current.Play("https://audio.jukehost.co.uk/MzKUcBxYhbxdRC1Ob2NPABrzsvZ0y40Z");
            //});
            //}
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new Flyuot2());
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            
                var label = sender as Label;
                var slider = sender as Slider;
                if (slider == RhymesSlider)
                    RhymesLabel.Text = RhymesSlider.Value.ToString();
                else if (slider == StructureSlider) {
                StructureLabel.Text = StructureSlider.Value.ToString();
            }
            else if (slider == StyleRealizationSlider)
            {
                StyleRealizationLabel.Text = StyleRealizationSlider.Value.ToString();
            }
            else if (slider == IndividualitySlider)
            {
                IndividualityLabel.Text = IndividualitySlider.Value.ToString();
            }
            else if (slider == AtmosphereSlider)
            {
                AtmosphereLabel.Text = AtmosphereSlider.Value.ToString();
            }
            else if (slider == TrendinessSlider)
            {
                TrendinessLabel.Text = TrendinessSlider.Value.ToString();
            }


        }

    }
}



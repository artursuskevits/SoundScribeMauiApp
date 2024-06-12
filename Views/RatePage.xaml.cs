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
                double a = song.Rhymes + song.Structure + song.Style_realization + song.Individuality;
                double b = song.Atmosphere * 10 / 100;
                double c = song.Trendiness * 10 / 100;
                song.C = a + b + c;

                App.Database.SaveItemSongs(song);
            }
            this.Navigation.PushAsync(new Flyuot2());
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
            {
                int intvaluelabel = (int)Math.Round(RhymesSlider.Value);
                RhymesLabel.Text = intvaluelabel.ToString();
            }
            else if (slider == StructureSlider)
            {
                int intvaluelabel = (int)Math.Round(StructureSlider.Value);
                StructureLabel.Text = intvaluelabel.ToString();
            }
            else if (slider == StyleRealizationSlider)
            {
                int intvaluelabel = (int)Math.Round(StyleRealizationSlider.Value);
                StyleRealizationLabel.Text = intvaluelabel.ToString();
            }
            else if (slider == IndividualitySlider)
            {
                int intvaluelabel = (int)Math.Round(IndividualitySlider.Value);
                IndividualityLabel.Text = intvaluelabel.ToString();
            }
            else if (slider == AtmosphereSlider)
            {
                int intvaluelabel = (int)Math.Round(AtmosphereSlider.Value);
                AtmosphereLabel.Text = intvaluelabel.ToString();
            }
            else if (slider == TrendinessSlider)
            {
                int intvaluelabel = (int)Math.Round(TrendinessSlider.Value);
                TrendinessLabel.Text = intvaluelabel.ToString();
            }


        }

        private void Button_Clicked_1(object sender, EventArgs e) { 
         var song = (Songs)BindingContext;
        App.Database.DeleteItemSongs(song.Id);
this.Navigation.PopAsync();
        }
    }
}



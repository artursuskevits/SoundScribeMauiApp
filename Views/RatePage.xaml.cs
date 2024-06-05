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
            Navigation.PopAsync();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            if (sender is Slider slider)
            {
                var viewModel = BindingContext as RatePageViewModel;
                if (viewModel != null)
                {
                    if (slider == RhymesSlider)
                        viewModel.Rhymes = (int)e.NewValue;
                    else if (slider == StructureSlider)
                        viewModel.Structure = (int)e.NewValue;
                    else if (slider == StyleRealizationSlider)
                        viewModel.Style_realization = (int)e.NewValue;
                    else if (slider == IndividualitySlider)
                        viewModel.Individuality = (int)e.NewValue;
                    else if (slider == AtmosphereSlider)
                        viewModel.Atmosphere = (int)e.NewValue;
                    else if (slider == TrendinessSlider)
                        viewModel.Trendiness = (int)e.NewValue;
                }
            }
        }
    }
}

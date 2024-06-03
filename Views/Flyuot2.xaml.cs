using Microsoft.Maui.Controls;
using SoundScribe.Models;
namespace SoundScribe.Views;

    public partial class Flyuot2 : FlyoutPage
    {
        public Flyuot2()
        {
            InitializeComponent();
        }

    private void OnPage1Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Leaderboard());
            IsPresented = false;
        }

        private void OnPage2Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Tracklist());
            IsPresented = false;
        }
        private void OnPage3Clicked(object sender, EventArgs e)
        {
           
            Detail = new NavigationPage(new Add_track());
            IsPresented = false;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new Flyuot2());
            IsPresented = false;
        }
    }

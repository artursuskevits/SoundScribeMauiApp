using SoundScribe.Models;
using System.Collections.ObjectModel;
namespace SoundScribe.Views;

public partial class Leaderboard : ContentPage
{
    public ObservableCollection<Songs> Songs { get; set; }
    public Leaderboard()
	{
        InitializeComponent();
        Songs = new ObservableCollection<Songs>(App.Database.GetSortedSongs());
        BindingContext = this;
    }
    
 
}
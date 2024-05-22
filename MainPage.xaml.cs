using SoundScribe.Models;
namespace SoundScribe;

public partial class MainPage : ContentPage
{
    HorizontalStackLayout maincontent;
    StackLayout search, leaders, tracklist;
    Entry song_search;
    Label lbl_leaderboard;
    FlyoutItem burgermenu;
    Grid grid;

    public MainPage()
    {
        this.BackgroundImageSource = "church_1.png";

        grid = new Grid();

        Image backgroundImage = new Image
        {
            Source = ImageSource.FromFile("church_1.png"),
            Aspect = Aspect.AspectFill
        };

        // Add the background image to the grid, spanning the entire grid
        grid.Children.Add(backgroundImage);
        Grid.SetRowSpan(backgroundImage, 3);
        Grid.SetColumnSpan(backgroundImage, 2);

        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });

        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
        
        //==SEARCH===========================

        song_search = new Entry()
        {
            Text = "Found Song"
        };
        search = new StackLayout()
        {
            BackgroundColor = Color.FromRgb(160, 160, 160),
            Orientation = StackOrientation.Horizontal,
            Children = { song_search }
        };
        Grid.SetRow(search, 0);
        Grid.SetColumn(search, 1);

        //======LEADERS======================

        lbl_leaderboard = new Label()
        {
            Text = "LeaderBoard",
            FontSize= 26,
            TextColor = Color.FromRgb(255, 255, 255)
        };

        leaders = new StackLayout()
        {
            BackgroundColor = Color.FromRgb(43, 43, 43),
            Orientation = StackOrientation.Horizontal,
            Margin = new Thickness(5),
            Spacing = 6,
            Children = { lbl_leaderboard }
        };
        
        Grid.SetRow(leaders, 1);
        Grid.SetRowSpan(leaders, 1);
        Grid.SetColumn(leaders, 1);

        //=========TRACKLIST=================

        tracklist = new StackLayout() { BackgroundColor = Color.FromRgb(43, 43, 43) };
        Grid.SetRow(tracklist, 2);
        Grid.SetColumn(tracklist, 1);

        //=======BURGERMENU==================

        //burgermenu = new FlyoutItem
        //{
        //    Title = "Menu",
        //    FlyoutDisplayOptions = FlyoutDisplayOptions.AsSingleItem,
        //    Items =
        //        {
        //        }
        //};
        //Grid.SetRow(burgermenu, 0);
        //Grid.SetColumn(burgermenu, 0);
      


        grid.Children.Add(search);
        grid.Children.Add(leaders);
        grid.Children.Add(tracklist);
        //maincontent = new HorizontalStackLayout
        //{
        //    Background = ImageSource.FromFile("church_1.png"),
        //    //Children = {burgermenu}
        //};
        this.Content = grid;
    }


}


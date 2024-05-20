using SoundScribe.Models;
namespace SoundScribe;

public partial class MainPage : ContentPage
{
    HorizontalStackLayout maincontent;
    StackLayout search, leadesrs, tracklist;
    Entry song_search;
    FlyoutItem burgermenu;
    Grid grid;

    public MainPage()
    {
        grid = new Grid();
        grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(2, GridUnitType.Star) });

        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
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

        leadesrs = new StackLayout()
        {
            BackgroundColor = Color.FromRgb(0, 0, 0)
        };
        Grid.SetRow(leadesrs, 1);
        Grid.SetColumn(leadesrs, 1);

        tracklist = new StackLayout() { BackgroundColor = Color.FromRgb(160, 160, 160) };
        Grid.SetRow(tracklist, 2);
        Grid.SetColumn(tracklist, 1);


        burgermenu = new FlyoutItem
        {
            Title = "Menu",
            FlyoutDisplayOptions = FlyoutDisplayOptions.AsSingleItem,
            Items =
                {
                }
        };
        Grid.SetRow(burgermenu, 0);
        Grid.SetColumn(burgermenu, 0);
      


        grid.Children.Add(search);
        grid.Children.Add(leadesrs);
        grid.Children.Add(tracklist);
        maincontent = new HorizontalStackLayout
        {
            BackgroundColor = Color.FromRgb(160, 160, 160),
            //Children = {burgermenu}
        };
        Content = grid;
    }


}


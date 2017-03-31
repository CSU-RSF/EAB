using Xamarin.Forms;
using XLabs.Enums;
using XLabs.Forms.Controls;

namespace EAB
{
    public class CustomListCell : ViewCell
    {

        public CustomListCell()
        {
            // Instantiate Views
            var image = new Image();
            var title = new Label();
            var description = new Label();
            var arrow = new ImageButton() { Image = "arrow.png", BackgroundColor = Color.Transparent };
            var cellLayout = new StackLayout() { BackgroundColor = Color.FromHex("88cececc"), Padding = new Thickness(20, 10, 20, 10), Margin = new Thickness(0, 10, 0, 10) };
            Grid innerLayout = new Grid { ColumnSpacing = 20 };

            // Set Bindings
            image.SetBinding(Image.SourceProperty, new Binding("Thumbnail"));
            title.SetBinding(Label.TextProperty, new Binding("Text"));
            description.SetBinding(Label.TextProperty, new Binding("Detail"));
            arrow.SetBinding(ImageButton.CommandProperty, new Binding("NavigationCommand"));

            // Set properties for desired design
            innerLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            innerLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(3, GridUnitType.Star) });
            innerLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(10, GridUnitType.Star) });
            innerLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(2, GridUnitType.Star) });
            image.HorizontalOptions = LayoutOptions.End;
            title.FontSize = 18;
            description.FontSize = 14;

            // Join title and description
            StackLayout titleAndDescription = new StackLayout { VerticalOptions = LayoutOptions.Center };
            titleAndDescription.Children.Add(title);
            titleAndDescription.Children.Add(description);

            // Add views to hierarchy
            innerLayout.Children.Add(image, 0, 0);
            innerLayout.Children.Add(titleAndDescription, 1, 0);
            innerLayout.Children.Add(arrow, 2, 0);

            cellLayout.Children.Add(innerLayout);

            View = cellLayout;
        }
    }
}

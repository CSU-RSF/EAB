using System;
using System.Windows.Input;
using System.Threading.Tasks;
using Xamarin.Forms;
using EAB.Helpers;

namespace EAB
{
    public class CustomListCell : ViewCell
    {
        public static BindableProperty CommandProperty = BindableProperty.Create<CustomListCell, ICommand>(x => x.Command, null);

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public Task Navigation { get; private set; }

        public CustomListCell()
        {

            var helpers = new ViewHelpers();
            // Instantiate Views
            var image = new Image { Aspect = Aspect.AspectFill };
            var title = new Label();
            var description = new Label();
            var arrow = new Image { Source = "arrow.png", BackgroundColor = Color.Transparent };
            Grid cellLayout = new Grid {
                ColumnSpacing = 15,
                BackgroundColor = Color.FromHex("88cececc"),
                Padding = new Thickness(15, 5, 15, 5),
                Margin = new Thickness(0, 10, 0, 10)
            };

            // Add gesture recognizer for navigation
            var gestureRecognizer = new TapGestureRecognizer();
            gestureRecognizer.Tapped += (s, e) => {
                if (Command != null && Command.CanExecute(null))
                {
                    Command.Execute(null);
                }
            };

            // Set Bindings
            image.SetBinding(Image.SourceProperty, new Binding("Thumbnail"));
            title.SetBinding(Label.TextProperty, new Binding("Text"));
            description.SetBinding(Label.TextProperty, new Binding("Detail"));
            SetBinding(CommandProperty, new Binding("NavigationCommand"));
            cellLayout.GestureRecognizers.Add(gestureRecognizer);          

            // Set properties for desired design
            cellLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(80) });
            cellLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            cellLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(40) });
            cellLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(80) });
            title.FontSize = 18;
            description.FontSize = 14;

            // Join title and description
            StackLayout titleAndDescription = new StackLayout {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start
            };
            titleAndDescription.Children.Add(title);
            titleAndDescription.Children.Add(description);

            // Add views to hierarchy
            cellLayout.Children.Add(image, 0, 0);
            cellLayout.Children.Add(titleAndDescription, 1, 0);
            cellLayout.Children.Add(arrow, 2, 0);

            View = cellLayout;
        }

    }
}

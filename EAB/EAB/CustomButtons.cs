using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace EAB
{
    public partial class CustomButtons : Grid
    {

        public CustomButtons()
        {
            // Initialize
            ConstructGrid();            
        }

        public Grid ConstructGrid()
        {
            // Instantiate Views
            var CSFS = new ImageButton() { Image = "csfs.png", BackgroundColor = Color.Transparent };
            var CSU = new ImageButton() { Image = "csu_extension.png", BackgroundColor = Color.Transparent };
            Grid layout = new Grid { ColumnSpacing = 20 };

            // Set bindings
            CSFS.SetBinding(ImageButton.CommandProperty, new Binding("NavigationCommand"));

            // Set properties for desired design
            layout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            layout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // Add views to hierarchy
            layout.Children.Add(CSFS, 0, 0);
            layout.Children.Add(CSU, 1, 0);

            return layout;
        }
    }
}

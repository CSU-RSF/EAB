using Xamarin.Forms;
using EAB.Helpers;

namespace EAB
{
    public partial class SymptomsPage : ViewHelpers
    {
        public SymptomsPage()
        {
            // Hide built-in navigation bar
            NavigationPage.SetHasNavigationBar(this, false);

            // Construct outer page container and internal grid
            AbsoluteLayout pageLayout = ConstructPageContainer();
            Grid gridLayout = new Grid { RowSpacing = 20 };
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // Construct navigation bar and add to grid layout
            Grid navigationBar = ConstructNavigationBar();
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            gridLayout.Children.Add(navigationBar, 0, 0);

            // Construct title bar and add to grid layout
            AbsoluteLayout titleBarContainer = ConstructTitleBarContainer("EAB Symptoms");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(80) });
            gridLayout.Children.Add(titleBarContainer, 0, 1);

            // Construct paragraphs and add to grid layout
            Label paragraphOne = new Label
            {
                Text = "If you have an ash tree, you need to watch it for EAB symptoms, and have a plan in place for when the insect is detected in your area. Signs that a tree has EAB include:",
                FontSize = 17,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            Label bulletOne = new Label
            {
                Text = "\u2022 thinning of leaves and upper branches and twigs",
                FontSize = 18,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            Label bulletTwo = new Label
            {
                Text = "\u2022 serpentine tunnels produced by larvae under the bark",
                FontSize = 18,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            Label bulletThree = new Label
            {
                Text = "\u2022 D-shaped exit holes 1/8-inch wide",
                FontSize = 18,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            Label bulletFour = new Label
            {
                Text = "\u2022 new sprouts on the lower trunk or lower branches",
                FontSize = 18,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            Label bulletFive = new Label
            {
                Text = "\u2022 vertical splits in the bark",
                FontSize = 18,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            Label bulletSix = new Label
            {
                Text = "\u2022 increased woodpecker activity",
                FontSize = 18,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            Label paragraphTwo = new Label
            {
                Text = "Be aware of EAB imposters! Other insects like lilac/ash borer, ash bark beetle and flat-headed appletree borer may look like EAB or cause similar tree symptoms.",
                FontSize = 17,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            Label paragraphThree = new Label
            {
                Text = "If the holes on a tree are the size of a pinhead or oval/circular in shape and approximately 1/4-inch across, they were not made by EAB. (To be sure of the hole’s true size and shape, try scraping away a thin layer of bark with a knife.) Also, tunnels under the bark that are not serpentine, wavy or S-shaped most likely were not made by EAB, but by other pests.",
                FontSize = 17,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            Label paragraphFour = new Label
            {
                Text = "If you think you do have EAB in your ash trees, contact the Colorado Department of Agriculture at (888) 248-5535 or email CAPS.program@state.co.us.",
                FontSize = 17,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            Button EABManagement = new Button
            {
                Text = "EAB Management",
                Style = Application.Current.Resources["semiTransparentButton"] as Style,
                FontFamily = Device.OnPlatform("Montserrat-Light", "Montserrat-Light.ttf#Montserrat-Light", null)
            };
            EABManagement.Clicked += ToEABManagement;

            Button EABInfoButton = new Button
            {
                Text = "More EAB Info",
                Style = Application.Current.Resources["semiTransparentButton"] as Style,
                FontFamily = Device.OnPlatform("Montserrat-Light", "Montserrat-Light.ttf#Montserrat-Light", null)
            };
            EABInfoButton.Clicked += ToMoreEABInfo;

            ScrollView paragraphContainer = new ScrollView();
            StackLayout paragraphText = new StackLayout { Margin = new Thickness(20, 0, 20, 0) };
            paragraphText.Children.Add(paragraphOne);
            paragraphText.Children.Add(bulletOne);
            paragraphText.Children.Add(bulletTwo);
            paragraphText.Children.Add(bulletThree);
            paragraphText.Children.Add(bulletFour);
            paragraphText.Children.Add(bulletFive);
            paragraphText.Children.Add(bulletSix);
            paragraphText.Children.Add(paragraphTwo);
            paragraphText.Children.Add(paragraphThree);
            paragraphText.Children.Add(paragraphFour);
            paragraphText.Children.Add(EABManagement);
            paragraphText.Children.Add(EABInfoButton);
            paragraphContainer.Content = paragraphText;
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridLayout.Children.Add(paragraphContainer, 0, 2);

            // Add grid layout to absolute layout and assign to Content
            pageLayout.Children.Add(gridLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            Content = pageLayout;
        }
    }
}

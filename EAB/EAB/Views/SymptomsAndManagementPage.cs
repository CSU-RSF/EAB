using Xamarin.Forms;
using EAB.Helpers;

namespace EAB
{
    public partial class SymptomsAndManagementPage : ViewHelpers
    {
        public SymptomsAndManagementPage()
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
            AbsoluteLayout titleBarContainer = ConstructTitleBarContainer("EAB Symptoms & Management");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(130) });
            gridLayout.Children.Add(titleBarContainer, 0, 1);

            // Construct paragraphs and add to grid layout
            Label paragraphOne = new Label
            {
                Text = "Emerald ash borer (EBA) attacks and kills all true native North American ash trees, including green, white, black and blue ash, including cultivars like \"autumn purple ash\", a popular white ash varietal in Colorado.",
                FontSize = 17,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            Label paragraphTwo = new Label
            {
                Text = "EAB kills stressed and healthy trees and is so aggressive that ash trees may die within two years after they become infested.",
                FontSize = 17,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            Button EABSymptoms = new Button
            {
                Text = "EAB Symptoms",
                Style = Application.Current.Resources["semiTransparentButton"] as Style,
                FontFamily = Device.OnPlatform("Montserrat-Light", "Montserrat-Light.ttf#Montserrat-Light", null)
            };
            EABSymptoms.Clicked += ToEABSymptoms;

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

            Label paragraphThree = new Label
            {
                Text = "*Although very rare in Colorado, white fringetree also has now been documented as susceptible to EAB; anyone with this tree type should seek a professional forester or arborist for recommendations.",
                FontSize = 14,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            ScrollView paragraphContainer = new ScrollView();
            StackLayout paragraphText = new StackLayout { Margin = new Thickness(20, 0, 20, 0) };
            paragraphText.Children.Add(paragraphOne);
            paragraphText.Children.Add(paragraphTwo);
            paragraphText.Children.Add(EABSymptoms);
            paragraphText.Children.Add(EABManagement);
            paragraphText.Children.Add(EABInfoButton);
            paragraphText.Children.Add(paragraphThree);
            paragraphContainer.Content = paragraphText;
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridLayout.Children.Add(paragraphContainer, 0, 2);

            // Add grid layout to absolute layout and assign to Content
            pageLayout.Children.Add(gridLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            Content = pageLayout;
        }
    }
}

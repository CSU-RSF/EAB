using Xamarin.Forms;
using EAB.Helpers;

namespace EAB
{
    public partial class ManagementPage : ViewHelpers
    {
        public ManagementPage()
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
            AbsoluteLayout titleBarContainer = ConstructTitleBarContainer("EAB Management");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            gridLayout.Children.Add(titleBarContainer, 0, 1);

            // Construct paragraphs and add to grid layout
            Label paragraphOne = new Label
            {
                Text = "Insecticides are available to protect ash trees from EAB. Consumers should educate themselves when purchasing chemical products to protect trees against EAB and talk to a professional forester, Extension agent or arborist before applying any treatment.",
                FontSize = 17,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            Label paragraphTwo = new Label
            {
                Text = "Other management strategies for dealing with EAB include:",
                FontSize = 17,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            Label bulletOne = new Label
            {
                Text = "\u2022 monitoring trees for the presence of the pest",
                FontSize = 18,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            Label bulletTwo = new Label
            {
                Text = "\u2022 removing and/or replacing ash trees",
                FontSize = 18,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            Label bulletThree = new Label
            {
                Text = "\u2022 planting new trees preemptively in an effort to get them established before the arrival of EAB",
                FontSize = 18,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };

            Label paragraphThree = new Label
            {
                Text = "Decisions about how to manage ash trees should take into account the overall health of each tree and its value to the property owner.",
                FontSize = 17,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };
            
            Button EABManagement = new Button
            {
                Text = "EAB Symptoms",
                Style = Application.Current.Resources["semiTransparentButton"] as Style,
                FontFamily = Device.OnPlatform("Montserrat-Light", "Montserrat-Light.ttf#Montserrat-Light", null)
            };
            EABManagement.Clicked += ToEABSymptoms;

            Button EABInfoButton = new Button
            {
                Text = "More EAB Info",
                Style = Application.Current.Resources["semiTransparentButton"] as Style,
                FontFamily = Device.OnPlatform("Montserrat-Light", "Montserrat-Light.ttf#Montserrat-Light", null),
            };
            EABInfoButton.Clicked += ToMoreEABInfo;

            ScrollView paragraphContainer = new ScrollView();
            StackLayout paragraphText = new StackLayout { Margin = new Thickness(20, 0, 20, 0) };
            paragraphText.Children.Add(paragraphOne);
            paragraphText.Children.Add(paragraphTwo);
            paragraphText.Children.Add(bulletOne);
            paragraphText.Children.Add(bulletTwo);
            paragraphText.Children.Add(bulletThree);
            paragraphText.Children.Add(paragraphThree);
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

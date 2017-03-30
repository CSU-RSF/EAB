using Xamarin.Forms;
using EAB.Helpers;

namespace EAB
{
    public class IntroPage : ViewHelpers
    {
        public IntroPage()
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
            AbsoluteLayout titleBarContainer = ConstructTitleBarContainer("Introduction to App");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            gridLayout.Children.Add(titleBarContainer, 0, 1);

            // Construct paragraphs and add to grid layout
            Image image = new Image {
                Source = ImageSource.FromResource("EAB.Images.intro.jpg")
            };

            Label paragraphOne = new Label {
                Text = "In 2013, Emerald Ash Borer (EAB) was confirmed for the first time in Colorado, in the City of Boulder. The highly destructive, non-native insect is responsible for the death or decline of millions of ash trees in the U.S. and has already cost communities billions of dollars to treat, remove and replace ash trees.",
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null),
                FontSize = 17
            };
            Label paragraphTwo = new Label {
                Text = "All species of \"true\" ash trees are at risk of being killed by EAB. In Colorado, ash trees comprise 15 percent or more of all trees and can be found in most communities.",
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null),
                FontSize = 17
            };
            Label paragraphThree = new Label {
                Text = "This app will help you determine if a tree is an ash, and can be killed by EAB.",
                FontFamily = Device.OnPlatform("Arimo-Bold", "Arimo-Bold.ttf#Arimo-Bold", null),
                FontSize = 17
            };
            Label paragraphFour = new Label {
                Text = "Note: This application tool is intended to help determine whether a tree might be a true ash and susceptible to EAB. This app should not be used for definitive tree species determination; seek a professional forester or arborist if you suspect you may have an ash tree.",
                FontFamily = Device.OnPlatform("Arimo-Italic", "Arimo-Italic.ttf#Arimo-Italic", null),
                FontSize = 17
            };
            ScrollView paragraphContainer = new ScrollView();
            StackLayout paragraphText = new StackLayout { Margin = new Thickness(20, 0, 20, 0) };
            paragraphText.Children.Add(image);
            paragraphText.Children.Add(paragraphOne);
            paragraphText.Children.Add(paragraphTwo);
            paragraphText.Children.Add(paragraphThree);
            paragraphText.Children.Add(paragraphFour);
            paragraphContainer.Content = paragraphText;

            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridLayout.Children.Add(paragraphContainer, 0, 2);

            // Construct "Continue" button and add to grid layout
            Button getStartedButton = new Button
            {
                Style = Application.Current.Resources["semiTransparentButton"] as Style,
                FontFamily = Device.OnPlatform("Montserrat-Light", "Montserrat-Light.ttf#Montserrat-Light", null),
                Text = "CONTINUE",
                Margin = new Thickness(20, 0, 20, 20)
            };
            getStartedButton.Clicked += ToTreeKind;

            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(70) });
            gridLayout.Children.Add(getStartedButton, 0, 3);

            // Add grid layout to absolute layout and assign to Content
            pageLayout.Children.Add(gridLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            Content = pageLayout;
        }
    }
}

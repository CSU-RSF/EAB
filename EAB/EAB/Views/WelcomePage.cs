using Xamarin.Forms;
using EAB.Helpers;

namespace EAB
{
    public class WelcomePage : ViewHelpers
    {
        public WelcomePage()
        {

            NavigationPage.SetHasNavigationBar(this, false);

            AbsoluteLayout pageLayout = ConstructPageContainer();

            Grid navigationBar = ConstructNavigationBar(false, false);

            Grid gridLayout = new Grid { RowSpacing = 10 };
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60) });
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            Label welcome = new Label {
                FontSize = 35,
                Text = "Welcome!",
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null),
                HorizontalTextAlignment = TextAlignment.Center
            };
            Button getStartedButton = new Button {
                Style = Application.Current.Resources["semiTransparentButton"] as Style,
                FontFamily = Device.OnPlatform("Montserrat-Light", "Montserrat-Light.ttf#Montserrat-Light", null),
                Text = "GET STARTED",
                Margin = new Thickness(20, 0, 20, 0)
            };
            getStartedButton.Clicked += ToIntroPage;
            Button moreInfoButton = new Button
            {
                Style = Application.Current.Resources["semiTransparentButton"] as Style,
                FontFamily = Device.OnPlatform("Montserrat-Light", "Montserrat-Light.ttf#Montserrat-Light", null),
                Text = "EAB SYMPTOMS & MANAGEMENT",
                Margin = new Thickness(20, 0, 20, 0)
            };
            moreInfoButton.Clicked += ToEABSymptomsAndManagement;

            gridLayout.Children.Add(navigationBar, 0, 0);
            gridLayout.Children.Add(welcome, 0, 2);
            gridLayout.Children.Add(getStartedButton, 0, 3);
            gridLayout.Children.Add(moreInfoButton, 0, 4);

            pageLayout.Children.Add(gridLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All); 

            Content = pageLayout;
        }
    }
}

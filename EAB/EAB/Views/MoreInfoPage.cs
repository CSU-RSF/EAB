using Xamarin.Forms;
using EAB.Helpers;
using System;

namespace EAB
{
    public partial class MoreInfoPage : ViewHelpers
    {
        public MoreInfoPage()
        {
            // Hide built-in navigation bar
            NavigationPage.SetHasNavigationBar(this, false);

            // Construct outer page container and internal grid
            AbsoluteLayout pageLayout = ConstructPageContainer();
            Grid gridLayout = new Grid { RowSpacing = 10 };
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // Construct navigation bar and add to grid layout
            Grid navigationBar = ConstructNavigationBar();
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            gridLayout.Children.Add(navigationBar, 0, 0);

            // Construct title bar and add to grid layout
            AbsoluteLayout titleBarContainer = ConstructTitleBarContainer("More EAB Info");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(150) });
            gridLayout.Children.Add(titleBarContainer, 0, 1);

            // Construct buttons and add to grid layout
            Button ForHomeownersButton = new Button
            {
                Text = "For Homeowners",
                Style = Application.Current.Resources["semiTransparentButton"] as Style,
                FontFamily = Device.OnPlatform("Montserrat-Light", "Montserrat-Light.ttf#Montserrat-Light", null),
            };
            ForHomeownersButton.Clicked += ToHomeOwnersLink;
            
            Button EABManagmentButton = new Button
            {
                Text = "EAB Management/Quarantine Colorado",
                Style = Application.Current.Resources["semiTransparentButton"] as Style,
                FontFamily = Device.OnPlatform("Montserrat-Light", "Montserrat-Light.ttf#Montserrat-Light", null),
            };
            EABManagmentButton.Clicked += ToEABManagementLink;
            
            Button ControlOptionsButton = new Button
            {
                Text = "Control Options for EAB",
                Style = Application.Current.Resources["semiTransparentButton"] as Style,
                FontFamily = Device.OnPlatform("Montserrat-Light", "Montserrat-Light.ttf#Montserrat-Light", null),
            };
            ControlOptionsButton.Clicked += ToControlOptionsLink;
            
            Button DangersButton = new Button
            {
                Text = "Dangers of Moving Firewood and EAB",
                Style = Application.Current.Resources["semiTransparentButton"] as Style,
                FontFamily = Device.OnPlatform("Montserrat-Light", "Montserrat-Light.ttf#Montserrat-Light", null),
            };
            DangersButton.Clicked += ToDangersLink;

            StackLayout paragraphText = new StackLayout { Margin = new Thickness(20, 0, 20, 0) };
            paragraphText.Children.Add(ForHomeownersButton);
            paragraphText.Children.Add(EABManagmentButton);
            paragraphText.Children.Add(ControlOptionsButton);
            paragraphText.Children.Add(DangersButton);
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridLayout.Children.Add(paragraphText, 0, 2);

            // Add grid layout to absolute layout and assign to Content
            pageLayout.Children.Add(gridLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            Content = pageLayout;
        }
    }
}

using EAB.Helpers;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace EAB
{
        
    public partial class OutcomeAPage : ViewHelpers
    {
        public OutcomeAPage()
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
            AbsoluteLayout titleBarContainer = ConstructTitleBarContainer("Probably Not an Ash");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            gridLayout.Children.Add(titleBarContainer, 0, 1);

           
            // Construct paragraphs and add to grid layout
            Label paragraphOne = new Label
            {
                Text = "This is probably not a true ash tree, and therefore not at risk from EAB.",
                FontSize = 17,
                FontFamily = Device.OnPlatform("Arimo-Bold", "Arimo-Bold.ttf#Arimo-Bold", null)
            };
            Label paragraphTwo = new Label
            {
                Text = "Check with a professional forester and arborist to be sure.",
                FontSize = 17,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };
            Button EABInfoButton = new Button
            {
                Text = "More EAB Info",
                Style = Application.Current.Resources["semiTransparentButton"] as Style,
                FontFamily = Device.OnPlatform("Montserrat-Light", "Montserrat-Light.ttf#Montserrat-Light", null)
            };
            EABInfoButton.Clicked += ToMoreEABInfo;

            StackLayout paragraphText = new StackLayout { Margin = new Thickness(20, 0, 20, 0) };
            paragraphText.Children.Add(paragraphOne);
            paragraphText.Children.Add(paragraphTwo);
            paragraphText.Children.Add(EABInfoButton);



            // Instantiate Views
            var CSFS = new ImageButton() { Image = "csfs.png", BackgroundColor = Color.Transparent };
            var CSU = new ImageButton() { Image = "csu_extension.png", BackgroundColor = Color.Transparent };
            Grid buttonGroup = new Grid { ColumnSpacing = 20 };

            // Set bindings
            CSFS.SetBinding(ImageButton.CommandProperty, new Binding("NavigationCommand"));

            // Set properties for desired design
            buttonGroup.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            buttonGroup.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            buttonGroup.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // Add views to hierarchy
            buttonGroup.Children.Add(CSFS, 0, 0);
            buttonGroup.Children.Add(CSU, 1, 0);

            // Add paragrah to grid layout
            paragraphText.Children.Add(buttonGroup);
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridLayout.Children.Add(paragraphText, 0, 2);



            // Add grid layout to absolute layout and assign to Content
            pageLayout.Children.Add(gridLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            Content = pageLayout;

        }
    }

    public partial class OutcomeBPage : ViewHelpers
    {
        public OutcomeBPage()
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
            AbsoluteLayout titleBarContainer = ConstructTitleBarContainer("Probably an Ash");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            gridLayout.Children.Add(titleBarContainer, 0, 1);


            // Construct paragraphs and add to grid layout
            Label paragraphOne = new Label
            {
                Text = "This appears to be an ash tree, and susceptible to being killed by EAB.",
                FontSize = 17,
                FontFamily = Device.OnPlatform("Arimo-Bold", "Arimo-Bold.ttf#Arimo-Bold", null)
            };
            Label paragraphTwo = new Label
            {
                Text = "You should consult with a professional forester or arborist as soon as possible to confirm and discuss management options.",
                FontSize = 17,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };
            Button EABInfoButton = new Button
            {
                Text = "More EAB Info",
                Style = Application.Current.Resources["semiTransparentButton"] as Style,
                FontFamily = Device.OnPlatform("Montserrat-Light", "Montserrat-Light.ttf#Montserrat-Light", null)
            };
            EABInfoButton.Clicked += ToMoreEABInfo;

            StackLayout paragraphText = new StackLayout { Margin = new Thickness(20, 0, 20, 0) };
            paragraphText.Children.Add(paragraphOne);
            paragraphText.Children.Add(paragraphTwo);
            paragraphText.Children.Add(EABInfoButton);
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridLayout.Children.Add(paragraphText, 0, 2);

            // Add grid layout to absolute layout and assign to Content
            pageLayout.Children.Add(gridLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            Content = pageLayout;
        }
    }

    public partial class OutcomeCPage : ViewHelpers
    {
        public OutcomeCPage()
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
            AbsoluteLayout titleBarContainer = ConstructTitleBarContainer("An Ash?");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            gridLayout.Children.Add(titleBarContainer, 0, 1);


            // Construct paragraphs and add to grid layout
            Label paragraphOne = new Label
            {
                Text = "It's hard to say if this is an ash or not.",
                FontSize = 17,
                FontFamily = Device.OnPlatform("Arimo-Bold", "Arimo-Bold.ttf#Arimo-Bold", null)
            };
            Label paragraphTwo = new Label
            {
                Text = "Check with a professional forester and arborist, or wait until leaves are on the tree and then re-assess.",
                FontSize = 17,
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null)
            };
            Button EABInfoButton = new Button
            {
                Text = "More EAB Info",
                Style = Application.Current.Resources["semiTransparentButton"] as Style,
                FontFamily = Device.OnPlatform("Montserrat-Light", "Montserrat-Light.ttf#Montserrat-Light", null)
            };
            EABInfoButton.Clicked += ToMoreEABInfo;

            StackLayout paragraphText = new StackLayout { Margin = new Thickness(20, 0, 20, 0) };
            paragraphText.Children.Add(paragraphOne);
            paragraphText.Children.Add(paragraphTwo);
            paragraphText.Children.Add(EABInfoButton);
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridLayout.Children.Add(paragraphText, 0, 2);

            // Add grid layout to absolute layout and assign to Content
            pageLayout.Children.Add(gridLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            Content = pageLayout;
        }
    }

}

using Xamarin.Forms;
using EAB.Helpers;
using System;

namespace EAB
{
    public class ImageModal : ViewHelpers
    {
        public ImageModal(string fileName)
        {
            NavigationPage.SetHasNavigationBar(this, false);

            AbsoluteLayout pageLayout = ConstructPageContainer();

            var image = new Image { Aspect = Aspect.AspectFit };
            image.Source = ImageSource.FromResource(string.Format("EAB.Images.{0}", fileName));

            var closeButton = new Button {
                Text = "CLOSE",
                Style = Application.Current.Resources["semiTransparentButton"] as Style,
                FontFamily = Device.OnPlatform("Montserrat-Light", "Montserrat-Light.ttf#Montserrat-Light", null),
            };
            closeButton.Clicked += OnCloseButtonClicked;

            Grid gridLayout = new Grid { RowSpacing = 10 };
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            
            gridLayout.Children.Add(image, 0, 0);
            gridLayout.Children.Add(closeButton, 0, 1);

            pageLayout.Children.Add(gridLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All); 

            Content = pageLayout;
        }

        async void OnCloseButtonClicked(object sender, EventArgs args)
        {
            await Navigation.PopModalAsync();
        }
        
    }
}

using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace EAB.Helpers
{
    public class ViewHelpers : ContentPage
    {
        public StackLayout stackLayout = new StackLayout();

        public AbsoluteLayout ConstructPageContainer()
        {
            AbsoluteLayout pageLayout = new AbsoluteLayout();
            pageLayout.Padding = new Thickness(0, Device.OnPlatform(20, 0, 0), 0, 0);
            Image backgroundImage = new Image { Source = ImageSource.FromResource("EAB.Images.emerald_ash_background.jpg"), Aspect = Aspect.AspectFill };
            pageLayout.Children.Add(backgroundImage, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            return pageLayout;
        }
                
        public Grid ConstructNavigationBar(bool backButtonVisible = true, bool homeButtonVisible = true)
        {
            Grid gridLayout = new Grid { BackgroundColor = Color.FromHex("1e4d2b"), VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand };
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(5, GridUnitType.Star) });
            gridLayout.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // Construct back button and add gesture recognizer
            Image backImage = new Image {
                Source = ImageSource.FromResource("EAB.Images.back_arrow.png"),
                IsVisible = backButtonVisible,
                HeightRequest = 20,
                WidthRequest = 20,
                Margin = new Thickness(0, 15, 0, 15)
            };
            var backGestureRecognizer = new TapGestureRecognizer();
            backGestureRecognizer.Tapped += async (sender, e) => {
                backImage.Opacity = .5;
                await Task.Delay(200);
                backImage.Opacity = 1;
                await Navigation.PopAsync();
            };
            backImage.GestureRecognizers.Add(backGestureRecognizer);

            Label title = new Label { Text = "EAB/ASH TREE ID", FontFamily = Device.OnPlatform("Montserrat-Medium", "Montserrat-Medium.ttf#Montserrat-Medium", null), TextColor = Color.White, FontSize = 20, HorizontalTextAlignment = TextAlignment.Center, VerticalTextAlignment = TextAlignment.Center };

            // Construct home button and add gesture recognizer
            Image homeImage = new Image {
                Source = ImageSource.FromResource("EAB.Images.home_icon.png"),
                IsVisible = homeButtonVisible,
                HeightRequest = 20,
                WidthRequest = 20,
                Margin = new Thickness(0, 15, 0, 15)
            };
            var homeGestureRecognizer = new TapGestureRecognizer();
            homeGestureRecognizer.Tapped += async (sender, e) => {
                homeImage.Opacity = .5;
                await Task.Delay(200);
                homeImage.Opacity = 1;
                await Navigation.PopToRootAsync();
                await Navigation.PushAsync(new IntroPage());
            };
            homeImage.GestureRecognizers.Add(homeGestureRecognizer);

            gridLayout.Children.Add(backImage, 0, 0);
            gridLayout.Children.Add(title, 1, 0);
            gridLayout.Children.Add(homeImage, 2, 0);
            return gridLayout;
        }

        public Grid ConstructPageGrid()
        {
            Grid gridLayout = new Grid();
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(50) });
            return gridLayout;
        }

        public AbsoluteLayout ConstructTitleBarContainer(string titleText)
        {
            AbsoluteLayout absoluteLayout = new AbsoluteLayout();
            Image backgroundImage = new Image { Source = ImageSource.FromResource("EAB.Images.text_background_overlay.png"), Aspect = Aspect.AspectFill };
            absoluteLayout.Children.Add(backgroundImage, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);

            Label question = new Label { Text = titleText, FontSize = 25, HorizontalTextAlignment = TextAlignment.Center, TextColor = Color.White };
            AbsoluteLayout.SetLayoutBounds(question, new Rectangle(.5, .5, 1, .5));
            AbsoluteLayout.SetLayoutFlags(question, AbsoluteLayoutFlags.All);
            absoluteLayout.Children.Add(question);
            return absoluteLayout;
        }

        public AbsoluteLayout ConstructQuestionContainer(string questionText)
        {
            Label question = new Label {
                Text = questionText,
                FontSize = 17,
                Margin = new Thickness(10, 0, 10, 0),
                HorizontalTextAlignment = TextAlignment.Center,
                TextColor = Color.Black,
                FontFamily = Device.OnPlatform("Arimo-Bold", "Arimo-Bold.ttf#Arimo-Bold", null)
            };
            AbsoluteLayout absoluteLayout = new AbsoluteLayout();
            AbsoluteLayout.SetLayoutBounds(question, new Rectangle(.5, .5, 1, .5));
            AbsoluteLayout.SetLayoutFlags(question, AbsoluteLayoutFlags.All);
            absoluteLayout.Children.Add(question);
            return absoluteLayout;
        }

        // HTML View
        public WebView browser = new WebView { HeightRequest = 500, WidthRequest = 500 };
        public HtmlWebViewSource htmlSource = new HtmlWebViewSource();
        public string html = "";

        // ListView
        public ObservableCollection<QuestionModel> questionChoices = new ObservableCollection<QuestionModel>();
        public ListView ConstructListView(bool twoImages = false)
        {
            ListView listView = new ListView();
            listView.RowHeight = 110;
            listView.SeparatorVisibility = SeparatorVisibility.None;
            if (twoImages)
            {
                listView.ItemTemplate = new DataTemplate(typeof(CustomTwoImageListCell));
            }
            else
            {
                listView.ItemTemplate = new DataTemplate(typeof(CustomListCell));
            }
            return listView;
        }

        // Button Group
        public Grid ConstructButtonGroup()
        {
            // Create CSFS and CSU Buttons
            var CSFS = new ImageButton() { Image = "csfs.png", BackgroundColor = Color.Transparent, WidthRequest = 200 };
            var CSU = new ImageButton() { Image = "csu_extension.png", BackgroundColor = Color.Transparent, WidthRequest = 200 };
            Grid buttonGroup = new Grid { ColumnSpacing = 20 };

            // Set navigation
            CSFS.Clicked += ToCSFS;
            CSU.Clicked += ToCSU;

            // Set properties for desired design
            buttonGroup.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            buttonGroup.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            buttonGroup.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

            // Add views to hierarchy
            buttonGroup.Children.Add(CSFS, 0, 0);
            buttonGroup.Children.Add(CSU, 1, 0);

            return buttonGroup;
        }

        //contruct ash tree outcome information
        public StackLayout ConstructOutcomeInfoGroup()
        {
            StackLayout outcomeLayout = new StackLayout();

            Label heading = new Label
            {
                Text = "Ash trees have the following characteristics:",
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null),
                FontSize = 17,
                VerticalTextAlignment = TextAlignment.Center
            };
            outcomeLayout.Children.Add(heading);

            Grid outcomeGrid = new Grid() { ColumnSpacing = 20, VerticalOptions = LayoutOptions.FillAndExpand };

            //buttonGroup.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            outcomeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(20) });
            outcomeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            outcomeGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(100)});
            Label leafText = new Label
            {
                Text = "Compound leaves with 5-11 leaflets (Note that in Colorado, ash species typically have only 5-9 leaflets)",
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null),
                FontSize = 17,
                VerticalTextAlignment = TextAlignment.Center
            };
            Image leafNumberImage = new Image
            {
                Source = ImageSource.FromResource("EAB.Images.LeafNumber.png")
            };


            outcomeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            outcomeGrid.Children.Add(leafText,1,0);
            outcomeGrid.Children.Add(leafNumberImage, 2, 0);

            Label branchText = new Label
            {
                Text = "Opposite buds and branches",
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null),
                FontSize = 17,
                VerticalTextAlignment = TextAlignment.Center
            };
            Image branchImage = new Image
            {
                Source = ImageSource.FromResource("EAB.Images.branch.png")
            };
            outcomeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            outcomeGrid.Children.Add(branchText, 1, 1);
            outcomeGrid.Children.Add(branchImage, 2, 1);


            Label barkText = new Label
            {
                Text = "Diamond-shaped bark patterns on most of the mature (>12” trunk diameter) ash tree species seen in Colorado",
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null),
                FontSize = 17,
                VerticalTextAlignment = TextAlignment.Center
            };
            Image barkImage = new Image
            {
                Source = ImageSource.FromResource("EAB.Images.diamond_bark.png")
            };
            outcomeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            outcomeGrid.Children.Add(barkText, 1, 2);
            outcomeGrid.Children.Add(barkImage, 2, 2);
            outcomeLayout.Children.Add(outcomeGrid);


            Label leafEdgeText = new Label
            {
                Text = "Leaflet edges that are smooth or finely toothed",
                FontFamily = Device.OnPlatform("Arimo-Regular", "Arimo-Regular.ttf#Arimo-Regular", null),
                FontSize = 17,
                VerticalTextAlignment = TextAlignment.Center
            };
            Image leafEdgeImage = new Image
            {
                Source = ImageSource.FromResource("EAB.Images.leaf_edge.png")
            };
            outcomeGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            outcomeGrid.Children.Add(leafEdgeText, 1, 3);
            outcomeGrid.Children.Add(leafEdgeImage, 2, 3);
            outcomeLayout.Children.Add(outcomeGrid);


            return outcomeLayout;
        }

        // NAVIGATION: GENERAL

        public async void ToPreviousPage(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        public async void ToRootPage(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        public async void ToIntroPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new IntroPage());
        }

        public async void ToTreeKind(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TreeKindPage());
        }

        public async void ToBudsAndLeaves(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BudsAndLeavesPage());
        }

        public async void ToLeavesType(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LeavesTypePage());
        }

        public async void ToLeafletsShape(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LeafletsShapePage());
        }

        public async void ToLeafletsNumber(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LeafletsNumberPage());
        }

        public async void ToTrunkWidth(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TrunkWidthPage());
        }

        public async void ToDiamondShapedBark(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DiamondShapedBarkPage());
        }

        // NAVIGATION: OUTCOMES

        public async void ToOutcomeA(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OutcomeAPage());
        }

        public async void ToOutcomeB(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OutcomeBPage());
        }

        public async void ToOutcomeC(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new OutcomeCPage());
        }

        public async void ToCSFS(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HTMLPage("https://csfs.colostate.edu/"));
        }

        public async void ToCSU(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HTMLPage("https://extension.colostate.edu/"));
        }

        // NAVIGATION: MORE INFO

        public async void ToEABSymptomsAndManagement(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SymptomsAndManagementPage());
        }

        public async void ToEABSymptoms(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SymptomsPage());
        }

        public async void ToEABManagement(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ManagementPage());
        }

        public async void ToMoreEABInfo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MoreInfoPage());
        }

        public async void ToHomeOwnersLink(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HTMLPage("https://csfs.colostate.edu/forest-management/emerald-ash-borer/"));
        }

        public async void ToEABManagementLink(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HTMLPage("https://www.colorado.gov/agplants/emerald-ash-borer"));
        }

        public async void ToControlOptionsLink(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HTMLPage("EAB-control-options-February-11.pdf"));
        }

        public async void ToDangersLink(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HTMLPage("https://www.dontmovefirewood.org/"));
        }

    }
}

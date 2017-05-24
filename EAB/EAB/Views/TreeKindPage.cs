using Xamarin.Forms;
using EAB.Helpers;

namespace EAB
{
    public partial class TreeKindPage : ViewHelpers
    {
        public TreeKindPage()
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
            AbsoluteLayout titleBarContainer = ConstructTitleBarContainer("Getting Started");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(80) });
            gridLayout.Children.Add(titleBarContainer, 0, 1);

            // Construct question and add to grid layout
            AbsoluteLayout questionContainer = ConstructQuestionContainer("Does the tree have needles or leaves?");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(80) });
            gridLayout.Children.Add(questionContainer, 0, 2);

            // Construct list of choices and add to grid layout
            ListView listView = ConstructListView();
            Command evergreenCommand = new Command(async () => { await Navigation.PushAsync(new OutcomeAPage()); });
            Command evergreenImageCommand = new Command(async () => { await Navigation.PushModalAsync(new ImageModal("evergreen_big.jpg")); });
            Command deciduousCommand = new Command(async () => { await Navigation.PushAsync(new BudsAndLeavesPage()); });
            Command deciduousImageCommand = new Command(async () => { await Navigation.PushModalAsync(new ImageModal("deciduous_big.jpg")); });
            questionChoices.Add(new QuestionModel() { Text = "Needles", Detail = "An evergreen tree", FileName = "evergreen.jpg", ImageCommand = evergreenImageCommand, NavigationCommand = evergreenCommand });
            questionChoices.Add(new QuestionModel() { Text = "Leaves", Detail = "Deciduous; leaves drop in fall", FileName = "deciduous.jpg", ImageCommand = deciduousImageCommand, NavigationCommand = deciduousCommand });
            listView.ItemsSource = questionChoices;
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridLayout.Children.Add(listView, 0, 3);

            // Add grid layout to absolute layout and assign to Content
            pageLayout.Children.Add(gridLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            Content = pageLayout;
        }
    }
}

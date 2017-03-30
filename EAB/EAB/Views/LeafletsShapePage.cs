using Xamarin.Forms;
using EAB.Helpers;

namespace EAB
{
    public partial class LeafletsShapePage : ViewHelpers
    {
        public LeafletsShapePage()
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
            AbsoluteLayout titleBarContainer = ConstructTitleBarContainer("This Might Be An Ash");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            gridLayout.Children.Add(titleBarContainer, 0, 1);

            // Construct question and add to grid layout
            AbsoluteLayout questionContainer = ConstructQuestionContainer("Do the leaflets all radiate off one point (like fingers on a hand) or emerge from separate, opposite points (arranged like a feather)? ");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(160) });
            gridLayout.Children.Add(questionContainer, 0, 2);

            // Construct list of choices and add to grid layout
            ListView listView = ConstructListView();
            Command onePointCommand = new Command(async () => { await Navigation.PushAsync(new OutcomeAPage()); });
            Command featherCommand = new Command(async () => { await Navigation.PushAsync(new LeafletsNumberPage()); });
            questionChoices.Add(new QuestionModel() { Text = "Leaflets radiate off one point", FileName = "leaflets_radiate.jpg", NavigationCommand = onePointCommand });
            questionChoices.Add(new QuestionModel() { Text = "Emerge from separate, opposite points", FileName = "leaflets_emerge.jpg", NavigationCommand = featherCommand });
            listView.ItemsSource = questionChoices;
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridLayout.Children.Add(listView, 0, 3);

            // Add grid layout to absolute layout and assign to Content
            pageLayout.Children.Add(gridLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            Content = pageLayout;

        }
    }
}

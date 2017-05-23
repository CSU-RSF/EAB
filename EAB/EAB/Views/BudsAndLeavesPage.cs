using Xamarin.Forms;
using EAB.Helpers;

namespace EAB
{
    public partial class BudsAndLeavesPage : ViewHelpers
    {
        public BudsAndLeavesPage()
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
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(80) });
            gridLayout.Children.Add(titleBarContainer, 0, 1);

            // Construct question and add to grid layout
            AbsoluteLayout questionContainer = ConstructQuestionContainer("How are the buds and smallest branches arranged? Examine them up close, for multiple examples.");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(120) });
            gridLayout.Children.Add(questionContainer, 0, 2);

            // Construct list of choices and add to grid layout
            ListView listView = ConstructListView(true);
            Command oppositeCommand = new Command(async () => { await Navigation.PushAsync(new LeavesTypePage()); });
            Command alternatingCommand = new Command(async () => { await Navigation.PushAsync(new OutcomeAPage()); });
            questionChoices.Add(new QuestionModel() { Text = "Opposite", FileName = "opposite.jpg", NavigationCommand = oppositeCommand });
            questionChoices.Add(new QuestionModel() { Text = "Alternating", FileName = "alternating.jpg", NavigationCommand = alternatingCommand });
            listView.ItemsSource = questionChoices;
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridLayout.Children.Add(listView, 0, 3);

            // Add grid layout to absolute layout and assign to Content
            pageLayout.Children.Add(gridLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            Content = pageLayout;
            
        }
    }
}

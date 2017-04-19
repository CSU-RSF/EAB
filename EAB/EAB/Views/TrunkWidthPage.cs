using Xamarin.Forms;
using EAB.Helpers;

namespace EAB
{
    public partial class TrunkWidthPage : ViewHelpers
    {
        public TrunkWidthPage()
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
            AbsoluteLayout questionContainer = ConstructQuestionContainer("How wide is the tree trunk?");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            gridLayout.Children.Add(questionContainer, 0, 2);

            // Construct list of choices and add to grid layout
            ListView listView = ConstructListView();
            Command greaterThanCommand = new Command(async () => { await Navigation.PushAsync(new DiamondShapedBarkPage()); });
            Command lessThanCommand = new Command(async () => { await Navigation.PushAsync(new OutcomeC2Page()); });
            questionChoices.Add(new QuestionModel() { Text = "Greater than 12\"", FileName = "greater_than_twelve_inches.jpg", NavigationCommand = greaterThanCommand });
            questionChoices.Add(new QuestionModel() { Text = "Less than 12\"", FileName = "less_than_twelve_inches.jpg", NavigationCommand = lessThanCommand });
            listView.ItemsSource = questionChoices;
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridLayout.Children.Add(listView, 0, 3);

            // Add grid layout to absolute layout and assign to Content
            pageLayout.Children.Add(gridLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            Content = pageLayout;
            
        }
    }
}

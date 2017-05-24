using Xamarin.Forms;
using EAB.Helpers;

namespace EAB
{
    public partial class DiamondShapedBarkPage : ViewHelpers
    {
        public DiamondShapedBarkPage()
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
            AbsoluteLayout questionContainer = ConstructQuestionContainer("Does the tree bark have a diamond-shaped pattern?");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            gridLayout.Children.Add(questionContainer, 0, 2);

            // Get image and add to grid layout
            Image image = new Image { Source = ImageSource.FromResource("EAB.Images.diamond_shaped.jpg"), Aspect = Aspect.AspectFit };
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            gridLayout.Children.Add(image, 0, 3);

            // Construct list of choices and add to grid layout
            ListView listView = ConstructListView();
            Command yesCommand = new Command(async () => { await Navigation.PushAsync(new OutcomeBPage()); });
            Command noCommand = new Command(async () => { await Navigation.PushAsync(new OutcomeAPage()); });
            Command notSureCommand = new Command(async () => { await Navigation.PushAsync(new OutcomeCPage()); });
            questionChoices.Add(new QuestionModel() { Text = "Yes", NavigationCommand = yesCommand });
            questionChoices.Add(new QuestionModel() { Text = "No", NavigationCommand = noCommand });
            questionChoices.Add(new QuestionModel() { Text = "I'm Not Sure", NavigationCommand = notSureCommand });
            listView.ItemsSource = questionChoices;
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridLayout.Children.Add(listView, 0, 4);

            // Add grid layout to absolute layout and assign to Content
            pageLayout.Children.Add(gridLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            Content = pageLayout;
            
        }
    }
}

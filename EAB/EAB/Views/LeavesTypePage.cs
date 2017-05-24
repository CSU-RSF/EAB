using Xamarin.Forms;
using EAB.Helpers;

namespace EAB
{
    public partial class LeavesTypePage : ViewHelpers
    {
        public LeavesTypePage()
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
            AbsoluteLayout questionContainer = ConstructQuestionContainer("What do the leaves look like?");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(60) });
            gridLayout.Children.Add(questionContainer, 0, 2);

            // Construct list of choices and add to grid layout
            ListView listView = ConstructListView();
            Command compoundCommand = new Command(async () => { await Navigation.PushAsync(new LeafletsShapePage()); });
            Command compoundImageCommand = new Command(async () => { await Navigation.PushModalAsync(new ImageModal("six_to_eleven_leaflets_big.jpg")); });
            Command simpleCommand = new Command(async () => { await Navigation.PushAsync(new OutcomeAPage()); });
            Command simpleImageCommand = new Command(async () => { await Navigation.PushModalAsync(new ImageModal("simple_big.jpg")); });
            Command noLeavesCommand = new Command(async () => { await Navigation.PushAsync(new TrunkWidthPage()); });
            questionChoices.Add(new QuestionModel() { Text = "Compound", Detail = "Multiple leaflets per stalk", FileName = "compound.jpg", ImageCommand = compoundImageCommand, NavigationCommand = compoundCommand });
            questionChoices.Add(new QuestionModel() { Text = "Simple", Detail = "Only one leaf per stalk", FileName = "simple.jpg", ImageCommand = simpleImageCommand, NavigationCommand = simpleCommand });
            questionChoices.Add(new QuestionModel() { Text = "It's Winter", Detail = "There are no leaves on the tree!", FileName = "winter.jpg", NavigationCommand = noLeavesCommand });
            questionChoices.Add(new QuestionModel() { Text = "I'm Not Sure", FileName = "question_mark.jpg", NavigationCommand = noLeavesCommand });
            listView.ItemsSource = questionChoices;
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridLayout.Children.Add(listView, 0, 3);

            // Add grid layout to absolute layout and assign to Content
            pageLayout.Children.Add(gridLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            Content = pageLayout;

        }
    }
}

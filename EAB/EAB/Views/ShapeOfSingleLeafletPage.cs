using Xamarin.Forms;
using EAB.Helpers;

namespace EAB
{
    public partial class ShapeOfSingleLeafletPage : ViewHelpers
    {
        public ShapeOfSingleLeafletPage()
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
            AbsoluteLayout questionContainer = ConstructQuestionContainer("The shape of a single leaflet is... ");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(64) });
            gridLayout.Children.Add(questionContainer, 0, 2);

            // Construct list of choices and add to grid layout
            ListView listView = ConstructListView(true);
            Command charCommand = new Command(async () => { await Navigation.PushAsync(new LeafletsShapePage()); });
            Command charImageCommand = new Command(async () => { await Navigation.PushModalAsync(new ImageModal("leaf_edge.png")); });
            questionChoices.Add(new QuestionModel() { Detail = "A 'characteristic' leaf shape", FileName = "leaf_edge.png", ImageCommand = charImageCommand, NavigationCommand = charCommand });

            Command leafShapeCommand = new Command(async () => { await Navigation.PushAsync(new OutcomeCPage()); });
            Command leafShapeImageCommand = new Command(async () => { await Navigation.PushModalAsync(new ImageModal("mapleoak.jpg")); });
            questionChoices.Add(new QuestionModel() { Text = "Some other leaf shape", FileName = "mapleoak.jpg", ImageCommand = leafShapeImageCommand, NavigationCommand = leafShapeCommand });

            Command noSureCommand = new Command(async () => { await Navigation.PushAsync(new LeafletsShapePage()); });
            Command noSureImageCommand = new Command(async () => { await Navigation.PushModalAsync(new ImageModal("question_mark.jpg")); });
            questionChoices.Add(new QuestionModel() { Text = "I'm not sure", FileName = "question_mark.jpg", ImageCommand = noSureImageCommand, NavigationCommand = noSureCommand });

            listView.ItemsSource = questionChoices;
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridLayout.Children.Add(listView, 0, 3);

            // Add grid layout to absolute layout and assign to Content
            pageLayout.Children.Add(gridLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            Content = pageLayout;

        }
    }
}

﻿using Xamarin.Forms;
using EAB.Helpers;

namespace EAB
{
    public partial class LeafletsNumberPage : ViewHelpers
    {
        public LeafletsNumberPage()
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
            AbsoluteLayout questionContainer = ConstructQuestionContainer("How many leaflets are on each leaf stalk?");
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(100) });
            gridLayout.Children.Add(questionContainer, 0, 2);

            // Construct list of choices and add to grid layout
            ListView listView = ConstructListView();
            Command threeCommand = new Command(async () => { await Navigation.PushAsync(new OutcomeAPage()); });
            Command threeImageCommand = new Command(async () => { await Navigation.PushModalAsync(new ImageModal("three_leaflets_big.jpg")); });
            Command fiveCommand = new Command(async () => { await Navigation.PushAsync(new TrunkWidthPage()); });
            Command fiveImageCommand = new Command(async () => { await Navigation.PushModalAsync(new ImageModal("five_leaflets_big.jpg")); });
            Command sixToElevenCommand = new Command(async () => { await Navigation.PushAsync(new OutcomeBPage()); });
            Command sixToElevenImageCommand = new Command(async () => { await Navigation.PushModalAsync(new ImageModal("leaflets_emerge_big.jpg")); });
            questionChoices.Add(new QuestionModel() { Text = "3 Leaflets", FileName = "three_leaflets.jpg", ImageCommand = threeImageCommand, NavigationCommand = threeCommand });
            questionChoices.Add(new QuestionModel() { Text = "5 Leaflets", FileName = "five_leaflets.jpg", ImageCommand = fiveImageCommand, NavigationCommand = fiveCommand });
            questionChoices.Add(new QuestionModel() { Text = "6-11 Leaflets", FileName = "leaflets_emerge.jpg", ImageCommand = sixToElevenImageCommand, NavigationCommand = sixToElevenCommand });
            questionChoices.Add(new QuestionModel() { Text = "I'm Not Sure", FileName = "question_mark.jpg", NavigationCommand = fiveCommand });
            listView.ItemsSource = questionChoices;
            gridLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            gridLayout.Children.Add(listView, 0, 3);

            // Add grid layout to absolute layout and assign to Content
            pageLayout.Children.Add(gridLayout, new Rectangle(0, 0, 1, 1), AbsoluteLayoutFlags.All);
            Content = pageLayout;
            
        }
    }
}

﻿namespace SampleApp
{
    using System.Collections.Generic;

    using LeoJHarris.EnhancedEntry.Plugin.Abstractions;
    using LeoJHarris.EnhancedEntry.Plugin.Abstractions.Helpers;

    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Page1 : ContentPage
    {
        public Page1()
        {
            EnhancedEntry advancedEntry = new EnhancedEntry
            {
                BorderColor = Color.Red,
                Placeholder = "Type an email in me...",
                FocusBorderColor = Color.Green,
                BackgroundColor = Color.Yellow,
                BorderWidth = 1,
                CornerRadius = 10,
                EmailValidatorBehavior = new EmailValidatorBehavior(),
                Keyboard = Keyboard.Email,
                ReturnKeyType = ReturnKeyTypes.Done
            };

            EnhancedEntry entryPasswordConfirm = new EnhancedEntry
            {
                BorderColor = Color.Red,
                BorderWidth = 1,
                CornerRadius = 2,
                Placeholder = "Password confirm"
            };

            EnhancedEntry passwordEntry = new EnhancedEntry
            {
                BorderColor = Color.Red,
                BorderWidth = 1,
                CornerRadius = 2,
                Placeholder = "Password",
                PasswordCompareValidation = new PasswordCompareValidationBehavior(new List<Entry>()
                {
                    entryPasswordConfirm
                })
                {
                    ValidColor = Color.Orange,
                    InValidColor = Color.Red
                },
            };

            entryPasswordConfirm.PasswordCompareValidation =
                new PasswordCompareValidationBehavior(new List<Entry>()
                {
                    passwordEntry
                })
                {
                    ValidColor = Color.Orange,
                    InValidColor = Color.Red
                };

            EnhancedEntry entry3 = new EnhancedEntry
            {
                BorderColor = Color.Red,
                BorderWidth = 1,
                CornerRadius = 2,
                Placeholder = "Tap done in keyboard to execute some code in keyboardaction...",
                KeyBoardAction = new Command(
                    () =>
                    {
                        DisplayAlert("Tapped", "Action executed", "OK");
                    }),
            };

            EnhancedEntry entry1 = new EnhancedEntry
            {
                BorderColor = Color.Red,
                Placeholder = "Jump to next entry on Next",
                BorderWidth = 1,
                CornerRadius = 2,
                NextEntry = entry3,
                ReturnKeyType = ReturnKeyTypes.Next
            };


            EnhancedEntry entry4 = new EnhancedEntry
            {
                BorderColor = Color.Red,
                Placeholder = "Focus next entry when text length is 2",
                BorderWidth = 1,
                CornerRadius = 2,
                NextEntry = entry3,
                ReturnKeyType = ReturnKeyTypes.Done,
                GoToNextEntryOnLengthBehaviour = new GoToNextEntryOnLengthBehaviour(advancedEntry)
                {
                    CharacterLength = 2
                },
            };

            if (entryPasswordConfirm.PasswordCompareValidation.IsValid && entryPasswordConfirm.PasswordCompareValidation.IsValid)
            {
                this.DisplayAlert("Passwords match!", "Both passwords match", "OK");
            }

            StackLayout stack = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Spacing = 10,
                Margin = 20,
                Children =
                {
                    new ContentView
                        {
                        VerticalOptions = LayoutOptions.Fill,
                        Content = advancedEntry
                        },
                    new ContentView
                    {
                        VerticalOptions = LayoutOptions.Fill,
                                                        Content = passwordEntry
                                                    },
                                                new ContentView
                                                    {
                                                        VerticalOptions = LayoutOptions.Fill,
                                                        Content = entryPasswordConfirm
                                                    },
                                                new ContentView
                                                    {
                                                        VerticalOptions = LayoutOptions.Fill,
                                                        Content = entry1
                                                    },
                                                new ContentView
                                                    {
                                                        VerticalOptions = LayoutOptions.Fill,
                                                        Content = entry4
                                                    },
                                                new ContentView
                                                    {
                                                        VerticalOptions = LayoutOptions.Fill,
                                                        Content = entry3
                                                    }
                                            }
            };

            ScrollView scrollView = new ScrollView
            {
                Content = stack
            };

            Content = scrollView;

            InitializeComponent();
        }
    }
}
﻿
using System.Collections.Generic;

using LeoJHarris.AdvancedEntry.Plugin.Abstractions.Helpers;

namespace App1
{
    using LeoJHarris.AdvancedEntry.Plugin.Abstractions;

    public partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            EnhancedEntry advancedEntry = new EnhancedEntry
            {
                BorderColor = Color.Red,
                Placeholder = "Type an email in me...",
                FocusBorderColor = Color.Green,
                BackgroundColor = Color.Yellow,
                BorderWidth = 1,
                CornerRadius = 2,
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
                            this.DisplayAlert("Tapped", "Action executed", "OK");
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

            this.CVAdvancedEntry1.Content = advancedEntry;
            this.CVAdvancedEntry2.Content = passwordEntry;
            this.CVAdvancedEntry3.Content = entryPasswordConfirm;
            this.CVAdvancedEntry4.Content = entry1;
            this.CVAdvancedEntry5.Content = entry1;
            this.CVAdvancedEntry6.Content = entry4;
            this.CVAdvancedEntry7.Content = entry3;
        }
    }
}

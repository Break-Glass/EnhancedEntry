﻿using EnhancedEntry.FormsPlugin.Abstractions.Effects;

namespace LeoJHarris.EnhancedEntry.Plugin.Abstractions
{
    using System;

    using LeoJHarris.EnhancedEntry.Plugin.Abstractions.Helpers;

    using Xamarin.Forms;


    public class EnhancedEntry : Entry
    {
        /// <summary>
        /// Left icon (Place images definitions in each of the drawable folders for android)
        /// </summary>
        public string LeftIcon
        {
            get => (string)this.GetValue(LeftIconProperty);

            set => this.SetValue(LeftIconProperty, value);
        }

        /// <summary>
        /// Padding for the left icon drawable
        /// </summary>
        public int PaddingLeftIcon
        {
            get => (int)this.GetValue(PaddingIconTextBindableProperty);

            set => this.SetValue(PaddingIconTextBindableProperty, value);
        }

        /// <summary>
        /// Border width
        /// </summary>
        public double BorderWidth
        {
            get => (double)this.GetValue(BorderWidthBindableProperty);

            set => this.SetValue(BorderWidthBindableProperty, value);
        }


        private event EventHandler EventTriggered;

        public const string ReturnKeyPropertyName = "ReturnKeyType";

        private static readonly BindableProperty LeftIconProperty =
            BindableProperty.Create(nameof(LeftIcon), typeof(string), typeof(EnhancedEntry), string.Empty);


        private static readonly BindableProperty PaddingIconTextBindableProperty =
            BindableProperty.Create(nameof(PaddingLeftIcon), typeof(int), typeof(EnhancedEntry), 10);

        private static readonly BindableProperty BorderWidthBindableProperty =
            BindableProperty.Create(nameof(BorderWidth), typeof(double), typeof(EnhancedEntry), 0.5);



        private static readonly BindableProperty CornerRadiusBindableProperty =
            BindableProperty.Create(nameof(CornerRadius), typeof(int), typeof(EnhancedEntry), 5);

        /// <summary>
        /// Corner radius
        /// </summary>
        public int CornerRadius
        {
            get => (int)this.GetValue(CornerRadiusBindableProperty);

            set => this.SetValue(CornerRadiusBindableProperty, value);
        }

        public static readonly BindableProperty LeftPaddingBindableProperty
            = BindableProperty.Create(nameof(LeftPadding), typeof(int), typeof(EnhancedEntry), 6);

        public int LeftPadding
        {
            get => (int)this.GetValue(LeftPaddingBindableProperty);

            set => this.SetValue(LeftPaddingBindableProperty, value);
        }
        public static readonly BindableProperty RightPaddingBindableProperty
            = BindableProperty.Create(nameof(RightPadding), typeof(int), typeof(EnhancedEntry), 6);

        /// <summary>
        /// Right padding
        /// </summary>
        public int RightPadding
        {
            get => (int)this.GetValue(RightPaddingBindableProperty);

            set => this.SetValue(RightPaddingBindableProperty, value);
        }

        public static readonly BindableProperty TopBottomPaddingBindableProperty
            = BindableProperty.Create(nameof(TopBottomPadding), typeof(int), typeof(EnhancedEntry), 0);

        /// <summary>
        /// Specified top/bottom padding
        /// </summary>
        public int TopBottomPadding
        {
            get => (int)this.GetValue(TopBottomPaddingBindableProperty);

            set => this.SetValue(TopBottomPaddingBindableProperty, value);
        }


        public static readonly BindableProperty FocusBorderColorBindableProperty
            = BindableProperty.Create(nameof(FocusBorderColor), typeof(Color),
                typeof(EnhancedEntry), Color.Transparent);

        /// <summary>
        /// Background color On focus of entry
        /// </summary>
        public Color FocusBorderColor
        {
            get => (Color)this.GetValue(FocusBorderColorBindableProperty);

            set => this.SetValue(FocusBorderColorBindableProperty, value);
        }
        public static readonly BindableProperty BorderColorProperty =
            BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(EnhancedEntry),
                Color.Transparent, propertyChanged: PropertyBorderColorChanged);

        private static void PropertyBorderColorChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is EnhancedEntry context)
            {
                context.FocusBorderColor = (Color)newValue;
            }
        }

        /// <summary>
        /// Border color requires <see cref="BorderWidth"/> to be set
        /// </summary>
        public Color BorderColor
        {
            get => (Color)this.GetValue(BorderColorProperty);

            set => this.SetValue(BorderColorProperty, value);
        }

        public static readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color),
                typeof(EnhancedEntry), Color.White);

        /// <summary>
        /// Background color 
        /// </summary>
        public Color BackgroundColor
        {
            get => (Color)this.GetValue(BackgroundColorProperty);

            set => this.SetValue(BackgroundColorProperty, value);
        }

        public static readonly BindableProperty HasShowAndHidePasswordProperty =
            BindableProperty.Create(nameof(HasShowAndHidePassword), typeof(bool),
                typeof(EnhancedEntry), false);

        /// <summary>
        /// Background color 
        /// </summary>
        public bool HasShowAndHidePassword
        {
            get => (bool)this.GetValue(HasShowAndHidePasswordProperty);

            set => this.SetValue(HasShowAndHidePasswordProperty, value);
        }

        /// <summary>
        /// GoToNextEntryOnLengthBindableProperty
        /// </summary>
        public static readonly BindableProperty GoToNextEntryOnLengthBindableProperty =
            BindableProperty.Create(nameof(GoToNextEntryOnLengthBehaviour),
                typeof(GoToNextEntryOnLengthBehaviour),
                typeof(EnhancedEntry), propertyChanged: PropertyGoToNextChanged);

        private static void PropertyGoToNextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is EnhancedEntry context)
            {
                context.Behaviors.Add((GoToNextEntryOnLengthBehaviour)newValue);
            }
        }

        /// <summary>
        /// Jump next to entry behaviour, requires <see cref="NextEntry"/> to be set.
        /// </summary>
        [Obsolete("Add to Behavior collection instead")]
        public GoToNextEntryOnLengthBehaviour GoToNextEntryOnLengthBehaviour
        {
            get => (GoToNextEntryOnLengthBehaviour)this.GetValue(GoToNextEntryOnLengthBindableProperty);

            set => this.SetValue(GoToNextEntryOnLengthBindableProperty, value);
        }

        /// <summary>
        /// GoToNextEntryOnLengthBindableProperty
        /// </summary>
        public static readonly BindableProperty EmailValidatorBehaviorBindableProperty =
            BindableProperty.Create(nameof(EmailValidatorBehavior), typeof(EmailValidatorBehavior),
                typeof(EnhancedEntry), propertyChanged: PropertyEmailValidatorChanged);

        private static void PropertyEmailValidatorChanged(BindableObject bindable,
            object oldValue, object newValue)
        {
            if (bindable is EnhancedEntry context)
            {
                context.Behaviors.Add((EmailValidatorBehavior)newValue);
            }
        }

        /// <summary>
        /// Sets the email to entry.
        /// </summary>
        [Obsolete("Add to Behavior collection instead")]
        public EmailValidatorBehavior EmailValidatorBehavior
        {
            get => (EmailValidatorBehavior)this.GetValue(EmailValidatorBehaviorBindableProperty);
            set => this.SetValue(EmailValidatorBehaviorBindableProperty, value);
        }

        public static readonly BindableProperty PasswordCompareValidationBindableProperty =
            BindableProperty.Create(nameof(PasswordCompareValidation),
                typeof(PasswordCompareValidationBehavior),
                typeof(EnhancedEntry), propertyChanged: PropertyChanged);

        private static void PropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is EnhancedEntry context)
            {
                context.Behaviors.Add((PasswordCompareValidationBehavior)newValue);
            }
        }

        public static readonly BindableProperty NextEntryBindableProperty =
            BindableProperty.Create(nameof(NextEntry), typeof(EnhancedEntry),
                typeof(EnhancedEntry));

        /// <summary>
        /// The Entry with next focus.
        /// </summary>
        public EnhancedEntry NextEntry
        {
            get => (EnhancedEntry)this.GetValue(NextEntryBindableProperty);

            set => this.SetValue(NextEntryBindableProperty, value);
        }

        /// <summary>
        /// Password compare validation
        /// </summary>
        [Obsolete("Add to Behavior collection instead")]
        public PasswordCompareValidationBehavior PasswordCompareValidation
        {
            get => (PasswordCompareValidationBehavior)
                this.GetValue(PasswordCompareValidationBindableProperty);
            set => this.SetValue(PasswordCompareValidationBindableProperty, value);
        }

        /// <summary>
        /// Enhanced entry
        /// </summary>
        public EnhancedEntry()
        {
            this.EventTriggered += Goto;
            
            this.Effects.Add(new ShowHiddenEntryEffect());
        }



        /// <summary>
        /// The keyboard action command, please set <see cref="ReturnKeyType"/>
        /// </summary>
        public Command KeyBoardAction { get; set; }


        private static void Goto(object sender, EventArgs e)
        {
            ((EnhancedEntry)sender)?.KeyBoardAction?.Execute(null);
            ((EnhancedEntry)sender)?.NextEntry?.Focus();
        }

        private static readonly BindableProperty ReturnTypeProperty =
            BindableProperty.Create(nameof(ReturnKeyType), typeof(ReturnKeyTypes),
                typeof(EnhancedEntry), ReturnKeyTypes.Done);

        public ReturnKeyTypes ReturnKeyType
        {
            get { return (ReturnKeyTypes)this.GetValue(ReturnTypeProperty); }
            set
            {
                this.SetValue(ReturnTypeProperty, value);
            }
        }

        public void EntryActionFired()
        {
            this.EventTriggered?.Invoke(this, null);
        }

        private static readonly BindableProperty UITextBorderStyleBindableProperty =
            BindableProperty.Create(nameof(UITextBorderStyle), typeof(TextBorderStyle),
                typeof(EnhancedEntry), TextBorderStyle.None);

        /// <summary>
        /// iOS border style
        /// </summary>
        public TextBorderStyle UITextBorderStyle
        {
            get => (TextBorderStyle)this.GetValue(UITextBorderStyleBindableProperty);
            set => this.SetValue(UITextBorderStyleBindableProperty, value);
        }
    }

    /// <summary>
    /// Specify the keyboard action button text.
    /// </summary>
    public enum ReturnKeyTypes
    {
        Default,
        Go,
        Google,
        Join,
        Next,
        Route,
        Search,
        Send,
        Yahoo,
        Done,
        EmergencyCall,
        Continue
    }

    /// <summary>
    /// Used for iOS only to determine the border style.
    /// </summary>
    public enum TextBorderStyle : long
    {
        None = 0,
        Line = 1,
        Bezel = 2,
        RoundedRect = 3
    }
}

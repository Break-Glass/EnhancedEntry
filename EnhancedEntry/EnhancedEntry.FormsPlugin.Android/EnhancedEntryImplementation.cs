using System;
using System.ComponentModel;
using System.Reflection;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Text.Method;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using LeoJHarris.FormsPlugin.Abstractions;
using LeoJHarris.FormsPlugin.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EnhancedEntry), typeof(EnhancedEntryRenderer))]
namespace LeoJHarris.FormsPlugin.Droid
{
    /// <summary>
    /// 
    /// </summary>
    public class EnhancedEntryRenderer : EntryRenderer
    {
        private readonly Context _context;

        public EnhancedEntryRenderer(Context context) : base(context)
        {
            AutoPackage = false;
            _context = context;
        }

        private static string PackageName
        {
            get;
            set;
        }

        private GradientDrawable _gradietDrawable;

        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public static void Init(Context context) { PackageName = context.PackageName; }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (!((Control != null) & (e.NewElement != null))) return;

            if (!(e.NewElement is EnhancedEntry entryExt)) return;
            {
                Control.ImeOptions = GetValueFromDescription(entryExt.ReturnKeyType);

                Control.SetImeActionLabel(entryExt.ReturnKeyType.ToString(), Control.ImeOptions);

                _gradietDrawable = new GradientDrawable();
                _gradietDrawable.SetShape(ShapeType.Rectangle);
                _gradietDrawable.SetColor(entryExt.BackgroundColor.ToAndroid());
                _gradietDrawable.SetCornerRadius(entryExt.CornerRadius);
                _gradietDrawable.SetStroke((int)entryExt.BorderWidth, entryExt.BorderColor.ToAndroid());


                Rect padding = new Rect
                {
                    Left = entryExt.LeftPadding,
                    Right = entryExt.RightPadding,
                    Top = entryExt.TopBottomPadding / 2,
                    Bottom = entryExt.TopBottomPadding / 2
                };
                _gradietDrawable.GetPadding(padding);

                e.NewElement.Focused += (sender, evt) =>
                {
                    _gradietDrawable.SetStroke(
                        (int)entryExt.BorderWidth,
                        entryExt.FocusBorderColor.ToAndroid());
                };

                e.NewElement.Unfocused += (sender, evt) =>
                {
                    _gradietDrawable.SetStroke((int)entryExt.BorderWidth, entryExt.BorderColor.ToAndroid());
                };

                Control.SetBackground(_gradietDrawable);

                if (Control != null && !string.IsNullOrEmpty(PackageName))
                {
                    if (!string.IsNullOrEmpty(entryExt.LeftIcon))
                    {
                        int identifier = Context.Resources.GetIdentifier(
                            entryExt.LeftIcon,
                            "drawable",
                            PackageName);
                        if (identifier != 0)
                        {
                            Drawable drawable = Resources.GetDrawable(identifier);
                            if (drawable != null)
                            {
                                Control.SetCompoundDrawablesWithIntrinsicBounds(drawable, null, null, null);
                                Control.CompoundDrawablePadding = entryExt.PaddingLeftIcon;
                            }
                        }
                    }
                }

                Control.EditorAction += (sender, args) =>
                {
                    if (entryExt.NextEntry == null)
                    {
                        if (_context.GetSystemService(Context.InputMethodService) is InputMethodManager inputMethodManager && _context is Activity)
                        {
                            Activity activity = (Activity)_context;
                            IBinder token = activity.CurrentFocus?.WindowToken;
                            inputMethodManager.HideSoftInputFromWindow(token, HideSoftInputFlags.None);

                            activity.Window.DecorView.ClearFocus();
                        }
                    }

                    entryExt.EntryActionFired();
                };
            }
        }

        public class OnDrawableTouchListener : Java.Lang.Object, IOnTouchListener
        {
            public bool OnTouch(Android.Views.View v, MotionEvent e)
            {
                if (v is EditText editText && e.Action == MotionEventActions.Up)
                {
                    if (e.RawX >= (editText.Right - editText.GetCompoundDrawables()[2].Bounds.Width()))
                    {
                        editText.TransformationMethod = editText.TransformationMethod == null ? PasswordTransformationMethod.Instance : null;

                        return true;
                    }
                }

                return false;
            }
        }

        /// <summary>
        /// The on element property changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName != EnhancedEntry.ReturnKeyPropertyName) return;
            if (!(sender is EnhancedEntry entryExt)) return;
            Control.ImeOptions = GetValueFromDescription(entryExt.ReturnKeyType);
            Control.SetImeActionLabel(entryExt.ReturnKeyType.ToString(), Control.ImeOptions);
        }

        private static ImeAction GetValueFromDescription(ReturnKeyTypes value)
        {
            Type type = typeof(ImeAction);
            if (!type.IsEnum) throw new InvalidOperationException();
            foreach (FieldInfo field in type.GetFields())
            {
                if (Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == value.ToString()) return (ImeAction)field.GetValue(null);
                }
                else
                {
                    if (field.Name == value.ToString()) return (ImeAction)field.GetValue(null);
                }
            }

            throw new NotSupportedException($"Not supported on Android: {value}");
        }
    }
}
using A11YTools.Droid;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ContentPage), typeof(AccessiblePageRenderer))]
namespace A11YTools.Droid
{
    public class AccessiblePageRenderer : PageRenderer
    {
        public AccessiblePageRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            Clickable = false;
        }

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();
            DisableFocusableInTouchMode();
        }

        protected override void AttachViewToParent(Android.Views.View child, int index, LayoutParams @params)
        {
            base.AttachViewToParent(child, index, @params);
            DisableFocusableInTouchMode();
        }

        void DisableFocusableInTouchMode()
        {
            var view = Parent;
            string className = $"{view?.GetType().Name}";

            while (!className.Contains("PlatformRenderer") && view != null)
            {
                view = view.Parent;
                className = $"{view?.GetType().Name}";
            }

            if (view is global::Android.Views.View androidView)
            {
                androidView.Focusable = false;
                androidView.FocusableInTouchMode = false;
            }
        }
    }
}
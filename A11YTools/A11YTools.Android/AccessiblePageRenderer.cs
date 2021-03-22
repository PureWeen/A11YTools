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
            Focusable = false;
            ImportantForAccessibility = ImportantForAccessibility.No;
            Clickable = false;
        }
    }
}
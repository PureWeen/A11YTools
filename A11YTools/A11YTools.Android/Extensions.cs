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

namespace A11YTools.Droid
{
    public static class Extensions
    {
        public static global::Android.Views.View GetViewForAccessibility(this VisualElement visualElement)
        {
            var renderer = Platform.GetRenderer(visualElement);

            if (visualElement is Layout)
                return renderer?.View;
            else if (renderer is ViewGroup vg && vg.ChildCount > 0)
                return vg.GetChildAt(0);
            else if (renderer != null)
                return renderer.View;

            return null;
        }
    }
}
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("A11YTools")]
[assembly: ExportEffect(typeof(A11YTools.Droid.AccessibilityFixesEffect), nameof(A11YTools.Droid.AccessibilityFixesEffect))]
namespace A11YTools.Droid
{
    public class AccessibilityFixesEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            ApplyFixes();
            Device.BeginInvokeOnMainThread(ApplyFixes);
        }

        void ApplyFixes()
        {
            var renderer = Platform.GetRenderer((VisualElement)Element);
            var nativeView = Platform.GetRenderer((VisualElement)Element)?.View;

            var accessibilityView = ((VisualElement)Element).GetViewForAccessibility();

            if (nativeView != null && nativeView.ContentDescription?.EndsWith("Container") == true)
            {
                nativeView.ImportantForAccessibility = ImportantForAccessibility.No;
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
using A11YTools.Droid;
using AndroidX.Core.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(A11YTools.Droid.NativeSemanticEffect), nameof(A11YTools.Droid.NativeSemanticEffect))]
namespace A11YTools.Droid
{
    public class NativeSemanticEffect : PlatformEffectBase<A11YTools.NativeSemanticEffect>
    {

        protected override void Update(Android.Views.View view, A11YTools.NativeSemanticEffect effect)
        {
            bool isHeading = SemanticEffect.GetIsHeading(Element);
            ViewCompat.SetAccessibilityHeading(view, isHeading);
        }


        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == SemanticEffect.IsHeadingProperty.PropertyName)
            {
                Update();
            }
        }
    }
}
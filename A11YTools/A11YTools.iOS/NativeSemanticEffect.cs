using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

[assembly: ExportEffect(typeof(A11YTools.iOS.NativeSemanticEffect), nameof(A11YTools.iOS.NativeSemanticEffect))]
namespace A11YTools.iOS
{
    public class NativeSemanticEffect : PlatformEffectBase<A11YTools.NativeSemanticEffect>
    {

        protected override void Update(UIView view, A11YTools.NativeSemanticEffect effect)
        {
            bool isHeading = SemanticEffect.GetIsHeading(Element);

            if(isHeading)
                view.AccessibilityTraits |= UIAccessibilityTrait.Header;
            else
                view.AccessibilityTraits &= ~UIAccessibilityTrait.Header;
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
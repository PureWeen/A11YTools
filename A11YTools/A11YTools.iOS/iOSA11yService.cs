using System;
using Xamarin.Forms;
using A11YTools.iOS;
using UIKit;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(iOSA11yService))]
namespace A11YTools.iOS
{
    public class iOSA11yService : IA11yService
    {
        public void SetFocus(VisualElement element)
        {
            var nativeView = Platform.GetRenderer(element).NativeView;
            UIAccessibility.PostNotification(UIAccessibilityPostNotification.LayoutChanged, nativeView);
        }

        public void SetControlType(VisualElement element, ControlType controlType)
        {
            var nativeView = Platform.GetRenderer(element).NativeView;

            switch (controlType)
            {
                case ControlType.Button:
                    nativeView.AccessibilityTraits = UIAccessibilityTrait.Button;
                    break;
                case ControlType.Default:
                    nativeView.AccessibilityTraits = UIAccessibilityTrait.None;
                    break;
            }
        }

        public void SetIsClickable(VisualElement element, bool isClickable, Action action)
        {
            
            if (isClickable)
            {
                SetControlType(element, ControlType.Button);
            }
            else
            {
                SetControlType(element, ControlType.Default);
            }
        }
    }
}

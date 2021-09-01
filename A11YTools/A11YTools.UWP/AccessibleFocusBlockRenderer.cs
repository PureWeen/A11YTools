using A11YTools.UWP;
using A11YTools.Views;
using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(AccessibleFocusBlock), typeof(AccessibleFocusBlockRenderer))]
namespace A11YTools.UWP
{
    public class AccessibleFocusBlockRenderer : ViewRenderer<AccessibleFocusBlock, Windows.UI.Xaml.Controls.Button>
    {
        private Windows.UI.Xaml.Controls.Button accessibilityHiddenBtn = null;

        protected override void OnElementChanged(ElementChangedEventArgs<AccessibleFocusBlock> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null && accessibilityHiddenBtn != null)
            {
                accessibilityHiddenBtn.GotFocus -= AccessibilityHiddenBtn_GotFocus;
                accessibilityHiddenBtn.LostFocus -= AccessibilityHiddenBtn_LostFocus;
                accessibilityHiddenBtn = null;

                SetNativeControl(null);
            }

            if (e.NewElement != null)
            {
                accessibilityHiddenBtn = new Windows.UI.Xaml.Controls.Button();
                accessibilityHiddenBtn.IsTabStop = e.NewElement.IsTabStop;
                accessibilityHiddenBtn.IsHitTestVisible = false;
                accessibilityHiddenBtn.IsEnabled = false;
                accessibilityHiddenBtn.Visibility = e.NewElement.IsTabStop && e.NewElement.IsEnabled && e.NewElement.IsVisible ? Visibility.Visible : Visibility.Collapsed;
                accessibilityHiddenBtn.UseSystemFocusVisuals = false;
                accessibilityHiddenBtn.GotFocus += AccessibilityHiddenBtn_GotFocus;
                accessibilityHiddenBtn.LostFocus += AccessibilityHiddenBtn_LostFocus;
                Canvas.SetZIndex(accessibilityHiddenBtn, -1);

                SetNativeControl(accessibilityHiddenBtn);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && Control != null)
            {
                accessibilityHiddenBtn.GotFocus -= AccessibilityHiddenBtn_GotFocus;
                accessibilityHiddenBtn.LostFocus -= AccessibilityHiddenBtn_LostFocus;
                accessibilityHiddenBtn = null;

                SetNativeControl(null);
            }
            base.Dispose(disposing);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            switch (e.PropertyName)
            {
                case nameof(Element.IsEnabled):
                case nameof(Element.IsTabStop):
                case nameof(Element.IsVisible):
                    accessibilityHiddenBtn.Visibility = Element.IsTabStop && Element.IsEnabled && Element.IsVisible ? Visibility.Visible : Visibility.Collapsed;
                    break;
            }
        }

        private void AccessibilityHiddenBtn_GotFocus(object sender, RoutedEventArgs e)
        {
            Element?.OnAccessibilityGotFocus();
        }

        private void AccessibilityHiddenBtn_LostFocus(object sender, RoutedEventArgs e)
        {
            Element?.OnAccessibilityLostFocus();
        }
    }
}
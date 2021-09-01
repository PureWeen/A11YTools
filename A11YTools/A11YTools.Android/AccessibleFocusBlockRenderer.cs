using A11YTools.UWP;
using A11YTools.Views;
using Android.Content;
using Android.Views.Accessibility;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AccessibleFocusBlock), typeof(AccessibleFocusBlockRenderer))]
namespace A11YTools.UWP
{
    public class AccessibleFocusBlockRenderer : ViewRenderer<AccessibleFocusBlock, Android.Views.View>
    {
        public AccessibleFocusBlockRenderer(Context context) : base(context)
        {

        }

        public override void OnInitializeAccessibilityEvent(AccessibilityEvent e)
        {
            base.OnInitializeAccessibilityEvent(e);

            if (e.EventType == EventTypes.ViewAccessibilityFocused)
            {
                Element?.OnAccessibilityGotFocus();
            }
            else if (e.EventType == EventTypes.ViewAccessibilityFocusCleared)
            {
                Element?.OnAccessibilityLostFocus();
            }
        }
    }
}
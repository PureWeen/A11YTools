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
        private bool isFocused = false;

        public AccessibleFocusBlockRenderer(Context context) : base(context)
        {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<AccessibleFocusBlock> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                FocusChange += Control_FocusChange;
            }
            else
            {
                FocusChange -= Control_FocusChange;
            }
        }

        private void Control_FocusChange(object sender, FocusChangeEventArgs e)
        {
            if (e.HasFocus)
            {
                if (!isFocused)
                    Element?.OnAccessibilityGotFocus();

                isFocused = true;
            }
            else
            {
                if (isFocused)
                    Element?.OnAccessibilityLostFocus();

                isFocused = false;
            }
        }

        public override void OnInitializeAccessibilityEvent(AccessibilityEvent e)
        {
            base.OnInitializeAccessibilityEvent(e);

            if (e.EventType == EventTypes.ViewAccessibilityFocused)
            {
                if (!isFocused)
                    Element?.OnAccessibilityGotFocus();

                isFocused = true;
            }
            else if (e.EventType == EventTypes.ViewAccessibilityFocusCleared)
            {
                if (isFocused)
                    Element?.OnAccessibilityLostFocus();

                isFocused = false;
            }
        }
    }
}
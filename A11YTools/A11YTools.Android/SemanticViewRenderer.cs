using A11YTools;
using A11YTools.Droid;
using Android.Content;
using Android.Views.Accessibility;
using Java.Lang;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SemanticView), typeof(SemanticViewRenderer))]
namespace A11YTools.Droid
{
    public class SemanticViewRenderer : VisualElementRenderer<SemanticView>
    {
        public SemanticViewRenderer(Context context) : base(context)
        {
            ImportantForAccessibility =
                Android.Views.ImportantForAccessibility.Yes;
        }

        public override ICharSequence AccessibilityClassNameFormatted =>
            new Java.Lang.String("android.widget.RadioButton");

        public override void OnInitializeAccessibilityNodeInfo(AccessibilityNodeInfo info)
        {
            base.OnInitializeAccessibilityNodeInfo(info);

            var rb = Element.Content as RadioButton;
            var sl = rb.Parent.Parent as StackLayout;
            var index = sl.Children.IndexOf(rb.Parent as View);

            info.SetCollectionItemInfo(
                new AccessibilityNodeInfo.CollectionItemInfo(index, 1, 0, 1, false, 
                (Element.Content as RadioButton)?.IsChecked ?? false));

            info.ClassName = "android.widget.RadioButton";
            info.Clickable = true;
            info.Checkable = true;
            info.Checked = (Element.Content as RadioButton)?.IsChecked ?? false;
            
            var view = GetChildAt(0);
            view.ImportantForAccessibility = Android.Views.ImportantForAccessibility.NoHideDescendants;
        }
    }
}
using A11YTools;
using A11YTools.Droid;
using Android.Content;
using Android.Views.Accessibility;
using Java.Lang;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SemanticView), typeof(SemanticGroupViewRenderer))]
namespace A11YTools.Droid
{
    public class SemanticGroupViewRenderer : VisualElementRenderer<SemanticView>
    {
        public SemanticGroupViewRenderer(Context context) : base(context)
        {
            ImportantForAccessibility = 
                Android.Views.ImportantForAccessibility.Yes;
        }

        public override ICharSequence AccessibilityClassNameFormatted =>
            new Java.Lang.String("android.widget.RadioGroup");

        public override void OnInitializeAccessibilityNodeInfo(AccessibilityNodeInfo info)
        {
            base.OnInitializeAccessibilityNodeInfo(info);

            info.SetCollectionInfo(new AccessibilityNodeInfo.CollectionInfo(2, 1, false, 
                (int)global::Android.Views.Accessibility.SelectionMode.Single));
                        
            info.ClassName = "android.widget.RadioGroup";
            //info.ChildCount = 2;
        }
    }
}
using A11YTools.Droid;
using Android.Views;
using Android.Views.Accessibility;
using AndroidX.Core.View.Accessibiity;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: Dependency(typeof(AndroidA11yService))]
namespace A11YTools.Droid
{
    public class AndroidA11yService : IA11yService
    {
        public void SetControlType(VisualElement element, ControlType controlType)
        {
            var renderer = Platform.GetRenderer(element);
            var view = GetView(element);
            
            if (view == null)
                return;

            if (controlType == ControlType.Default)
                view.SetAccessibilityDelegate(null);
            else
                view.SetAccessibilityDelegate(new MyAccessibilityDelegate(controlType));
        }

        class MyAccessibilityDelegate : Android.Views.View.AccessibilityDelegate
        {
            private ControlType controlType;

            public MyAccessibilityDelegate(ControlType controlType)
            {
                this.controlType = controlType;
            }

            public override void OnInitializeAccessibilityNodeInfo(Android.Views.View host, AccessibilityNodeInfo info)
            {
                base.OnInitializeAccessibilityNodeInfo(host, info);                
                switch(controlType)
                {
                    case ControlType.Button:
                        info.ClassName = "android.widget.Button";
                       // info.ContentDescription = "I am the description";
                        info.Clickable = true;
                        break;
                }
            }
        }

        public void SetIsClickable(VisualElement element, bool isClickable, System.Action action)
        {
            var renderer = Platform.GetRenderer(element);
            var view = GetView(element);
            if (view == null)
                return;

            view.Clickable = isClickable;
            view.Click += (_, __) =>
            {
                action?.Invoke();
            };
        }

        public void SetFocus(VisualElement element)
        {
            var renderer = Platform.GetRenderer(element);
            var view = GetView(element);

            view?.SendAccessibilityEvent(Android.Views.Accessibility.EventTypes.ViewFocused);
        }

        global::Android.Views.View GetView(VisualElement visualElement)
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
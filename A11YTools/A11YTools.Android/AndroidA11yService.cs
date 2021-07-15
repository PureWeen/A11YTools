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
            var view = element.GetViewForAccessibility();

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
                        info.Clickable = true;
                        break;
                }
            }
        }

        public void SetIsClickable(VisualElement element, bool isClickable, System.Action action)
        {
            var renderer = Platform.GetRenderer(element);
            var view = element.GetViewForAccessibility();
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
            var view = element.GetViewForAccessibility();

            view?.SendAccessibilityEvent(EventTypes.ViewAccessibilityFocused);
        }

        public void SetAnnouncement(string text)
        {
            AccessibilityManager manager = (AccessibilityManager)Android.App.Application.Context.GetSystemService(Android.App.Application.AccessibilityService);

            if (!(manager.IsEnabled || manager.IsTouchExplorationEnabled))
                return;

            // Sends the accessibility event to announce.
            AccessibilityEvent e = AccessibilityEvent.Obtain();
            e.EventType = EventTypes.Announcement;
            e.Text.Add(new Java.Lang.String(text));
            manager.SendAccessibilityEvent(e);
        }
    }
}
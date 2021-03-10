using A11YTools;
using A11YTools.iOS;
using A11YTools.Views;
using Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AccessibilityContentView), typeof(AccessibilityContentViewRenderer))]
namespace A11YTools.iOS
{
    public class AccessibilityContentViewRenderer : ViewRenderer, IUIAccessibilityContainer
    {


        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);

            var result = this.GetAccessibilityElements();

            if(result != null)
                this.SetAccessibilityElements(NSArray.FromNSObjects(result.ToArray()));
        }


        AccessibilityContentView AccessibilityContentView => (AccessibilityContentView)Element;
        #region Accessibility

        private List<NSObject> GetAccessibilityElements()
        {
            var viewOrder = AccessibilityContentView.ViewOrder;

            List<NSObject> returnValue = new List<NSObject>();
            foreach(View view in viewOrder)
            {
                returnValue.Add(Platform.GetRenderer(view).NativeView);
            }

            if (returnValue.Count == 0)
                return null;

            return returnValue;
        }

        #endregion
    }
}

using A11YTools;
using A11YTools.Droid;
using A11YTools.Views;
using Android.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(SemanticView), typeof(SemanticViewRenderer))]
namespace A11YTools.Droid
{
    public class SemanticViewRenderer : ViewRenderer
    {
        SemanticView AccessibilityContentView => (SemanticView)Element;

        public SemanticViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<View> e)
        {
            base.OnElementChanged(e);
            this.SetAccessibilityElements();
        }

        protected override void OnLayout(bool changed, int left, int top, int right, int bottom)
        {
            this.SetAccessibilityElements();
            base.OnLayout(changed, left, top, right, bottom);
        }

        void SetAccessibilityElements()
        {
            var viewOrder = AccessibilityContentView.ViewOrder.OfType<View>().ToList();

            for (int i = 1; i < viewOrder.Count; i++)
            {
                var view1 = viewOrder[i - 1].GetViewForAccessibility();
                var view2 = viewOrder[i].GetViewForAccessibility();

                if (view1 == null || view2 == null)
                    return;

                view2.AccessibilityTraversalAfter = view1.Id;
                view1.AccessibilityTraversalBefore = view2.Id;
            }
        }
    }
}
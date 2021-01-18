using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ResolutionGroupName("A11YTools")]
[assembly: ExportEffect(typeof(A11YTools.iOS.AccessibilityFixesEffect), nameof(A11YTools.iOS.AccessibilityFixesEffect))]
namespace A11YTools.iOS
{
    public class AccessibilityFixesEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            ApplyFixes();
            Device.BeginInvokeOnMainThread(ApplyFixes);
        }

        void ApplyFixes()
        {
            if(Element is ListView || 
                Element is ScrollView ||
                Element is CollectionView)
            {
                AutomationProperties.SetIsInAccessibleTree(Element, false);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
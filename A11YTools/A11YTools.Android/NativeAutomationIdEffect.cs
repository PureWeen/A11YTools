using A11YTools.Droid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportEffect(typeof(A11YTools.Droid.NativeAutomationIdEffect), nameof(A11YTools.Droid.NativeAutomationIdEffect))]
namespace A11YTools.Droid
{
    public class NativeAutomationIdEffect : Xamarin.Forms.Platform.Android.PlatformEffect
    {
        protected override void OnAttached()
        {
            var control =
                (base.Element as VisualElement).GetViewForAccessibility();

            if (Control == null)
                Element.PropertyChanged += OnSetTag;
            else
            {
                SetTag();
            }
        }
        
        void SetTag()
        {
            var effect = (A11YTools.NativeAutomationIdEffect)Element.Effects.FirstOrDefault(e => e is A11YTools.NativeAutomationIdEffect);

            if (effect != null)
            {
                var control = (base.Element as VisualElement).GetViewForAccessibility(Control);
                
                if(control != null)
                    control.Tag = AutomationIdEffect.GetAutomationId(Element);
            }
        }

        void OnSetTag(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Renderer")
            {
                Element.PropertyChanged -= OnSetTag;
                SetTag();
            }
            else if(e.PropertyName == AutomationIdEffect.AutomationIdProperty.PropertyName)
            {
                SetTag();
            }
        }

        protected override void OnDetached()
        {
            Element.PropertyChanged -= OnSetTag;
        }

        protected override void OnElementPropertyChanged(PropertyChangedEventArgs args)
        {
            base.OnElementPropertyChanged(args);

            if (args.PropertyName == "AutomationId")
            {
                SetTag();
            }
        }
    }
}
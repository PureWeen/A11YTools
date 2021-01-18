using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace A11YTools
{
    public class AccessibilityFixesEffect : RoutingEffect
    {
        public static readonly BindableProperty ApplyAccessibilityFixesProperty =
  BindableProperty.CreateAttached("ApplyAccessibilityFixes", typeof(bool), typeof(AccessibilityFixesEffect), false, propertyChanged:OnChanged);

        private static void OnChanged(BindableObject bindable, object oldValue, object newValue)
        {
            bool result = (bool)newValue;
            Element element = (Element)bindable;

            if(result)
            {
                element.Effects.Add(new AccessibilityFixesEffect());
            }
            else
            {
                foreach(var effect in element.Effects.OfType<AccessibilityFixesEffect>().ToList())
                {
                    element.Effects.Remove(effect);
                }
            }
        }

        public static bool GetApplyAccessibilityFixes(BindableObject view)
        {
            return (bool)view.GetValue(ApplyAccessibilityFixesProperty);
        }

        public static void SetApplyAccessibilityFixes(BindableObject view, bool value)
        {
            view.SetValue(ApplyAccessibilityFixesProperty, value);
        }


        public AccessibilityFixesEffect() : base($"A11YTools.{nameof(AccessibilityFixesEffect)}")
        {
        }
    }
}

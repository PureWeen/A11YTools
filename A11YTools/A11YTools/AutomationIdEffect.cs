using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace A11YTools
{
    public static class AutomationIdEffect
    {
        public static readonly BindableProperty AutomationIdProperty =
          BindableProperty.CreateAttached("AutomationId", typeof(string), typeof(AutomationIdEffect), null, propertyChanged: OnAutomationIdChanged);

        public static string GetAutomationId(BindableObject view)
        {
            return (string)view.GetValue(AutomationIdProperty);
        }

        public static void SetAutomationId(BindableObject view, string value)
        {
            view.SetValue(AutomationIdProperty, value);
        }


        private static void OnAutomationIdChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if(Device.RuntimePlatform != Device.Android)
            {
                if (bindable is Element element)
                    element.AutomationId = $"{newValue}";

                return;
            }

            var view = bindable as View;
            if (view == null)
            {
                return;
            }

            string automationId = (string)newValue;
            if (view.Effects.FirstOrDefault(x => x is NativeAutomationIdEffect) == null)
            {
                view.Effects.Add(new NativeAutomationIdEffect());
            }
        }
    }

    public class NativeAutomationIdEffect : RoutingEffect
    {
        public NativeAutomationIdEffect() : base($"A11YTools.{nameof(NativeAutomationIdEffect)}")
        {

        }
    }
}
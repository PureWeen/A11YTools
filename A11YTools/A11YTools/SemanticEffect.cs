using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace A11YTools
{
    public static class SemanticEffect
    {
        public static readonly BindableProperty IsHeadingProperty =
          BindableProperty.CreateAttached("IsHeading", typeof(bool), typeof(SemanticEffect), false, propertyChanged: OnIsHeadingChanged);

        public static bool GetIsHeading(BindableObject view)
        {
            return (bool)view.GetValue(IsHeadingProperty);
        }

        public static void SetIsHeading(BindableObject view, bool value)
        {
            view.SetValue(IsHeadingProperty, value);
        }


        private static void OnIsHeadingChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as View;
            if (view == null)
            {
                return;
            }

            if (view.Effects.FirstOrDefault(x => x is NativeSemanticEffect) == null)
            {
                view.Effects.Add(new NativeSemanticEffect());
            }
        }
    }

    public class NativeSemanticEffect : RoutingEffect
    {
        public NativeSemanticEffect() : base($"A11YTools.{nameof(NativeSemanticEffect)}")
        {

        }
    }
}
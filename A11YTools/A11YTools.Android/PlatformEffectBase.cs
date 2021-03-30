using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace A11YTools.Droid
{
    public class PlatformEffectBase<T> : Xamarin.Forms.Platform.Android.PlatformEffect
        where T : Effect
    {
        protected override void OnAttached()
        {
            var ve = Element as VisualElement;
            var control =
                ve.GetViewForAccessibility() ?? ve.GetViewForAccessibility(Control);

            if (control == null)
                Element.PropertyChanged += SetupControl;
            else
            {
                Update();
            }
        }


        protected virtual void Update(global::Android.Views.View view, T effect)
        {
        }

        protected void Update()
        {
            var effect = (T)Element.Effects.FirstOrDefault(e => e is T);
            var ve = Element as VisualElement;
            Update(ve.GetViewForAccessibility() ?? ve.GetViewForAccessibility(Control), effect);
        }

        void SetupControl(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Renderer")
            {
                Element.PropertyChanged -= SetupControl;
                Update();
            }
        }

        protected override void OnDetached()
        {
            Element.PropertyChanged -= SetupControl;
        }
    }
}
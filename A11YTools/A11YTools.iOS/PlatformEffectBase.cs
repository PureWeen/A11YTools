using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;

namespace A11YTools.iOS
{
    public class PlatformEffectBase<T> : Xamarin.Forms.Platform.iOS.PlatformEffect
        where T : Effect
    {
        protected override void OnAttached()
        {
            if (Control == null)
                Element.PropertyChanged += SetupControl;
            else
            {
                Update();
            }
        }


        protected virtual void Update(UIView view, T effect)
        {
        }

        protected void Update()
        {
            var effect = (T)Element.Effects.FirstOrDefault(e => e is T);
            Update(Control, effect);
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
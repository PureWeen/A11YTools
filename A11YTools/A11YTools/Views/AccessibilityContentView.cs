using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace A11YTools.Views
{
    public class AccessibilityContentView : ContentView
    {
        public static readonly BindableProperty ViewOrderProperty =
            BindableProperty.Create(nameof(ViewOrder), typeof(IEnumerable), typeof(AccessibilityContentView), new View[0]);

        public IEnumerable ViewOrder
        {
            get => (IEnumerable)GetValue(ViewOrderProperty);
            set => SetValue(ViewOrderProperty, value);
        }

        public AccessibilityContentView()
        {
            
        }
    }
}

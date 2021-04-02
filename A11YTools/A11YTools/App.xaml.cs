
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace A11YTools
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Xamarin.Forms.Device.SetFlags(new List<string> {
                "Shell_UWP_Experimental",
                "AccessibilityExperimental"});

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}

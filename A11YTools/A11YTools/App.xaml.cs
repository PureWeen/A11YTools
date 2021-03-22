
using A11YTools.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace A11YTools
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new RadioButtonA11y();
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

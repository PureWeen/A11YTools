using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace A11YTools.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetFocus : ContentPage
    {
        private readonly IA11yService _a11yService;
        public SetFocus()
        {
            InitializeComponent();
            _a11yService = DependencyService.Get<IA11yService>();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _a11yService.SetFocus(afcLabel);
        }
        private void Button2_Clicked(object sender, EventArgs e)
        {
            _a11yService.SetFocus(afcLabel2);
        }

        private void Button3_Clicked(object sender, EventArgs e)
        {
            _a11yService.SetFocus(theButton1);
        }
    }
}
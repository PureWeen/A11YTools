using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace A11YTools.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModifyControlType : ContentPage
    {
        private readonly IA11yService _a11yService;
        public ModifyControlType()
        {
            InitializeComponent();
            _a11yService = DependencyService.Get<IA11yService>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // the renderers need to have been set for this code to work
            Device.BeginInvokeOnMainThread(async () =>
            {
                await Task.Delay(1000);
                _a11yService.SetControlType(button, ControlType.Button);
                _a11yService.SetIsClickable(clickable, true);
            });
        }
    }
}
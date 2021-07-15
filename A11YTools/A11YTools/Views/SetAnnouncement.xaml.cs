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
    public partial class SetAnnouncement : ContentPage
    {
        private readonly IA11yService _a11yService;
        public SetAnnouncement()
        {
            InitializeComponent();
            _a11yService = DependencyService.Get<IA11yService>();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            _a11yService.SetAnnouncement("This is the announcement text");
        }
    }
}
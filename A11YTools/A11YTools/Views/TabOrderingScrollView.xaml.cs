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
    public partial class TabOrderingScrollView : ContentPage
    {
        public TabOrderingScrollView()
        {
            InitializeComponent();
            acv.ViewOrder = new List<View> { first, second, third, middle, bottom };
        }
    }
}
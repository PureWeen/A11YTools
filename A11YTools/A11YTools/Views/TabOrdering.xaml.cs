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
    public partial class TabOrdering : ContentPage
    {
        public TabOrdering()
        {
            InitializeComponent();

            acv.ViewOrder = new List<View> { first, second, third };

            third.ItemsSource = Enumerable.Range(0, 4000).ToList();
        }
    }
}
using A11YTools;
using A11YTools.UWP;
using A11YTools.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(SemanticView), typeof(SemanticViewRenderer))]
namespace A11YTools.UWP
{
    public class SemanticViewRenderer : ViewRenderer<SemanticView, FrameworkElement>
	{
        protected override void OnElementChanged(ElementChangedEventArgs<SemanticView> e)
        {
            base.OnElementChanged(e);
            UpdateViewOrder();
        }
        protected  override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if(e.PropertyName == SemanticView.ViewOrderProperty.PropertyName)
                UpdateViewOrder();

        }

        void UpdateViewOrder()
        {
            int i = 1;
            foreach (var element in Element.ViewOrder)
            {
                if (element is VisualElement ve)
                    ve.TabIndex = i++;
            }
        }
	}
}

using A11YTools.UWP;
using A11YTools.Views;
using System;
using System.Diagnostics;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Input;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: Dependency(typeof(UWPA11yService))]
namespace A11YTools.UWP
{
    public class UWPA11yService : IA11yService
    {
        public void SetAnnouncement(string text)
        {
            throw new NotImplementedException();
        }

        public void SetControlType(VisualElement element, ControlType controlType)
        {
            throw new NotImplementedException();
        }

        public async void SetFocus(VisualElement element)
        {
            var containerElement = Platform.GetRenderer(element).ContainerElement;

            FrameworkElement view = null;
            if (containerElement is AccessibleFocusBlockRenderer)
            {
                view = ((Xamarin.Forms.Platform.UWP.VisualElementRenderer<A11YTools.Views.AccessibleFocusBlock, Windows.UI.Xaml.Controls.Button>)containerElement).Control;
            }
            if (containerElement is ButtonRenderer)
            {
                view = ((VisualElementRenderer<Xamarin.Forms.Button, Xamarin.Forms.Platform.UWP.FormsButton>)containerElement).Control;
            }

            if (view == null)
                throw new NotImplementedException();

            var result = await FocusManager.TryFocusAsync(view, FocusState.Programmatic);

            Debug.WriteLine($"Set focus result {result.Succeeded}");
        }

        public void SetIsClickable(VisualElement element, bool isClickable, Action clickActionThatOnlyRunsOnAndroid)
        {
            throw new NotImplementedException();
        }
    }
}
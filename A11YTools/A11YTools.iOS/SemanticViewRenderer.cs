using A11YTools;
using A11YTools.Droid;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SemanticView), typeof(SemanticViewRenderer))]
namespace A11YTools.Droid
{
    public class SemanticViewRenderer : VisualElementRenderer<SemanticView>
    {
        public SemanticViewRenderer()
        {
        }
    }
}
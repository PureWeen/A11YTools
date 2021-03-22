using A11YTools;
using A11YTools.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(SemanticView), typeof(SemanticGroupViewRenderer))]
namespace A11YTools.Droid
{
    public class SemanticGroupViewRenderer : VisualElementRenderer<SemanticView>
    {
    }
}
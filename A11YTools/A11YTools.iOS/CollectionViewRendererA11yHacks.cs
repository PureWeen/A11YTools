using A11YTools.iOS;
using Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CollectionView), typeof(CollectionViewRendererA11yHacks))]
namespace A11YTools.iOS
{
    public class CollectionViewRendererA11yHacks : CollectionViewRenderer
    {

        void SetAllViewsToNotBeAccessibilityElementsUsingDunDunDunRecursion(UIView uIView)
        {
            if(uIView.IsAccessibilityElement)
                uIView.IsAccessibilityElement = false;

            if (uIView is UICollectionView)
            {
                return;
            }

            foreach(var view in uIView.Subviews)
            {
                SetAllViewsToNotBeAccessibilityElementsUsingDunDunDunRecursion(view);
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<GroupableItemsView> e)
        {
            base.OnElementChanged(e);
            SetAllViewsToNotBeAccessibilityElementsUsingDunDunDunRecursion(this);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs changedProperty)
        {
            base.OnElementPropertyChanged(sender, changedProperty);
            SetAllViewsToNotBeAccessibilityElementsUsingDunDunDunRecursion(this);
        }


        protected override void SetIsAccessibilityElement()
        {
            SetAllViewsToNotBeAccessibilityElementsUsingDunDunDunRecursion(this);
        }

    }
}
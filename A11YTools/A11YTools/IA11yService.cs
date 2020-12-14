using System;
using Xamarin.Forms;

namespace A11YTools
{
    public enum ControlType
    {
        Default,
        Button
    }

    public interface IA11yService
    {
        void SetFocus(VisualElement element);
        void SetControlType(VisualElement element, ControlType controlType);

        /// <summary>
        /// Sets the element to being a clickable element (like a button)
        /// </summary>
        /// <param name="element"></param>
        /// <param name="isClickable">Null resets element to the default</param>
        void SetIsClickable(VisualElement element, bool isClickable, Action clicked);
    }
}

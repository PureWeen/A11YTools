```C#
public interface IA11yService
    {
        /// <summary>
        /// Force accessibility focus to specified element
        /// </summary>
        /// <param name="element"></param>
        void SetFocus(VisualElement element);

        /// <summary>
        /// Tell an element to parade around as a different element
        /// </summary>
        /// <param name="element"></param>
        /// <param name="controlType"></param>
        void SetControlType(VisualElement element, ControlType controlType);

        /// <summary>
        /// Sets the element to being a clickable element (like a button).
        /// iOS: this is the same as setting control type to Button
        /// Android: Sets the "clickable" property on the native view to true
        /// </summary>
        /// <param name="element"></param>
        /// <param name="isClickable">Null resets element to the default</param>
        void SetIsClickable(VisualElement element, bool isClickable, Action clicked);
    }
 ```
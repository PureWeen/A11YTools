I am currently using this as a repository to test and have conversations around useful APIs that we can add to Xamarin.Forms to help users achieve accessibility goals.
This repository also works as a way to demonstrate various workarounds for your own app.

Please feel free to log issues if you have any questions or if you have additional APIs you would like to see. 

If you would like to make a contribution please feel free to create a PR.

The APIs in this project are all a work in progress that, once validated enough, will be added to Xamarin.Forms


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
        void SetIsClickable(VisualElement element, bool isClickable, Action clickActionThatOnlyRunsOnAndroid);
    }
 ```
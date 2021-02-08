I am currently using this as a repository to test and have conversations around useful APIs that we can add to Xamarin.Forms to help users achieve accessibility goals.
This repository also works as a way to demonstrate various workarounds for your own app.

Please feel free to log issues if you have any questions or if you have additional APIs you would like to see. 

If you would like to make a contribution please feel free to create a PR.

The APIs in this project are all a work in progress that, once validated enough, will be added to Xamarin.Forms

### IA11yService
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

 ### Accessibility Container (TabIndex replacement)

 TabIndex on Android and iOS messes with the ordering on an entire page. If you have a single element on a page set to
 `TabIndex 0` or `TabStop=true` it causes the entire native ordering to get replaced. The Accessibility Container represents
 our first steps towards a lighter touch approach. This will eventually get merged into XCT and a version of this will make its
 way into .NET MAUI

 Check out TabOrdering for a demo. If you are copying this code to your own code base you will need the custom renderers that go along with AccessibilityContentView

 ```XAML
 <local:AccessibilityContentView x:Name="acv">
    <StackLayout>
        <Label Text="First"
        VerticalOptions="CenterAndExpand" 
        HorizontalOptions="CenterAndExpand"
                x:Name="first">
        </Label>
        <CollectionView x:Name="third">
            <CollectionView.ItemTemplate>
                <DataTemplate>
                    <Label Text="{Binding .}"></Label>
                </DataTemplate>
            </CollectionView.ItemTemplate>
        </CollectionView>
        <Label Text="Second"
        VerticalOptions="CenterAndExpand" 
        HorizontalOptions="CenterAndExpand" 
                x:Name="second"/>
    </StackLayout>
</local:AccessibilityContentView>

 ```

 ```C#
      acv.ViewOrder = new List<View> { first, second, third };
 ```

 ### Known Issues With Samples

 - TabOrdering 
   - On Android the entire page gets selected after swiping off the Hamburger
   - On Android the focus goes directly to the first element of the CollectionView instead of the second
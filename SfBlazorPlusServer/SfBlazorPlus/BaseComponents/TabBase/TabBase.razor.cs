using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Navigations;
using System.Diagnostics;

namespace Code420.SfBlazorPlus.BaseComponents.TabBase
{
    // TODO: Understand why the various OverflowMode settings aren't working
    public partial class TabBase : ComponentBase
    {

        #region Component Parameters

        #region Base Parameters

        // ==================================================
        // Base Parameters
        // ==================================================

        /// <summary>
        /// Boolean value indicating if drag-and-drop operations are allowed to reorder tabs.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool AllowDragAndDrop { get; set; } = false;

        /// <summary>
        /// An integer value that specifies the duration (in milliseconds) applied to the animation of the Tabs component.
        /// Default value is 600 (milliseconds).
        /// </summary>
        [Parameter]
        public int AnimationDuration { get; set; } = 600;

        /// <summary>
        /// One of the <see cref="AnimationEffect"/> enum values that specify the animation type applied when animating the Tabs component.
        /// This effect is applied when moving to the next tab component.
        /// Default value is SlideRightIn.
        /// </summary>
        [Parameter]
        public AnimationEffect AnimationNextEffect { get; set; } = AnimationEffect.SlideRightIn;

        /// <summary>
        /// One of the <see cref="AnimationEffect"/> enum values that specify the animation type applied when animating the Tabs component.
        /// This effect is applied when moving to the previous tab component.
        /// Default value is SlideLeftIn.
        /// </summary>
        [Parameter]
        public AnimationEffect AnimationPreviousEffect { get; set; } = AnimationEffect.SlideLeftIn;

        /// <summary>
        /// A <see cref="RenderFragment"/> object containing the child content for the tab. 
        /// Default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; } = null;

        /// <summary>
        /// String value that specifies the area in which the draggable element movement will be occurring. 
        /// Outside that area will be restricted for the draggable element movement. 
        /// By default, the draggable element movement occurs with Tabitems. 
        /// Default value is null.
        /// </summary>
        [Parameter]
        public string DragArea { get; set; } = null;

        /// <summary>
        /// Boolean value specifying the persistance of the component's state between page reloads. 
        /// If enabled, the tab’s selected item will be persisted.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool EnablePersistence { get; set; } = false;

        /// <summary>
        /// A <see cref="HeaderPosition"/> object specifying the position of the Tab headers.
        /// Default value is Top.
        /// </summary>
        [Parameter]
        public HeaderPosition HeaderPlacement { get; set; } = HeaderPosition.Top;

        /// <summary>
        /// A read-only <see cref="List{T}"/> where T is a <see cref="TabItem"/> containing a list of items used to configure the Tabs component.
        /// </summary>
        public List<TabItem> TabItems
        {
            get => this.tab.Items;

            private set { }
        }

        /// <summary>
        /// A <see cref="ContentLoad"/> object specifying the loading modes for Tab contents.
        /// Default value is Dynamic (only the content of the current tab is loaded in the DOM).
        /// </summary>
        [Parameter]
        public ContentLoad LoadOn { get; set; } = ContentLoad.Dynamic;

        /// <summary>
        /// A <see cref="OverflowMode"/> object specifying the display mode applied when the Tabs exceeds the viewing area..
        /// Default value is Scrollable (All the elements will be displayed in a single line with horizontal scrolling enabled).
        /// </summary>
        [Parameter]
        public OverflowMode OverflowMode { get; set; } = OverflowMode.Scrollable;

        /// <summary>
        /// Boolean value specifying whether to re-order tab items to show active tab item in the Tab Header area 
        /// or popup when <see cref="OverflowMode"/> is Popup. 
        /// Default value is true (active tab item should be visible in header area).
        /// </summary>
        [Parameter]
        public bool ReorderActiveTab { get; set; } = true;

        /// <summary>
        /// Integer value specifying the scrolling distance (in pixels) applied when scrolling in Tab and <see cref="OverflowMode"/> is Scrollable.
        /// Default value is 200 (pixels).
        /// </summary>
        [Parameter]
        public int ScrollStep { get; set; } = 200;

        /// <summary>
        /// Integer value specifying  the index of the active Tab item.
        /// Default value is 0 (the first Tab).
        /// </summary>
        [Parameter]
        public int SelectedItem { get; set; } = 0;

        /// <summary>
        /// Boolean value specifying whether to show the close button in the Tab header or not.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool ShowCloseButton { get; set; } = false;

        #endregion


        #region Event Callback Parameters

        // ==================================================
        // Event Callback Parameters
        // ==================================================

        /// <summary>
        /// An <see cref="EventCallback{TValue}"/> where TValue is an <see cref="AddEventArgs"/>.
        /// The consumer's method is invoked when a tab is added to the tabs collection.
        /// </summary>
        [Parameter]
        public EventCallback<AddEventArgs> Added { get; set; }

        /// <summary>
        /// An <see cref="EventCallback{TValue}"/> where TValue is an <see cref="AddEventArgs"/>.
        /// The consumer's method is invoked before a tab is added to the tabs collection.
        /// </summary>
        [Parameter]
        public EventCallback<AddEventArgs> Adding { get; set; }

        /// <summary>
        /// An <see cref="EventCallback{TValue}"/> where TValue is an <see cref="object"/>.
        /// The consumer's method is invoked after the tab component is rendered.
        /// </summary>
        [Parameter]
        public EventCallback<object> Created { get; set; }

        /// <summary>
        /// An <see cref="EventCallback{TValue}"/> where TValue is an <see cref="object"/>.
        /// The consumer's method is invoked after the tab component is destroyed.
        /// </summary>
        [Parameter]
        public EventCallback<object> Destroyed { get; set; }

        /// <summary>
        /// An <see cref="EventCallback{TValue}"/> where TValue is an <see cref="DragEventArgs"/>.
        /// The consumer's method is invoked after the tab header element is dropped.
        /// </summary>
        [Parameter]
        public EventCallback<DragEventArgs> Dragged { get; set; }

        /// <summary>
        /// An <see cref="EventCallback{TValue}"/> where TValue is an <see cref="DragEventArgs"/>.
        /// The consumer's method is invoked before the tab header element is dragged.
        /// </summary>
        [Parameter]
        public EventCallback<DragEventArgs> OnDragStart { get; set; }

        /// <summary>
        /// An <see cref="EventCallback{TValue}"/> where TValue is an <see cref="RemoveEventArgs"/>.
        /// The consumer's method is invoked after removing a tab from the tab collection.
        /// </summary>
        [Parameter]
        public EventCallback<RemoveEventArgs> Removed { get; set; }

        /// <summary>
        /// An <see cref="EventCallback{TValue}"/> where TValue is an <see cref="RemoveEventArgs"/>.
        /// The consumer's method is invoked before removing a tab from the tab collection.
        /// </summary>
        [Parameter]
        public EventCallback<RemoveEventArgs> Removing { get; set; }

        /// <summary>
        /// An <see cref="EventCallback{TValue}"/> where TValue is an <see cref="SelectEventArgs"/>.
        /// The consumer's method is invoked after a tab item is selected.
        /// </summary>
        [Parameter]
        public EventCallback<SelectEventArgs> Selected { get; set; }

        /// <summary>
        /// An <see cref="EventCallback{TValue}"/> where TValue is an <see cref="SelectingEventArgs"/>.
        /// The consumer's method is invoked before a tab item is selected.
        /// </summary>
        [Parameter]
        public EventCallback<SelectingEventArgs> Selecting { get; set; }

        /// <summary>
        /// An <see cref="EventCallback{TValue}"/> where TValue is an <see cref="int"/>.
        /// The consumer's method is invoked when the selected tab changes.
        /// The parameter is an integer value which is the index of the selected tab.
        /// Handling this callback adds the responsibility of updating the Selected parameter.
        /// </summary>
        [Parameter]
        public EventCallback<int> SelectedItemChanged { get; set; }

        #endregion


        #region CSS Parameters

        // ==================================================
        // CSS Styling Parameters
        // ==================================================


        /// <summary>
        /// String value containing CSS class definition(s) that will be injected in the root HTML div element of the Tab container.
        /// Default value is string.Empty.
        /// </summary>
        [Parameter]
        public string CssClass { get; set; } = string.Empty;

        /// <summary>
        /// String value containing CSS ID that will be injected in the root HTML div element of the Tab container.
        /// Default value is string.Empty.
        /// </summary>
        [Parameter]
        public string CssId { get; set; } = string.Empty;

        /// <summary>
        /// Collection of additional HTML attributes such as styles, class, and more that are injected in root element. 
        /// If both property and equivalent HTML attribute are configured, the component considers the property value. 
        /// This is a <see cref="Dictionary{TKey, TValue}"/> where TKey is a <see cref="string"/> and TValue is an <see cref="object"/>.
        /// Default value is an empty dictionary.
        /// </summary>
        [Parameter]
        public Dictionary<string, object> HtmlAttributes { get; set; } = new();

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/height">height</see> value 
        /// of the Tab container. 
        /// The height CSS property specifies the height of an element.
        /// By default, Tab height is set based on the height of its parent.
        /// Default value is 100%
        /// </summary>
        [Parameter]
        public string Height { get; set; } = "100%";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/width">width</see> value 
        /// specifying the width of the Tab container. 
        /// The width CSS property sets an element's width.
        /// By default, Tab width sets based on the width of its parent.
        /// Default value is 100%
        /// </summary>
        [Parameter]
        public string Width { get; set; } = "100%";


        // ==================== Tab Header Styles ====================


        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-width">border-width</see> value 
        /// used for the border between the Tab Items and the Tab Content, and around the active Tab Item.
        /// The border-width shorthand CSS property sets the width of an element's border.
        /// Default value is 1px.
        /// </summary>
        [Parameter]
        public string TabHeaderBorderWidth { get; set; } = "1px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-color">border-color</see> value 
        /// used for the border between the Tab Items and the Tab Content, and around the active Tab Item.
        /// The border-color shorthand CSS property sets the color of an element's border.
        /// Default value is #DEE2E6.
        /// </summary>
        [Parameter]
        public string TabHeaderBorderColor { get; set; } = "#DEE2E6";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-style">border-style</see> value 
        /// used for the border between the Tab Items and the Tab Content, and around the active Tab Item.
        /// The border-style shorthand CSS property sets the line style for all four sides of an element's border.
        /// Default value is solid.
        /// </summary>
        [Parameter]
        public string TabHeaderBorderStyle { get; set; } = "solid";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius">border-radius</see> value 
        /// used for the border around the Tab Header.
        /// The border-radius CSS property rounds the corners of an element's outer border edge.
        /// Default value is 0px.
        /// </summary>
        [Parameter]
        public string TabHeaderBorderRadius { get; set; } = "0px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background-color</see> value 
        /// used for the Tab Header.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is #FFF.
        /// </summary>
        [Parameter]
        public string TabHeaderBackgroundColor { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-width">border-width</see> value 
        /// used for the border around the inactive, hovered Tab Item.
        /// The border-width shorthand CSS property sets the width of an element's border.
        /// Default value is 1px.
        /// </summary>
        [Parameter]
        public string TabHeaderInactiveHoveredBorderWidth { get; set; } = "1px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-color">border-color</see> value 
        /// used for the border around the inactive, hovered Tab Item.
        /// The border-color shorthand CSS property sets the color of an element's border.
        /// Default value is #E9ECEF.
        /// </summary>
        [Parameter]
        public string TabHeaderInactiveHoveredBorderColor { get; set; } = "#E9ECEF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-style">border-style</see> value 
        /// used for the border around the inactive, hovered Tab Item.
        /// The border-style shorthand CSS property sets the line style for all four sides of an element's border.
        /// Default value is solid.
        /// </summary>
        [Parameter]
        public string TabHeaderInactiveHoveredBorderStyle { get; set; } = "solid";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/length">length</see> data type
        /// used to add extra spacing around the Tab Header.
        /// The length CSS data type represents a distance value.
        /// Note that only a single pixel value should be set (e.g., 4px). The component will apply the margin as appropriate based on the
        /// <see cref="HeaderPlacement"/> parameter.
        /// Default value is 4px.
        /// </summary>
        [Parameter]
        public string TabHeaderExtraMargin { get; set; } = "4px";


        // ==================== Tab Item Styles ====================


        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/length">length</see> data type
        /// used for the border around the active Tab Item.
        /// The length CSS data type represents a distance value.
        /// Note that only a single pixel value (e.g., 4px) should be set. The proper application of this value is handled by the component
        /// Default value is 4px.
        /// </summary>
        [Parameter]
        public string TabItemBorderRadius { get; set; } = "4px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-color">border-color</see> value 
        /// used for the bottom border for the active Tab Item.
        /// The border-color shorthand CSS property sets the color of an element's border.
        /// Default value is string.Empty indicating the <see cref="TabHeaderBackgroundColor"/> parameter value will be used.
        /// </summary>
        [Parameter]
        public string TabItemActiveBottomBorderColor { get; set; } = string.Empty;

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/margin-right">margin-right</see> value 
        /// used for spacing between the Tab Items.
        /// The margin-right CSS property sets the margin area on the right side of an element.
        /// The margin value will be applied as needed based on the <see cref="HeaderPlacement"/> parameter.
        /// Default value is 2px.
        /// </summary>
        [Parameter]
        public string TabItemMargin { get; set; } = "2px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/height">height</see> value 
        /// of the Tab Items. 
        /// The height CSS property specifies the height of an element.
        /// Default value is 32px
        /// </summary>
        [Parameter]
        public string TabItemHeight { get; set; } = "32px";


        // ==================== Tab Text Styles ====================


        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value 
        /// used for the active Tab Item font size.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 14px.
        /// </summary>
        [Parameter]
        public string TabTextActiveFontSize { get; set; } = "14px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value 
        /// used for the active Tab Item font color.
        /// The color CSS property sets the foreground color value of an element's text and text decorations.
        /// Default value is #777.
        /// </summary>
        [Parameter]
        public string TabTextActiveFontColor { get; set; } = "#777";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight">font-weight</see> value 
        /// used for the active Tab Item font color.
        /// The font-weight CSS property sets the weight (or boldness) of the font.
        /// Default value is 400.
        /// </summary>
        [Parameter]
        public string TabTextActiveFontWeight { get; set; } = "400";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value 
        /// used for the inactive Tab Item font size.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 14px.
        /// </summary>
        [Parameter]
        public string TabTextInactiveFontSize { get; set; } = "14px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value 
        /// used for the inactive Tab Item font color.
        /// The color CSS property sets the foreground color value of an element's text and text decorations.
        /// Default value is #007BFF.
        /// </summary>
        [Parameter]
        public string TabTextInactiveFontColor { get; set; } = "#007BFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight">font-weight</see> value 
        /// used for the inactive Tab Item font color.
        /// The font-weight CSS property sets the weight (or boldness) of the font.
        /// Default value is 400.
        /// </summary>
        [Parameter]
        public string TabTextInactiveFontWeight { get; set; } = "400";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value 
        /// used for the active, hovered Tab Item font size.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 14px.
        /// </summary>
        [Parameter]
        public string TabTextActiveHoveredFontSize { get; set; } = "14px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value 
        /// used for the active, hovered Tab Item font color.
        /// The color CSS property sets the foreground color value of an element's text and text decorations.
        /// Default value is #495057.
        /// </summary>
        [Parameter]
        public string TabTextActiveHoveredFontColor { get; set; } = "#495057";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight">font-weight</see> value 
        /// used for the active, hovered Tab Item font color.
        /// The font-weight CSS property sets the weight (or boldness) of the font.
        /// Default value is 400.
        /// </summary>
        [Parameter]
        public string TabTextActiveHoveredFontWeight { get; set; } = "400";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value 
        /// used for the inactive, hovered Tab Item font size.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 14px.
        /// </summary>
        [Parameter]
        public string TabTextInactiveHoveredFontSize { get; set; } = "14px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value 
        /// used for the inactive, hovered Tab Item font color.
        /// The color CSS property sets the foreground color value of an element's text and text decorations.
        /// Default value is #007BFF.
        /// </summary>
        [Parameter]
        public string TabTextInactiveHoveredFontColor { get; set; } = "#007BFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight">font-weight</see> value 
        /// used for the inactive, hovered Tab Item font color.
        /// The font-weight CSS property sets the weight (or boldness) of the font.
        /// Default value is 400.
        /// </summary>
        [Parameter]
        public string TabTextInactiveHoveredFontWeight { get; set; } = "400";


        // ==================== Scroll Button Styles ====================


        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value 
        /// used for the Scroll Button's icon when not hovered.
        /// The color CSS property sets the foreground color value of an element's text and text decorations.
        /// Default value is #212529.
        /// </summary>
        [Parameter]
        public string ScrollButtonNormalFontColor { get; set; } = "#212529";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value 
        /// used for the Scroll Button's icon when hovered.
        /// The color CSS property sets the foreground color value of an element's text and text decorations.
        /// Default value is #FFF.
        /// </summary>
        [Parameter]
        public string ScrollButtonHoveredFontColor { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background">background</see> value 
        /// used for the Scroll Button when not hovered.
        /// The background shorthand CSS property sets all background style properties at once, such as color, image, origin and size, or repeat method.
        /// Default value is none.
        /// </summary>
        [Parameter]
        public string ScrollButtonNormalBackground { get; set; } = "none";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background">background</see> value 
        /// used for the Scroll Button when hovered.
        /// The background shorthand CSS property sets all background style properties at once, such as color, image, origin and size, or repeat method.
        /// Default value is #5A6268.
        /// </summary>
        [Parameter]
        public string ScrollButtonHoveredBackground { get; set; } = "#5A6268";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius">border-radius</see> value 
        /// used for the Scroll Buttons.
        /// The border-radius CSS property rounds the corners of an element's outer border edge.
        /// Default value is 0px.
        /// </summary>
        [Parameter]
        public string ScrollButtonBorderRadius { get; set; } = "0px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value 
        /// used for the Scroll Buttons' icon font size.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 10px.
        /// </summary>
        [Parameter]
        public string ScrollButtonFontSize { get; set; } = "10px";

        #endregion

        #endregion



        #region Callback Events Invoked from Underlying Components

        // ==================================================
        // Methods used as Callback Events from the underlying component(s)
        // ==================================================

        private async Task AddedHandler(AddEventArgs args)
        {
            Debug.WriteLine("AddedHandler method invoked.");
            if (Added.HasDelegate) await Added.InvokeAsync(args);
        }

        private async Task AddingHandler(AddEventArgs args)
        {
            Debug.WriteLine("AddingHandler method invoked.");
            if (Adding.HasDelegate) await Adding.InvokeAsync(args);
        }

        private async Task CreatedHandler(object args)
        {
            Debug.WriteLine("CreatedHandler method invoked.");
            Debug.WriteLine($"Next--Duration={this.tab.Animation.Next.Duration}, Effect={this.tab.Animation.Next.Effect}, Easing={this.tab.Animation.Next.Easing}");
            Debug.WriteLine($"Previous--Duration={this.tab.Animation.Previous.Duration}, Effect={this.tab.Animation.Previous.Effect}, Easing={this.tab.Animation.Previous.Easing}");
            if (Created.HasDelegate) await Created.InvokeAsync(args);
        }

        private async Task DestroyedHandler(object args)
        {
            Debug.WriteLine("DestroyedHandler method invoked.");
            if (Destroyed.HasDelegate) await Destroyed.InvokeAsync(args);
        }

        private async Task DraggedHandler(DragEventArgs args)
        {
            Debug.WriteLine("DraggedHandler method invoked.");
            if (Dragged.HasDelegate) await Dragged.InvokeAsync(args);
        }

        private async Task OnDragStartHandler(DragEventArgs args)
        {
            Debug.WriteLine("OnDragStartHandler method invoked.");
            if (OnDragStart.HasDelegate) await OnDragStart.InvokeAsync(args);
        }

        private async Task OnRemovedHandler(RemoveEventArgs args)
        {
            Debug.WriteLine("OnRemovedHandler method invoked.");
            if (Removed.HasDelegate) await Removed.InvokeAsync(args);
        }

        private async Task OnRemovingHandler(RemoveEventArgs args)
        {
            Debug.WriteLine("OnRemovingHandler method invoked.");
            if (Removing.HasDelegate) await Removing.InvokeAsync(args);
        }

        private async Task OnSelectedHandler(SelectEventArgs args)
        {
            Debug.WriteLine("OnSelectedHandler method invoked.");
            if (Selected.HasDelegate) await Selected.InvokeAsync(args);
        }

        private async Task OnSelectingHandler(SelectingEventArgs args)
        {
            Debug.WriteLine("OnSelectingHandler method invoked.");
            if (Selecting.HasDelegate) await Selecting.InvokeAsync(args);
        }

        private async Task OnSelectedItemChangedHandler(int index)
        {
            Debug.WriteLine("OnSelectedItemChangedHandler method invoked.");
            if (SelectedItemChanged.HasDelegate) await SelectedItemChanged.InvokeAsync(index);
            else SelectedItem = index;
        }

        #endregion



        #region Instance Variables

        // ==================================================
        // Instance variables
        // ==================================================

        private SfTab tab;                                      // Reference to SfTab object
        private TabAnimationSettings tabAnimationSettings;      // TabAnimationSettins contructed below and passed to SfTab
        private string masterCssSelector = string.Empty;        // CSS selector for specificity
        private string tabHeaderBorderWidth;                    // Constructed tab header border widths for horizontal and vertical headers
        private string activeTabBorder;                         // Constructed border styling for the active tab
        private string activeTabBottomBorder;                   // Constructed active tab item bottom border.
        private string activeTabBorderRadius;                   // Constructed border radii for the active tab
        private string inactiveTabBorderHoveredBorders;         // Constructed inactive tab hovered left, to and right borders
        private string tabItemMargin;                           // Constructed Tab Item margins

        #endregion



        #region Injected Dependencies

        // Injected Dependencies



        // Dependency Injection


        #endregion



        #region Constructors


        // ==================================================
        // Constructors
        // ==================================================

        // This method is executed whenever the parent renders.
        // Parameters that were passed into the component are contained in a ParameterView.
        //  This is a good point at which to make asynchronous calls to a server (for example)
        //  based on the state passed into the component.
        // The component’s [Parameter] properties are assigned their values when you call
        //  base.SetParametersAsync(parameters) inside your override.
        // It is also the correct place to assign default parameter values.
        public override async Task SetParametersAsync(ParameterView parameters)
        {
            await base.SetParametersAsync(parameters);
        }

        // Once the state from the ParameterCollection has been assigned to the component’s
        //  [Parameter] properties, these methods are executed. This is useful in the same way
        //  as SetParametersAsync, except it is possible to use the component’s state.
        // This method is only executed once when the component is first created.If the parent
        //  changes the component’s parameters at a later time, this method is skipped.
        // When the component is a @page, and our Blazor app navigates to a new URL that renders
        //  the same page, Blazor will reuse the current object instance for that page.Because the
        //  object is the same instance, Blazor does not call IDisposable.Dispose on the object,
        //  nor does it execute its OnInitialized method again.
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            // Build the master selectors
            masterCssSelector = (CssClass == string.Empty) ? ".e-tab" : $".{ CssClass }.e-tab";


            // Construct the Animation parameter
            // Handle case when Effect = None
            tabAnimationSettings = new() { Next = new(), Previous = new() };
            tabAnimationSettings.Next.Duration = tabAnimationSettings.Previous.Duration = AnimationDuration;
            tabAnimationSettings.Next.Easing = tabAnimationSettings.Previous.Easing = "ease";
            tabAnimationSettings.Next.Effect = AnimationNextEffect;
            tabAnimationSettings.Previous.Effect = AnimationPreviousEffect;

            // Construct the tab header border widths for horizontal and vertical headers
            tabHeaderBorderWidth = HeaderPlacement switch
            {
                HeaderPosition.Top => $"0px 0px { TabHeaderBorderWidth }",
                HeaderPosition.Bottom => $"{ TabHeaderBorderWidth } 0px 0px 0px",
                HeaderPosition.Left => $"0px { TabHeaderBorderWidth } 0px 0px",
                HeaderPosition.Right => $"0px 0px 0px { TabHeaderBorderWidth }",
                _ => "",
            };


            // Construct the border styling for the active tab
            activeTabBorder = $"{ TabHeaderBorderWidth } { TabHeaderBorderStyle } { TabHeaderBorderColor }";


            // Construct the active tab item bottom border.
            // If TabItemActiveBottomBorderColor has been set, use that, otherwise use TabHeaderBackgroundColor
            activeTabBottomBorder = (TabItemActiveBottomBorderColor == string.Empty) ?
                $"{ TabHeaderBorderWidth } { TabHeaderBorderStyle } { TabHeaderBackgroundColor }" :
                $"{ TabHeaderBorderWidth } { TabHeaderBorderStyle } { TabItemActiveBottomBorderColor }";


            // Construct the inactive tab hovered left, to and right borders
            inactiveTabBorderHoveredBorders = $"{ TabHeaderInactiveHoveredBorderWidth } { TabHeaderInactiveHoveredBorderStyle } { TabHeaderInactiveHoveredBorderColor }";


            // Construct the border radii for the active tab
            activeTabBorderRadius = HeaderPlacement switch
            {
                HeaderPosition.Top => $"{ TabItemBorderRadius } { TabItemBorderRadius } 0px 0px",
                HeaderPosition.Bottom => $"0px 0px { TabItemBorderRadius } { TabItemBorderRadius }",
                HeaderPosition.Left => $"{ TabItemBorderRadius } 0px 0px { TabItemBorderRadius }",
                HeaderPosition.Right => $"0px { TabItemBorderRadius } { TabItemBorderRadius } 0px",
                _ => "",
            };


            // Construct the Tab Item margins
            tabItemMargin = HeaderPlacement switch
            {
                HeaderPosition.Top or HeaderPosition.Bottom => $"0px { TabItemMargin } 0px 0px",
                HeaderPosition.Left or HeaderPosition.Right => $"0px 0px { TabItemMargin } 0px",
                _ => "",
            };
        }

        // This method will be executed immediately after OnInitializedAsync if this is a new
        //  instance of a component. If it is an existing component that is being re-rendered because
        //  its parent is re-rendering then the OnInitialized* methods will not be executed, and this
        //  method will be executed immediately after SetParametersAsync instead
        protected override async Task OnParametersSetAsync()
        {
            await base.OnParametersSetAsync();
        }

        // This is the first place that the State should be changed
        //
        // This method is executed every time Blazor has re-generated the component’s RenderTree.
        //  This can be as a result of the component’s parent re-rendering, the user interacting with the component
        //  (e.g. a mouse-click), or if the component executes its StateHasChanged method to invoke a re-render.
        // This method has a single parameter named firstRender. This parameter is true only the first time the
        //  method is called on the current component, from there onwards it will always be false. In cases where
        //  additional component hook-up is required (for example, via JavaScript) it is useful to know this is the
        //  first render.
        // It is not until after the OnAfterRender method have executed that it is safe to use any references to
        //  components set via the @ref directive. And it is not until after the OnAfterRender method have been
        //  executed with firstRender set to true that it is safe to use any references to HTML elements set via
        //  the @ref directive
        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);
        }

        #endregion



        #region Public Methods Providing Access to the Underlying Components to the Consumer

        // ==================================================
        // Public Methods providing access to the underlying component to the consumer
        // ==================================================

        /// <summary>
        /// Adds a list of Tab items to the Tab.
        /// </summary>
        /// <param name="items">List of <see cref="TabItem"/> to add to the Tab.</param>
        /// <param name="index">Index value that determines where the items to be added</param>
        public async Task AddTabAsync(List<TabItem> items, int index) => await this.tab.AddTab(items, index);

        /// <summary>
        /// Disables/enables the Tab component.
        /// </summary>
        /// <param name="disable">Boolean value specifying is the Tab component is disabled (true) or enabled.</param>
        public async Task DisableAsync(bool disable) => await this.tab.DisableAsync(disable);

        /// <summary>
        /// Enables or disables a specific tab item.
        /// </summary>
        /// <param name="index">Integer value specifying the index of the tab.</param>
        /// <param name="isEnable">Boolean value specifying is the tab is enabled (true) or disabled.</param>
        /// <returns></returns>
        public async Task EnableTabAsync(int index, bool isEnable = true) => await this.tab.EnableTabAsync(index, isEnable);

        /// <summary>
        /// Returns the content element of the tab with the specified index.
        /// </summary>
        /// <param name="index">Integer value specifying the index of the tab whose content is to returned.</param>
        /// <returns>A <see cref="DOM"/> object containg the contents of the tab.</returns>
        public async Task<DOM> GetTabContentAsync(int index)
        {
            return await this.tab.GetTabContent(index);
        }

        /// <summary>
        /// Returns the header element of the tab with the specified index.
        /// </summary>
        /// <param name="index">Integer value specifying the index of the tab whose content is to returned.</param>
        /// <returns>A <see cref="DOM"/> object containg the header element of the tab.</returns>
        public async Task<DOM> GetTabItemAsync(int index)
        {
            return await this.tab.GetTabItem(index);
        }

        /// <summary>
        /// Show/hides a tab based on the specified index.
        /// </summary>
        /// <param name="index">Integer value spefifying the index of the tab to show/hide.</param>
        /// <param name="show">Boolean value specifying if the tab is shown (true) or hidden.</param>
        /// <returns></returns>
        public async Task HideTabAsync(int index, bool show) => await this.tab.HideTabAsync(index, show);

        /// <summary>
        /// Refresh the entire Tab component.
        /// </summary>
        public async Task RefreshAsync() => await this.tab.RefreshAsync();

        /// <summary>
        /// Removes an entire tab from the collection of tabs.
        /// </summary>
        /// <param name="index">Integer value spefifying the index of the tab to remove.</param>
        public async Task RemoveTabAsync(int index) => await this.tab.RemoveTab(index);

        /// <summary>
        /// Activates a tab based on the specified index.
        /// </summary>
        /// <param name="index">Integer value spefifying the index of the tab to activate.</param>
        public async Task SelectAsync(int index) => await this.tab.SelectAsync(index);

        #endregion



        #region Private Methods for Internal Use Only
        #endregion

    }
}

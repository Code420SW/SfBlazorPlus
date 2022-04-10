using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Navigations;
using System.Diagnostics;

namespace Code420.SfBlazorPlus.BaseComponents.MenuBase
{
    //
    // Encapsulates the SfMenu component with the goal of exposing various CSS styling options,
    // and to overload menu events. 
    //
    // The ChildContent parameter captures the menu item definition either through ise of the
    // MenuItems> and <MenuItem> component, through the <MenuFieldSettings> component, or through
    // the <MenuTemplates> component. An example for <MenuTemplates> can be found at:
    // Menu Templates: https://blazor.syncfusion.com/demos/menu-bar/templates?theme=bootstrap4
    //
    // Note that only one of these menu definition schemes should be used. I don't knoww that they
    // be intermixed.
    //
    // The <MenuEvents> component should not be defined. Use this components event parameters instead.
    // These will provide default handlers and will call their overrides as needed.
    //

    public partial class MenuBase<TValue> : ComponentBase
    {

        #region Component Parameters

        #region Base Parameters

        // ==================================================
        // Base Parameters
        // ==================================================

        /// <summary>
        /// <typeparamref name="TValue"/> value indicating if the switch is in the
        /// on or off state.
        /// </summary>
        [Parameter]
        public bool EnableScrolling { get; set; }

        /// <summary>
        /// Contains the <see cref="RenderFragment" /> composing the Menu contents.
        /// The default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; } = null;

        /// <summary>
        /// Boolean value specifying if hamburger mode is enabled in the Menu.
        /// The default value is false.
        /// </summary>
        [Parameter]
        public bool HamburgerMode { get; set; } = false;

        /// <summary>
        /// A <see cref="List{T}"/> whete T is <see cref="TValue"/> containing the menu items with their properties to be rendered in the Menu.
        /// The default value is null.
        /// </summary>
        [Parameter]
        public List<TValue> Items { get; set; } = null;

        /// <summary>
        /// One of the <see cref="Orientatiion"/> enums specifying the orientation of the Menu.
        /// The default value is Horizontal.
        /// </summary>
        [Parameter]
        public Orientation Orientation { get; set; } = Orientation.Horizontal;

        /// <summary>
        /// Boolean value specifying whether or not to show the submenu item on click.
        /// When set to true, the submenu will open onlu on mouse cllick.
        /// The default value is false.
        /// </summary>
        [Parameter]
        public bool ShowItemOnClick { get; set; } = true;

        /// <summary>
        /// String value specifying the CSS class whose HTML element the Menu will open/close when <see cref="HamburgerMode"/> is enabled.
        /// This must be a full CSS class specification (e.g., .sidebar__menu).
        /// Default value is string.Empty.
        /// </summary>
        [Parameter]
        public string Target { get; set; } = string.Empty;

        /// <summary>
        /// String value specifying the title text displayed when <see cref="HamburgerMode"/> is enabled.
        /// Default value is string.Empty.
        /// </summary>
        [Parameter]
        public string Title { get; set; } = string.Empty;

        #endregion


        #region Event Callback Parameters

        // ==================================================
        // Event Callback Parameters
        // ==================================================

        /// <summary>
        /// An <see cref="EventCallback"/> containing the consumer's method invoked when closing the menu.
        /// </summary>
        [Parameter]
        public EventCallback<OpenCloseMenuEventArgs<TValue>> Closed { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containing the consumer's method invoked once the Menu rendering is completed.
        /// </summary>
        [Parameter]
        public EventCallback<object> Created { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containing the consumer's method invoked while selecting menu item.
        /// </summary>
        [Parameter]
        public EventCallback<MenuEventArgs<TValue>> ItemSelected { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containing the consumer's method invoked before closing the menu.
        /// </summary>
        [Parameter]
        public EventCallback<BeforeOpenCloseMenuEventArgs<TValue>> OnClose { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containing the consumer's method invoked while rendering each menu item.
        /// </summary>
        [Parameter]
        public EventCallback<MenuEventArgs<TValue>> OnItemRender { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containing the consumer's method invoked before opening the menu item.
        /// </summary>
        [Parameter]
        public EventCallback<BeforeOpenCloseMenuEventArgs<TValue>> OnOpen { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containing the consumer's method invoked while opening the menu item.
        /// </summary>
        [Parameter]
        public EventCallback<OpenCloseMenuEventArgs<TValue>> Opened { get; set; }


        #endregion


        #region CSS Parameters

        // ==================================================
        // CSS Styling Parameters
        // ==================================================


        /// <summary>
        /// String value containing CSS class definition(s) that will be injected in the root HTML div element of the Menu container and the Popup container.
        /// Default value is string.Empty.
        /// </summary>
        [Parameter]
        public string CssClass { get; set; } = string.Empty;

        /// <summary>
        /// String value containing CSS ID that will be injected in the root HTML div element of the Sidebar container.
        /// Default value is string.Empty.
        /// </summary>
        //[Parameter]
        //public string CssId { get; set; } = string.Empty;

        /// <summary>
        /// Collection of additional HTML attributes such as styles, class, and more that are injected in root element. 
        /// If both property and equivalent HTML attribute are configured, the component considers the property value. 
        /// This is a <see cref="Dictionary{TKey, TValue}"/> where TKey is a <see cref="string"/> and TValue is an <see cref="object"/>.
        /// Default value is an empty dictionary.
        /// </summary>
        //[Parameter]
        //public Dictionary<string, object> HtmlAttributes { get; set; }


        // ==================== Menu Container Styles ====================


        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border">border</see> value 
        /// used for the border around the Menu container.
        /// The border shorthand CSS property sets an element's border. It sets the values of border-width, border-style, and border-color.
        /// Default value is none.
        /// </summary>
        [Parameter]
        public string MenuBorder { get; set; } = "none";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius">border-radius</see> value 
        /// used for the border around the Menu container.
        /// The border-radius CSS property rounds the corners of an element's outer border edge.
        /// Default value is 4px.
        /// </summary>
        [Parameter]
        public string MenuBorderRadius { get; set; } = "4px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value 
        /// applied to the text element of each Menu Item.
        /// The color CSS property sets the foreground color value of an element's text and text decorations, and sets the currentcolor value.
        /// Default value is #007BFF.
        /// </summary>
        [Parameter]
        public string MenuFontColor { get; set; } = "#007BFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value 
        /// applied to the text element of each Menu Item.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 14px.
        /// </summary>
        [Parameter]
        public string MenuFontSize { get; set; } = "14px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight">font-weight</see> value 
        /// applied to the text element of each Menu Item.
        /// The font-weight CSS property sets the weight (or boldness) of the font.
        /// Default value is normal.
        /// </summary>
        [Parameter]
        public string MenuFontWeight { get; set; } = "normal";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/text-align">text-align</see> value 
        /// applied to the text element of each Menu Item.
        /// The text-align CSS property sets the horizontal alignment of the content inside a block element or table-cell box.
        /// Default value is left.
        /// </summary>
        [Parameter]
        public string MenuTextAlign { get; set; } = "left";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background-color</see> value 
        /// applied to the Menu container.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is #FFF.
        /// </summary>
        [Parameter]
        public string MenuBackgroundColor { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/min-width">min-width</see> value 
        /// applied to the Menu container.
        /// The min-width CSS property sets the minimum width of an element.
        /// Default value is 120px.
        /// </summary>
        [Parameter]
        public string MenuMinimumWidth { get; set; } = "120px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/margin">margin</see> value 
        /// applied to the Menu container.
        /// The text-align CSS property sets the horizontal alignment of the content inside a block element or table-cell box.
        /// Default value is 0px.
        /// </summary>
        [Parameter]
        public string MenuMargin { get; set; } = "0px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value 
        /// applied to the Menu container.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Default value is 0px.
        /// </summary>
        [Parameter]
        public string MenuPadding { get; set; } = "0px";


        // ==================== Menu Item Styles ====================


        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/height">height</see> value 
        /// applied to the Menu container.
        /// The height CSS property specifies the height of an element. 
        /// Default value is 30px.
        /// </summary>
        [Parameter]
        public string MenuItemHeight { get; set; } = "30px";
        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/line-height">line-height</see> value 
        /// applied to the Menu container.
        /// The line-height CSS property sets the height of a line box.
        /// Default value is 30px.
        /// </summary>
        [Parameter]
        public string MenuItemLineHeight { get; set; } = "30px";
        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value 
        /// applied to each Menu Item.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Default value is 0px 12px.
        /// </summary>
        [Parameter]
        public string MenuItemPadding { get; set; } = "0px 12px";


        // ==================== Menu Item Icon Styles ====================


        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value 
        /// applied to the icon element of each Menu Item.
        /// The color CSS property sets the foreground color value of an element's text and text decorations, and sets the currentcolor value.
        /// Default value is #007BFF.
        /// </summary>
        [Parameter]
        public string MenuIconFontColor { get; set; } = "#007BFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value 
        /// applied to the icon element of each Menu Item.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 14px.
        /// </summary>
        [Parameter]
        public string MenuIconFontSize { get; set; } = "14px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/height">height</see> value 
        /// applied to the icon element of each Menu Item.
        /// The height CSS property specifies the height of an element. 
        /// Default value is auto.
        /// </summary>
        [Parameter]
        public string MenuIconHeight { get; set; } = "auto";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/line-height">line-height</see> value 
        /// applied to the icon element of each Menu Item.
        /// The line-height CSS property sets the height of a line box.
        /// Default value is 30px.
        /// </summary>
        [Parameter]
        public string MenuIconLineHeight { get; set; } = "30px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/width">width</see> value 
        /// applied to the icon element of each Menu Item.
        /// The width CSS property sets an element's width.
        /// Default value is 1em.
        /// </summary>
        [Parameter]
        public string MenuIconWidth { get; set; } = "1em";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/text-align">Text-align</see> value 
        /// applied to the icon element of each Menu Item.
        /// The text-align CSS property sets the horizontal alignment of the content inside a block element or table-cell box.
        /// Default value is center.
        /// </summary>
        [Parameter]
        public string MenuIconTextAlign { get; set; } = "center";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/margin-right">margin-right</see> value 
        /// applied to the icon element of each Menu Item.
        /// The margin-right CSS property sets the margin area on the right side of an element.
        /// Default value is 8px.
        /// </summary>
        [Parameter]
        public string MenuIconRightMargin { get; set; } = "8px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/vertical-align">vertical-align</see> value 
        /// applied to the icon element of each Menu Item.
        /// The vertical-align CSS property sets vertical alignment of an inline, inline-block or table-cell box.
        /// Default value is middle.
        /// </summary>
        [Parameter]
        public string MenuIconVerticalAlign { get; set; } = "middle";


        // ==================== Menu Item Caret Styles ====================


        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value 
        /// applied to the caret element of each Menu Item.
        /// The color CSS property sets the foreground color value of an element's text and text decorations, and sets the currentcolor value.
        /// Default value is #007BFF.
        /// </summary>
        [Parameter]
        public string MenuCaretFontColor { get; set; } = "#007BFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value 
        /// applied to the caret element of each Menu Item.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 9px.
        /// </summary>
        [Parameter]
        public string MenuCaretFontSize { get; set; } = "9px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/height">height</see> value 
        /// applied to the caret element of each Menu Item.
        /// The height CSS property specifies the height of an element. 
        /// Default value is auto.
        /// </summary>
        [Parameter]
        public string MenuCaretHeight { get; set; } = "auto";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/line-height">line-height</see> value 
        /// applied to the caret element of each Menu Item.
        /// The line-height CSS property sets the height of a line box.
        /// Default value is 30px.
        /// </summary>
        [Parameter]
        public string MenuCaretLineHeight { get; set; } = "30px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/width">width</see> value 
        /// applied to the caret element of each Menu Item.
        /// The width CSS property sets an element's width.
        /// Default value is auto.
        /// </summary>
        [Parameter]
        public string MenuCaretWidth { get; set; } = "auto";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/right">right</see> value 
        /// applied to the caret element of each Menu Item.
        /// The right CSS property participates in specifying the horizontal position of a positioned element.
        /// Default value is 12px.
        /// </summary>
        [Parameter]
        public string MenuCaretRight { get; set; } = "12px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/top">top</see> value 
        /// applied to the caret element of each Menu Item.
        /// The top CSS property participates in specifying the vertical position of a positioned element.
        /// Default value is 0px.
        /// </summary>
        [Parameter]
        public string MenuCaretTop { get; set; } = "0px";


        // ==================== Selected Menu Item Styles ====================


        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value 
        /// applied to the text element of the selected Menu Item.
        /// The color CSS property sets the foreground color value of an element's text and text decorations, and sets the currentcolor value.
        /// Default value is #0056B3.
        /// </summary>
        [Parameter]
        public string MenuItemSelectedFontColor { get; set; } = "#0056B3";


        // ==================== Menu Popup Container Styles ====================


        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border">border</see> value 
        /// used for the border around the Menu popup container.
        /// The border shorthand CSS property sets an element's border. It sets the values of border-width, border-style, and border-color.
        /// Default value is 1px solid rgba(0,0,0,0.15).
        /// </summary>
        [Parameter]
        public string MenuPopupBorder { get; set; } = "1px solid rgba(0,0,0,0.15)";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius">border-radius</see> value 
        /// used for the border around the Menu popup container.
        /// The border-radius CSS property rounds the corners of an element's outer border edge.
        /// Default value is 4px.
        /// </summary>
        [Parameter]
        public string MenuPopupBorderRadius { get; set; } = "4px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value 
        /// applied to the text element of each Menu Item in the popuo.
        /// The color CSS property sets the foreground color value of an element's text and text decorations, and sets the currentcolor value.
        /// Default value is #007BFF.
        /// </summary>
        [Parameter]
        public string MenuPopupFontColor { get; set; } = "#007BFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value 
        /// applied to the text element of each Menu Item in the popup.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 14px.
        /// </summary>
        [Parameter]
        public string MenuPopupFontSize { get; set; } = "14px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight">font-weight</see> value 
        /// applied to the text element of each Menu Item in the popup.
        /// The font-weight CSS property sets the weight (or boldness) of the font.
        /// Default value is normal.
        /// </summary>
        [Parameter]
        public string MenuPopupFontWeight { get; set; } = "normal";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/text-align">text-align</see> value 
        /// applied to the text element of each Menu Item in the popup.
        /// The text-align CSS property sets the horizontal alignment of the content inside a block element or table-cell box.
        /// Default value is left.
        /// </summary>
        [Parameter]
        public string MenuPopupTextAlign { get; set; } = "left";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background-color</see> value 
        /// applied to the Menu popup container.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is #FFF.
        /// </summary>
        [Parameter]
        public string MenuPopupBackgroundColor { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/box-shadow">box-shadow</see> value 
        /// applied to the Menu popup container.
        /// The box-shadow CSS property adds shadow effects around an element's frame.
        /// Default value is none.
        /// </summary>
        [Parameter]
        public string MenuPopupBoxShadow { get; set; } = "none";

        #endregion

        #endregion



        #region Callback Events Invoked from Underlying Components

        // ==================================================
        // Methods used as Callback Events from the underlying component(s)
        // ==================================================

        private async Task ClosedHandler(OpenCloseMenuEventArgs<TValue> args)
        {
            Debug.WriteLine("ClosedHandler method invoked.");
            if (Closed.HasDelegate) await Closed.InvokeAsync(args);
        }

        private async Task CreatedHandler(object args)
        {
            Debug.WriteLine("CreatedHandler method invoked.");
            if (Created.HasDelegate) await Created.InvokeAsync(args);
        }

        private async Task ItemSelectedHandler(MenuEventArgs<TValue> args)
        {
            Debug.WriteLine("ItemSelectedHandler method invoked.");
            if (ItemSelected.HasDelegate) await ItemSelected.InvokeAsync(args);
        }

        private async Task OnCloseHandler(BeforeOpenCloseMenuEventArgs<TValue> args)
        {
            Debug.WriteLine("OnCloseHandler method invoked.");
            if (OnClose.HasDelegate) await OnClose.InvokeAsync(args);
        }

        private async Task OnItemRenderHandler(MenuEventArgs<TValue> args)
        {
            Debug.WriteLine("OnItemRenderHandler method invoked.");
            if (OnItemRender.HasDelegate) await OnItemRender.InvokeAsync(args);
        }

        private async Task OnOpenHandler(BeforeOpenCloseMenuEventArgs<TValue> args)
        {
            Debug.WriteLine("OnOpenHandler method invoked.");
            if (OnOpen.HasDelegate) await OnOpen.InvokeAsync(args);
        }

        private async Task OpenedHandler(OpenCloseMenuEventArgs<TValue> args)
        {
            Debug.WriteLine("OpenedHandler method invoked.");
            if (Opened.HasDelegate) await Opened.InvokeAsync(args);
        }

        #endregion



        #region Instance Variables

        // ==================================================
        // Instance variables
        // ==================================================

        private SfMenu<TValue> menu;
        private string masterCssSelector;

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
            masterCssSelector = (CssClass == string.Empty) ? ".e-menu-container" : $".{ CssClass }.e-menu-container";

            // If the HtmlAttributes parameter is not set, create it.
            //if (HtmlAttributes is null) HtmlAttributes = new();

            // If the CssClass parameter is set, add it to HtmlAttributes if it doesn't already exist.
            //if ((CssClass != string.Empty) &&
            //    ((HtmlAttributes.TryGetValue("class", out object _) == false) &&
            //     (HtmlAttributes.TryGetValue("CLASS", out object _) == false)))
            //{
            //    HtmlAttributes.Add("class", CssClass);
            //}

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
        /// Closes the Menu if it is opened in hamburger mode.
        /// </summary>
        public async Task CloseAsync() => await this.menu.CloseAsync();

        /// <summary>
        /// Opens the Menu in hamburger mode.
        /// </summary>
        public async Task OpenAsync() => await this.menu.OpenAsync();

        /// <summary>
        /// Get the index of the menu item in the Menu based on the argument.
        /// </summary>
        /// <param name="item">Item be passed to get the index.</param>
        /// <param name="isUniqueId">Set true if it is a unique id.</param>
        /// <returns></returns>
        public List<int> GetItemIndex(TValue item, bool isUniqueId = false) => this.menu.GetItemIndex(item, isUniqueId);

        #endregion



        #region Private Methods for Internal Use Only
        #endregion

    }
}

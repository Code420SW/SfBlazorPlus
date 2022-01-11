using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Popups;

namespace Code420.SfBlazorPlus.BaseComponents.ToolTipBase
{
    public partial class ToolTipBase : ComponentBase
    {

        #region Component Parameters

        // ==================================================
        // Base Parameters
        // ==================================================


        /// <summary>
        /// Used to customize the animation of the Tooltip while opening and closing. 
        /// The animation property also allows you to set delay, duration, and various other effects of your choice. 
        /// You can set the same or different animation options to the Tooltip when it is in the open or close state. 
        /// The <see cref="Syncfusion.Blazor.Popups.AnimationModel"/> exposes the base
        /// Open and Close properties for which the <see cref="Syncfusion.Blazor.Popups.TooltipAnimationSettings"/> can be set.
        /// The default value is: Delay =  0.0ms, Duration = 0.0ms, Effect = None for both Open and Close.
        /// </summary>
        [Parameter]
        public AnimationModel Animation { get; set; }

        /// <summary>
        /// Double value specifying the number of millisecond to wait before closing the Tooltip.
        /// Default value is 0 seconds.
        /// </summary>
        [Parameter]
        public double CloseDelay { get; set; } = 0.0;

        /// <summary>
        /// String value containing the content to be displayed in the Tooltip.
        /// This property is the primary source for the tooltip content. 
        /// If this property is not set, the <see cref="ContentFragment"/> will be used.
        /// Default value is String.Empty.
        /// </summary>
        //[Parameter]
        //public string Content { get; set; } = String.Empty;

        /// <summary>
        /// Contains the <see cref="RenderFragment" /> composing the tooltip contents.
        /// This property will be used only if <see cref="Content"/> is not set.
        /// The default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment ContentFragment { get; set; } = null;

        /// <summary>
        /// String value specifying the CSS height value of the Tooltip.
        /// When the Tooltip content gets overflowed due to the height value, 
        /// then the scroll mode will be enabled. When set to auto, the Tooltip 
        /// height gets auto adjusted to display its  content within the viewable screen.
        /// Default value is Auto.
        /// </summary>
        [Parameter]
        public string Height { get; set; } = "auto";

        /// <summary>
        /// Boolean value indicating if the Tooltip is displayed in an open state until it is closed manually.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool IsSticky { get; set; } = false;

        /// <summary>
        /// Boolean value indicating if the Tooltip will follow the mouse pointer moves over the specified target element.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool MouseTrail { get; set; } = false;

        /// <summary>
        /// Double value that sets the space between the target and Tooltip element in X-axis.
        /// Default value is 0.0.
        /// </summary>
        [Parameter]
        public double OffsetX { get; set; } = 0.0;

        /// <summary>
        /// Double value that sets the space between the target and Tooltip element in Y-axis.
        /// Default value is 0.0.
        /// </summary>
        [Parameter]
        public double OffsetY { get; set; } = 0.0;

        /// <summary>
        /// Double value specifying the number of millisecond to wait before opening the Tooltip.
        /// Default value is 0.5 seconds (500ms).
        /// </summary>
        [Parameter]
        public double OpenDelay { get; set; } = 500.0;

        /// <summary>
        /// String value specifying the type of open mode to display the Tooltip content. 
        /// The available open modes are Auto, Hover, Click, Focus, and Custom. 
        /// To open the Tooltip for multiple actions, say while hovering over or clicking on a 
        /// target element, the OpensOn property can be assigned with multiple values, 
        /// separated by space such as Hover Click. 
        /// The Auto value cannot be used with any combination for multiple values.
        /// Default value is Auto.
        /// </summary>
        /// <remarks>
        /// Mode: {Desktop} [Mobile]
        /// Auto:   {Tooltip appears when you hover over the target or when the target element receives the focus.}
        ///         [Tooltip opens on tap and hold of the target element.]
        /// Hover:  {Tooltip appears when you hover over the target.}
        ///         [Tooltip opens on tap and hold of the target element]
        /// Click:  {Tooltip appears when you click a target element.}
        ///         [Tooltip appears when you single tap the target element.]
        /// Focus:  {Tooltip appears when you focus (say through tab key) on a target element.}
        ///         [Tooltip appears with a single tap on the target element.]
        /// Custom: {Tooltip is not triggered by any default action. So, you have to bind your own events and use either open or close public methods.}
        ///         [Same as Desktop.]
        /// </remarks>
        [Parameter]
        public string OpensOn { get; set; } = "Auto";

        /// <summary>
        /// <see cref="Syncfusion.Blazor.Popups.Position"/> member specifying the position of the Tooltip element with respect to the target element.
        /// Default value is BottomCenter.
        /// </summary>
        [Parameter]
        public Position Position { get; set; } = Position.TopCenter;

        /// <summary>
        /// Boolean value indicating if the tip pointer is shown with the Tooltip.
        /// Default value is true.
        /// </summary>
        [Parameter]
        public bool ShowTipPointer { get; set; } = true;

        /// <summary>
        /// String value specifying the target selector where the Tooltip needs to be displayed. 
        /// The target element is considered as the parent container.
        /// Must use full CSS target designator (e.g., #target for HTML Id or .target for HTML class).
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string Target { get; set; } = String.Empty;

        /// <summary>
        /// <see cref="Syncfusion.Blazor.Popups.TipPointerPosition"/> member specifying the position 
        /// of the tip pointer on the tooltip. The available options are Auto, Start, Middle, and End. 
        /// When set to Auto, the tip pointer gets auto adjusted within the space of the target's length and does not point outside.
        /// Default value is Auto.
        /// </summary>
        [Parameter]
        public TipPointerPosition TipPointerPosition { get; set; } = TipPointerPosition.Auto;

        /// <summary>
        /// String value specifying the CSS width value of the Tooltip.
        /// When set to auto, the Tooltip width gets auto adjusted to display its content within the viewable screen.
        /// Default value is Auto.
        /// </summary>
        [Parameter]
        public string Width { get; set; } = "auto";

        /// <summary>
        /// Boolean value used to set the collision target element as page viewport (window) or Tooltip element, when using the target. 
        /// If this property is enabled, tooltip will perform the collision calculation between the target elements. and viewport (window) instead of Tooltip element.
        /// Default value is true.
        /// </summary>
        [Parameter]
        public bool WindowCollision { get; set; } = true;


        // ==================================================
        // Event Callback Parameters
        // ==================================================


        /// <summary>
        /// An <see cref="EventCallback"/> containg the consumer's method invoked when the Tooltip is closed.
        /// </summary>
        [Parameter]
        public EventCallback<TooltipEventArgs> Closed { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containg the consumer's method invoked when the Tooltip is created.
        /// </summary>
        [Parameter]
        public EventCallback<object> Created { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containg the consumer's method invoked when the Tooltip is destroyed.
        /// </summary>
        [Parameter]
        public EventCallback<object> Destroyed { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containg the consumer's method called before the Tooltip hides from the screen. 
        /// The Tooltip close can be prevented by setting the cancel argument value to true.
        /// </summary>
        [Parameter]
        public EventCallback<TooltipEventArgs> OnClose { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containing the consumer's method invoked for every collision fit calculation.
        /// </summary>
        [Parameter]
        public EventCallback<TooltipEventArgs> OnCollision { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containg the consumer's method invoked before the Tooltip is displayed over the target element. 
        /// When one of its arguments cancel is set to true, the Tooltip display can be prevented. 
        /// This event is mainly used to refresh the Tooltip positions dynamically or to set customized styles.
        /// </summary>
        [Parameter]
        public EventCallback<TooltipEventArgs> OnOpen { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containg the consumer's method invoked before the Tooltip and its contents will be added to the DOM. 
        /// When one of its arguments cancel is set to true, the Tooltip can be prevented from rendering on the page. 
        /// This event is mainly used to customize the Tooltip before it shows up on the screen. 
        /// For example, to set new animation effects on the Tooltip.
        /// </summary>
        [Parameter]
        public EventCallback<TooltipEventArgs> OnRender { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containg the consumer's method invoked after the Tooltip component is opened.
        /// </summary>
        [Parameter]
        public EventCallback<TooltipEventArgs> Opened { get; set; }



        // ==================================================
        // CSS Styling Parameters
        // ==================================================


        /// <summary>
        /// String value containing CSS class definition(s) that will be injected in the root HTML div element of the Tooltip.
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string CssClass { get; set; } = String.Empty;

        /// <summary>
        /// String value that specifies the CSS ID in the root HTML div element of the Tooltip.
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string CssId { get; set; } = String.Empty;

        /// <summary>
        /// Collection of additional HTML attributes such as styles, class, and more that are injected in root element. 
        /// If both property and equivalent HTML attribute are configured, the component considers the property value. 
        /// This is a <see cref="Dictionary{TKey, TValue}"/> where TKey is a <see cref="string"/> and TValue is an <see cref="object"/>.
        /// Default value is null.
        /// </summary>
        [Parameter]
        public Dictionary<string, object> HtmlAttributes { get; set; }

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background-color</see> value used for the tooltip.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is #0009 [rgba(0,0,0,0.9)].
        /// </summary>
        [Parameter]
        public string TooltipBackgroundColor { get; set; } = "#0009";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border">border</see> value set used for the tooltip border.
        /// The border shorthand CSS property sets an element's border. It sets the values of border-width, border-style, and border-color.
        /// Default value is 1px solid #000.
        /// </summary>
        [Parameter]
        public string TooltipBorder { get; set; } = "1px solid #000";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius">border-radius</see> value used for the tooltip border radius.
        /// The border-radius CSS property rounds the corners of an element's outer border edge.
        /// Default value is 4px.
        /// </summary>
        [Parameter]
        public string TooltipBorderRadius { get; set; } = "4px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/filter">filter</see> value applied to the tooltip HTML element.
        /// The filter CSS property applies graphical effects like blur or color shift to an element. 
        /// Filters are commonly used to adjust the rendering of images, backgrounds, and borders.
        /// Default value is none.
        /// </summary>
        [Parameter]
        public string TooltipFilter { get; set; } = "none";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value used for the tooltip content font color.
        /// The color CSS property sets the foreground color value of an element's text and text decorations, and sets the currentcolor value.
        /// Default value is #FFF.
        /// </summary>
        [Parameter]
        public string ContentFontColor { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value used for the tooltip content.
        /// The font-size CSS property sets the size of the font. Changing the font size also updates the sizes of the font size-relative <length> units, such as em, ex, and so forth.
        /// This becomes the base em unit (=1em) for the tooltip contents and can be used to size child elements proportionally.
        /// Default value is 12px.
        /// </summary>
        [Parameter]
        public string ContentFontSize { get; set; } = "12px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/line-height">line-height</see> value used for the tooltip content.
        /// The line-height CSS property sets the height of a line box. 
        /// It's commonly used to set the distance between lines of text.
        /// Default value is 1.5.
        /// </summary>
        [Parameter]
        public string ContentLineHeight { get; set; } = "1.5";

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value used for the tooltip content.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Specify the padding in top, right, bottom, left order.
        /// Default value is: 4px 8px 4px 8px.
        /// </summary>
        [Parameter]
        public string ContentPadding { get; set; } = "4px 8px 4px 8px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value used for the tooltip tip color.
        /// The color CSS property sets the foreground color value of an element's text and text decorations, and sets the currentcolor value.
        /// Default value is #0009 [rgba(0,0,0,0.9)].
        /// </summary>
        [Parameter]
        public string TipColor { get; set; } = "#0009";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background-color</see> value used for the close button.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is #FFF.
        /// </summary>
        [Parameter]
        public string CloseButtonBackgroundColor { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value used for the close button icon color.
        /// The color CSS property sets the foreground color value of an element's text and text decorations, and sets the currentcolor value.
        /// Default value is #0009 [rgba(0,0,0,0.9)].
        /// </summary>
        [Parameter]
        public string CloseButtonIconColor { get; set; } = "#0009";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border">border</see> value set used for the close button border.
        /// The border shorthand CSS property sets an element's border. It sets the values of border-width, border-style, and border-color.
        /// Default value is 1px solid #FFF.
        /// </summary>
        [Parameter]
        public string CloseButtonBorder { get; set; } = "1px solid #FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value used for the close button icon size.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 16px.
        /// </summary>
        [Parameter]
        public string CloseButtonIconSize { get; set; } = "16px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border">border</see> value set used for the close button icon border.
        /// The border shorthand CSS property sets an element's border. It sets the values of border-width, border-style, and border-color.
        /// Default value is 1px solid #FFF.
        /// </summary>
        [Parameter]
        public string CloseButtonIconBorder { get; set; } = "1px solid #FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background-color</see> value used for the close button when hovered.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is #FFF.
        /// </summary>
        [Parameter]
        public string CloseButtonHoverBackgroundColor { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value used for the close button icon when hovered.
        /// The color CSS property sets the foreground color value of an element's text and text decorations, and sets the currentcolor value.
        /// Default value is #00000085 [rgba(0,0,0,0.85)].
        /// </summary>
        [Parameter]
        public string CloseButtonHoverIconColor { get; set; } = "#00000085";


        #endregion



        #region Callback Events Invoked from Underlying Components

        // ==================================================
        // Methods used as Callback Events from the underlying component(s)
        // ==================================================

        /// <summary>
        /// An <see cref="EventCallback"/> cast as an <see cref="Action"/> that encapsulated
        /// consumer's method called when the button is clicked.
        /// </summary>
        //public void Click() => OnClick.Invoke();

        #endregion



        #region Instance Variables

        // ==================================================
        // Instance variables
        // ==================================================

        private SfTooltip sfTooltip;                            // SF Tooltip component
        private string masterCssSelector = String.Empty;        // The master selector for the HTML div element

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

            // Build the master selector
            masterCssSelector = ((CssClass == String.Empty) ? ".e-tooltip-wrap" : $".{ CssClass }.e-tooltip-wrap");

            // Need to ensure a non-null Animation exists so SfTooltip doesn't throw an exception
            if (Animation is null)
            {
                Animation = new();
                Animation.Open = new();
                Animation.Open.Delay = 0.0;
                Animation.Open.Duration = 0.0;
                Animation.Open.Effect = Effect.None;
                Animation.Close = new();
                Animation.Close.Delay = 0.0;
                Animation.Close.Duration = 0.0;
                Animation.Close.Effect = Effect.None;
            }
        }

        // Once the state from the ParameterCollection has been assigned to the component’s
        //  [Parameter] properties, this method is executed. This is useful in the same way
        //  as SetParametersAsync, except it is possible to use the component’s state.
        // This method is only executed once when the component is first created. If the parent
        //  changes the component’s parameters at a later time, this method is skipped.
        // When the component is a @page, and our Blazor app navigates to a new URL that renders
        //  the same page, Blazor will reuse the current object instance for that page. Because the
        //  object is the same instance, Blazor does not call IDisposable.Dispose on the object,
        //  nor does it execute its OnInitialized method again.
        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
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
        /// Used to hide the Tooltip with a specific animation effect.
        /// </summary>
        /// <param name="animation"><see cref="Syncfusion.Blazor.Popups.TooltipAnimationSettings"/> settings for tooltip close action</param>
        /// <returns></returns>
        public async Task CloseAsync(TooltipAnimationSettings animation = null)
        {
            if (animation is null)
            {
                animation = new();
                animation.Delay = 0.0;
                animation.Duration = 0.0;
                animation.Effect = Effect.None;
            }

            await this.sfTooltip.CloseAsync(animation);
        }

        /// <summary>
        /// Used to show the Tooltip on the specified target with specific animation settings. 
        /// You can also pass the additional arguments like target element in which the tooltip should appear and animation settings for the tooltip open action.
        /// </summary>
        /// <param name="element">Target element in which the tooltip should appear.</param>
        /// <param name="animation"><see cref="Syncfusion.Blazor.Popups.AnimationModel"/> settings for the tooltip open action.</param>
        /// <returns></returns>
        public async Task OpenAsync(Nullable<ElementReference> element = null, TooltipAnimationSettings animation = null) =>
            await this.sfTooltip.OpenAsync(element, animation);

        /// <summary>
        /// Refresh the tooltip component when the target element is dynamically used.
        /// </summary>
        public async Task RefreshAsync() => await this.sfTooltip.RefreshAsync();

        /// <summary>
        /// Dynamically refreshes the tooltip element position based on the target element.
        /// </summary>
        /// <param name="target">The target element.</param>
        /// <returns></returns>
        public async Task RefreshPositionAsync(Nullable<ElementReference> target = null) => await this.sfTooltip.RefreshPositionAsync(target);


        #endregion



        #region Private Methods for Internal Use Only
        #endregion
    }
}

using Microsoft.AspNetCore.Components;

namespace Code420.SfBlazorPlus.CustomComponents.StepProgressIndicator
{

    //
    // The component creates a step-progress indicator consisting of a series of dots.
    // One of the dots is active at any time. The balance of the dots are inactive.
    //
    // The component is used to provide the user with a visual indication of progress
    // through a sequence of steps.
    //

    public partial class StepProgressIndicator : ComponentBase
    {

        #region Component Parameters

        // ==================================================
        // Base Parameters
        // ==================================================


        /// <summary>
        /// Integer value specifying the number of indicator dots to be rendered.
        /// Value must be a positive, non-zero value.
        /// Default value is 3.
        /// </summary>
        [Parameter]
        public int IndicatorCount { get; set; } = 3;

        /// <summary>
        /// Integer value specifying the active indicator.
        /// Value must be between 1 and <paramref name="IndicatorCount" />, inclusive.
        /// Default value is 1.
        /// </summary>
        [Parameter]
        public int ActiveIndicator { get; set; } = 1;


        // ==================================================
        // Event Callback Parameters
        // ==================================================



        // ==================================================
        // CSS Styling Parameters
        // ==================================================


        /// <summary>
        /// String value containing CSS class definition(s) that will be injected in the root HTML div element containing the step incicators.
        /// Default value is container__indicators.
        /// </summary>
        [Parameter]
        public string CssClass { get; set; } = "container__indicators";

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/height">height</see> value for the container.
        /// The height CSS property specifies the height of an element. By default, the property defines the height of the content area.
        /// Default value is 100% indicating the container is the same height as the containing HTML element.
        /// </summary>
        [Parameter]
        public string ContainerHeight { get; set; } = "100%";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background">background</see> value for the container.
        /// The background shorthand CSS property sets all background style properties at once, such as color, image, origin and size, or repeat method.
        /// Default value is transparent.
        /// </summary>
        [Parameter]
        public string ContainerBackground { get; set; } = "transparent";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom">border-border</see> value for the container.
        /// The border-bottom shorthand CSS property sets an element's bottom border. It sets the values of border-bottom-width, border-bottom-style and border-bottom-color.
        /// Default value is 1px solid #CCC.
        /// </summary>
        [Parameter]
        public string ContainerBottomBorder { get; set; } = "1px solid #CCC";

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/height">height</see> value for the indicator.
        /// Indicators are rendered as dot (width = height).
        /// The height CSS property specifies the height of an element. By default, the property defines the height of the content area.
        /// Default value is 12px
        /// </summary>
        [Parameter]
        public string IndicatorHeight { get; set; } = "12px";

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/margin">margin</see> value used for the indicators.
        /// The margin CSS shorthand property sets the margin area on all four sides of an element.
        /// Specify the margin in top, right, bottom, left order. Or use any of the margin shorhands.
        /// Default value is: 5px on all sides.
        /// </summary>
        [Parameter]
        public string IndicatorMargin { get; set; } = "5px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background">background</see> value for the active indicator.
        /// The background shorthand CSS property sets all background style properties at once, such as color, image, origin and size, or repeat method.
        /// Default value is #FF8F00.
        /// </summary>
        [Parameter]
        public string ActiveIndicatorBackground { get; set; } = "#FF8F00";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background">background</see> value for the inactive indicators.
        /// The background shorthand CSS property sets all background style properties at once, such as color, image, origin and size, or repeat method.
        /// Default value is #00000033 = rgba(0, 0, 0, 0.2).
        /// </summary>
        [Parameter]
        public string InactiveIndicatorBackground { get; set; } = "#00000033";




        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value for the label font color.
        /// The color CSS property sets the foreground color value of an element's text and text decorations, and sets the currentcolor value.
        /// Default value is black.
        /// </summary>
        [Parameter]
        public string FontColor { get; set; } = "black";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value for the label.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 1rem.
        /// </summary>
        [Parameter]
        public string FontSize { get; set; } = "1rem";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight">font-weight</see> value for the label.
        /// The font-weight CSS property sets the weight (or boldness) of the font. The weights available depend on the font-family that is currently set.
        /// Default value is normal.
        /// </summary>
        [Parameter]
        public string FontWeight { get; set; } = "normal";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-style">font-style</see> value for the label.
        /// The font-style CSS property sets whether a font should be styled with a normal, italic, or oblique face from its font-family.
        /// Default value is normal.
        /// </summary>
        [Parameter]
        public string FontStyle { get; set; } = "normal";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/text-align">text-align</see> value for the label.
        /// The text-align CSS property sets the horizontal alignment of the content inside a block element or table-cell box.
        /// Default value is left.
        /// </summary>
        [Parameter]
        public string TextAlign { get; set; } = "left";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/text-decoration">text-decoration</see> value for the label.
        /// The text-decoration shorthand CSS property sets the appearance of decorative lines on text. It is a shorthand for text-decoration-line, text-decoration-color, text-decoration-style, and the newer text-decoration-thickness property.
        /// Default value is none.
        /// </summary>
        [Parameter]
        public string TextDecoration { get; set; } = "none";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/text-transform">text-transform</see> value for the label.
        /// The text-transform CSS property specifies how to capitalize an element's text. It can be used to make text appear in all-uppercase or all-lowercase, or with each word capitalized.
        /// Default value is none.
        /// </summary>
        [Parameter]
        public string TextTransform { get; set; } = "none";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background-color</see> value for the label.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is transparent.
        /// </summary>
        [Parameter]
        public string LabelBackgroundColor { get; set; } = "transparent";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border">border</see> value for the label.
        /// The border shorthand CSS property sets an element's border. It sets the values of border-width, border-style, and border-color.
        /// Default value is none.
        /// </summary>
        [Parameter]
        public string LabelBorder { get; set; } = "none";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius">border-radius</see> value for the label.
        /// The border-radius CSS property rounds the corners of an element's outer border edge.
        /// Default value is none.
        /// </summary>
        [Parameter]
        public string LabelBorderRadius { get; set; } = "0";

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/margin">margin</see> value used for the label.
        /// The margin CSS shorthand property sets the margin area on all four sides of an element.
        /// Specify the margin in top, right, bottom, left order. Or use any of the margin shorhands.
        /// Default value is: 0px on all sides.
        /// </summary>
        [Parameter]
        public string LabelMargin { get; set; } = "0px";

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value for the label.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Specify the padding in top, right, bottom, left order. Or use any of the padding shorhands.
        /// Default value is: 0px on all sides.
        /// </summary>
        [Parameter]
        public string LabelPadding { get; set; } = "0px";




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

        private string masterCssSelector = String.Empty;        // The master selector for the HTML div element
        private string spanString = String.Empty;               // The class for the HTML label element

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

            // Make sure a positive, non-zero value is in IndicatorCount
            // Set to 1 if needed
            if (IndicatorCount < 1) IndicatorCount = 1;

            // Do some validation on the ActiveIndicator parameter
            if (ActiveIndicator < 1)
            {
                ActiveIndicator = 1;
            }
            else if (ActiveIndicator > IndicatorCount)
            {
                ActiveIndicator = IndicatorCount;
            }

            // Build the master CSS selector
            masterCssSelector = "." + CssClass;
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

            // Build the string containing the <span> tags to be injected in the HTML
            for (int i = 0; i < IndicatorCount; i++) spanString += "<span></span>";
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
        /// Sets the ActiveIndicator to the passed value.
        /// </summary>
        /// <param name="value">
        /// Integer representing the indicator to be activated.
        /// </param>
        public void SetActiveIndicator(int value)
        {
            this.ActiveIndicator = value;
            InvokeAsync(StateHasChanged);
        }


        #endregion


        #region Private Methods for Internal Use Only
        #endregion
    }
}

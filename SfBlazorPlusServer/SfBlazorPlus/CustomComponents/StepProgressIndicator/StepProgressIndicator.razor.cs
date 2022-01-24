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
        /// String value containing CSS class definition(s) that will be injected in the root HTML div element containing the step indicators.
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
        /// The height CSS property specifies the height of an element. By default, the property defines the height of the content area.
        /// Indicators are rendered as dots (width = height).
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
        /// Default value is rgba(0, 0, 0, 0.2).
        /// </summary>
        [Parameter]
        public string InactiveIndicatorBackground { get; set; } = "rgba(0, 0, 0, 0.2)";


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

            // Build the master CSS selector
            masterCssSelector = "." + CssClass;
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
            // Do some validation on the passed value.
            if (value < 1)
            {
                value = 1;
            }
            else if (value > IndicatorCount)
            {
                value = IndicatorCount;
            }

            this.ActiveIndicator = value;
            InvokeAsync(StateHasChanged);
        }


        #endregion


        #region Private Methods for Internal Use Only
        #endregion
    }
}

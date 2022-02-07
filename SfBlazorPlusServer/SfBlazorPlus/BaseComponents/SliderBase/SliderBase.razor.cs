using Code420.SfBlazorPlus.Code.CssUtilities;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Inputs;

namespace Code420.SfBlazorPlus.BaseComponents.SliderBase
{
    public partial class SliderBase<TValue> : ComponentBase
    {

        #region Component Parameters

        // ==================================================
        // Base Parameters
        // ==================================================

        /// <summary>
        /// <typeparamref name="TValue"/> data type containing the value of the slider.
        /// </summary>
        [Parameter]
        public TValue Value { get; set; }

        /// <summary>
        /// Double value that specifies the minimum value of the slider.
        /// Default value 0.0.
        /// </summary>
        [Parameter]
        public double ValueMin { get; set; } = 0.0;

        /// <summary>
        /// Double value that specifies the maximum value of the slider.
        /// Default value 10.0.
        /// </summary>
        [Parameter]
        public double ValueMax { get; set; } = 10.0;

        /// <summary>
        /// Double value that specifies the step value for each value change when the increase / decrease button is clicked or on arrow keys press or on dragging the thumb.
        /// Default value 1.0.
        /// </summary>
        [Parameter]
        public double ValueStep { get; set; } = 1.0;

        /// <summary>
        /// String array containing slider values in number or string type. 
        /// The <see cref="ValueMin"/>, <see cref="ValueMax"/> and <see cref="ValueStep"/> are not considered when custom values are specified.
        /// Default value is null.
        /// </summary>
        [Parameter]
        public string[] CustomValues { get; set; } = null;

        /// <summary>
        /// <see cref="SliderOrientation"/> value that specifies whether to render the slider in vertical or horizontal orientation.
        /// Default value is Horizontal.
        /// </summary>
        [Parameter]
        public SliderOrientation Orientation { get; set; } = SliderOrientation.Horizontal;

        /// <summary>
        /// Boolean value indicating if the slider is enabled.
        /// Default value is true.
        /// </summary>
        [Parameter]
        public bool Enabled { get; set; } = false;

        /// <summary>
        /// Boolean value indicating if slider movement animations are enabled.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool EnableAnimation { get; set; } = false;

        /// <summary>
        /// Boolean value that specifies whether the <see cref="Value"/> should be updated while the slider handle is dragged, or after dragging the slider handle is complete.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool IsImmediateValue { get; set; } = false;

        /// <summary>
        /// Boolean value that specifies whether the render the slider in read-only mode to restrict any user interaction. 
        /// The slider rendered with user defined values and can’t be interacted with user actions.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; } = false;

        /// <summary>
        /// Boolean value that specifies whether to show or hide the increase/decrease buttons with the slider to change the slider value.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool ShowButtons { get; set; } = false;



        /// <summary>
        /// Boolean value that specifies whether to apply the Ticks* parameters to the slider
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool TicksEnabled { get; set; } = false;

        /// <summary>
        /// String value used to customize the slider scale value to the desired format using internationalization or events (custom formatting). 
        /// Valid prefixes include the predefined formatting styles: Numeric (N), Percentage (P), Currency (C) and # specifiers.
        /// Default value is N2.
        /// </summary>
        [Parameter]
        public string TicksFormat { get; set; } = "N2";

        /// <summary>
        /// Double value used to denote the distance between two major (large) ticks from the scale of the slider.
        /// Default value 1.0.
        /// </summary>
        [Parameter]
        public double TicksLargeStep { get; set; } = 1.0;

        /// <summary>
        /// <see cref="Placement"/> value used to specify the position of the ticks in the slider.
        /// Default value is After (ticks placed below a horizontal slider).
        /// </summary>
        [Parameter]
        public Placement TicksPlacement { get; set; } = Placement.After;

        /// <summary>
        /// Boolean value that specifies whether to show or hide the small ticks between the large ticks.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool TicksShowSmallTicks { get; set; } = false;

        /// <summary>
        /// Double value used to denote the distance between two minor (sma;ll) ticks from the scale of the slider.
        /// Default value 1.0.
        /// </summary>
        [Parameter]
        public double TicksSmallStep { get; set; } = 1.0;



        /// <summary>
        /// Boolean value that specifies whether to apply the Tooltip* parameters to the slider
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool TooltipsEnabled { get; set; } = false;

        /// <summary>
        /// String value used to customize the Tooltip content to the desired format using internationalization or events (custom formatting). 
        /// Valid prefixes include the predefined formatting styles: Numeric (N), Percentage (P), Currency (C) and # specifiers.
        /// Default value is N2.
        /// </summary>
        [Parameter]
        public string TooltipsFormat { get; set; } = "N2";

        /// <summary>
        /// Boolean value that specifies whether to show or hide the Tooltip of slider component.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool TooltipsIsVisible { get; set; } = false;

        /// <summary>
        /// <see cref="TooltipPlacement"/> value used to denote the position for the tooltip element in the Slider. 
        /// Default value is Before.
        /// </summary>
        [Parameter]
        public TooltipPlacement TooltipsPlacement { get; set; } = TooltipPlacement.Before;

        /// <summary>
        /// <see cref="TooltipShowOn"/> value used to denote the position for the tooltip element in the Slider. 
        /// Default value is Auto.
        /// </summary>
        [Parameter]
        public TooltipShowOn TooltipsShowOn { get; set; } = TooltipShowOn.Auto;



        /// <summary>
        /// Boolean value that specifies whether to apply the Events* parameters to the slider.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool EventsEnabled { get; set; } = false;



        // ==================================================
        // Event Callback Parameters
        // ==================================================


        /// <summary>
        /// An <see cref="EventCallback<typeparamref name="TValue"/>"/> containng the consumer's method invoked when the slider value changes.
        /// </summary>
        [Parameter]
        public EventCallback<TValue> ValueChanged { get; set; }

        /// <summary>
        /// An <see cref="EventCallback<typeparamref name="TValue"/>"/> containng the consumer's method invoked when the slider is successfully created.
        /// </summary>
        [Parameter]
        public EventCallback<object> EventsCreated { get; set; }

        /// <summary>
        /// An <see cref="EventCallback<typeparamref name="TValue"/>"/> containng the consumer's method invoked when the slider is destroyed.
        /// </summary>
        [Parameter]
        public EventCallback<object> EventsDestroyed { get; set; }

        /// <summary>
        /// An <see cref="EventCallback<<see cref="SliderChangeEventArgs{TValue}"/>>/> containng the consumer's method invoked while the slider thumb is dragged.
        /// </summary>
        [Parameter]
        public EventCallback<SliderChangeEventArgs<TValue>> EventsOnChange { get; set; }

        /// <summary>
        /// An <see cref="EventCallback<<see cref="SliderChangeEventArgs{TValue}"/>>/> containng the consumer's method invoked when the slider tooltip is changed.
        /// Default value is null.
        /// </summary>
        [Parameter]
        public EventCallback<SliderTooltipEventArgs<TValue>> EventsOnTooltipChange { get; set; }

        /// <summary>
        /// An <see cref="EventCallback<<see cref="SliderTickRenderedEventArgs"/>>/> containng the consumer's method invoked when the ticks are rendered on the slider.
        /// </summary>
        [Parameter]
        public EventCallback<SliderTickRenderedEventArgs> EventsTicksRendered { get; set; }

        /// <summary>
        /// An <see cref="EventCallback<<see cref="SliderTickEventArgs"/>>/> containng the consumer's method invoked when rendering the ticks element in the slider.
        /// Used to customize the ticks labels dynamically.
        /// </summary>
        [Parameter]
        public EventCallback<SliderTickEventArgs> EventsTicksRendering { get; set; }

        /// <summary>
        /// An <see cref="EventCallback<<see cref="SliderChangeEventArgs{TValue}"/>>/> containng the consumer's method invoked when the slider tooltip is changed.
        /// </summary>
        [Parameter]
        public EventCallback<SliderChangeEventArgs<TValue>> EventsValueChange { get; set; }



        // ==================================================
        // CSS Styling Parameters
        // ==================================================



        /// <summary>
        /// String value containing CSS class definition(s) that will be injected in the HTML at the slider control level and allow access to the track, handle and scale selectors within the slider control. 
        /// The CssClass is used to build the CSS ID for the slider wrapper HTML element that wraps the SfSlider component.
        /// This is needed since CssClass (and CssId) are injected in the slider control HTML elemt which is a sibling of the slider buttons.
        /// Without the slider wrapper div, the slider buttons are not addressible.
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string CssClass { get; set; } = String.Empty;

        /// <summary>
        /// String value that specifies the CSS ID attribute injected in the slider control div. 
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string CssId { get; set; } = String.Empty;

        /// <summary>
        /// String value used to customize the Tooltip which accepts custom CSS class names that define specific user-defined styles and themes to be applied on the Tooltip element.
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string TooltipsCssClass { get; set; } = String.Empty;

        /// <summary>
        /// String containing the CSS width value for the slider container.
        /// Default value is 200px.
        /// </summary>
        [Parameter]
        public string SliderContainerWidth { get; set; } = "200px";

        /// <summary>
        /// String containing the CSS height/width value for the thickness of the slider track whether horizontal/vertical. 
        /// The track heigh should be between 6px and 18px. 
        /// Even values will produce more consistent visual results.
        /// Default value is 6px.
        /// </summary>
        [Parameter]
        public string TrackHeight { get; set; } = "6px";

        /// <summary>
        /// String containing the CSS background-color value for the slider track whether horizontal/vertical.
        /// Default value is #DEE2E6.
        /// </summary>
        [Parameter]
        public string TrackBackgroundColor { get; set; } = "#DEE2E6";

        /// <summary>
        /// String containing the CSS background-color value for the slider buttons.
        /// Default value is #6C757D.
        /// </summary>
        [Parameter]
        public string ButtonBackgroundColor { get; set; } = "#6C757D";

        /// <summary>
        /// String containing the CSS height/width value for the size of the slider buttons.
        /// Default value is 16px.
        /// </summary>
        [Parameter]
        public string ButtonSize { get; set; } = "16px";

        /// <summary>
        /// String containing the CSS height/width value for the size of the slider button icons.
        /// Default value is 8px.
        /// </summary>
        [Parameter]
        public string ButtonIconSize { get; set; } = "8px";

        /// <summary>
        /// String containing the CSS background-color value for the slider handle.
        /// Default value is #007BFF.
        /// </summary>
        [Parameter]
        public string HandleBackgroundColor { get; set; } = "#007BFF";

        /// <summary>
        /// String containing the CSS height/width value for the size of the slider handle.
        /// Default value is 14px.
        /// </summary>
        [Parameter]
        public string HandleSize { get; set; } = "14px";

        /// <summary>
        /// String containing the CSS background-color value for the slider handle.
        /// Default value is #212529.
        /// </summary>
        [Parameter]
        public string TickFontColor { get; set; } = "#212529";

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

        private SfSlider<TValue> sfSlider;                      // SF Slider component
        private string masterCssSelector = String.Empty;        // The master CSS selector for the slider container and ots children
        private string cssIdSliderWrapper = String.Empty;       // The CSS selector for the slider wrapper div needed so the slider buttons can be addressed
        private string boxShadowRgba = String.Empty;            // The RGBA value when styling the box shadow used when the handle is active

        #endregion


        #region Injected Dependencies

        // Injected Dependencies
        private ICssUtilities _cssUtilities;


        // Dependency Injection
        [Inject]
        ICssUtilities cssUtilities { get => _cssUtilities; set => _cssUtilities = value; }

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

            // Buid the CSS ID for the slider wrapper div
            // The slider wrapper div is an HTML element we inject and contains the SfSlider component.
            // The wrapper is needed so that the slider buttons are addressible.
            // The CssId and CssClass properties are injected (by SfSlider) in the slider control div which is a sibling of the slider buttons.
            cssIdSliderWrapper = ((CssClass == String.Empty) ? "id-slider-wrapper__" : $"id-slider-wrapper__{ CssClass }");

            // Build the master selector
            // This is based on a constructed CSS ID for slider wrapper div and is used to access all elements in the div.
            masterCssSelector = $"#{ cssIdSliderWrapper } .e-slider-container";

            boxShadowRgba = await _cssUtilities.ConvertToRgba(HandleBackgroundColor, 0.25m);
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
        /// Disables the slider.
        /// </summary>
        public void Disable()
        {
            this.Enabled = false;
            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Enables the slider.
        /// </summary>
        public void Enable()
        {
            this.Enabled = true;
            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Provided access to the Slider component's RepositionAsync
        /// method which needs to be invoked after the Slider's parent
        /// container has been opened so that the Slider can correctly
        /// size/position itseld in the parent.
        /// </summary>
        /// <returns></returns>
        public async Task RepositionAsync()
        {
            await this.sfSlider.RepositionAsync();
        }

        #endregion


        #region Private Methods for Internal Use Only
        #endregion
    }
}

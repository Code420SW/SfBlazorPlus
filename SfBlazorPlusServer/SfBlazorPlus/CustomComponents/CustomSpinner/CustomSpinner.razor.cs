using Code420.SfBlazorPlus.BaseComponents.SimpleCardBase;
using Code420.SfBlazorPlus.Code.Enums;
using Code420.SfBlazorPlus.CustomComponents.CustomSpinner.MyCustomSpinners;
using Microsoft.AspNetCore.Components;

namespace Code420.SfBlazorPlus.CustomComponents.CustomSpinner
{

    //
    // This component is used to encapsulate custom spinner definition elements.
    // The custom spinner definitions are defined in the CustomSpinners enum.
    // The OnInitializedAsync constructor determines the typeof() string for the spinner component defined in the Spinner property.
    // This is used by the <DynamicComponent> to render the custom spinner definition.
    // A pre-determned set of parameters are also passed to the <DynamicComponent>
    //
    // Each custom spinner definition is a self-contained HTML/CSS required to fully render the spinner.
    // Each definition must define the pre-determined set of parameters passed in by the <DynamicComponent> or an exception is thrown.
    //
    // This component uses a SimpleCardBase com[ponent to encapsulate the custom spinner definition in the card body.
    // This component accepts an optional RenderFragment for a loading message which, if defined, will be rendered in the card header.
    //
    // The SpinnerMargin parameter is mapped to the SimpleCardBase's CardMargin property and is used to position the card on the screen.
    //

    public partial class CustomSpinner : ComponentBase
    {

        #region Component Parameters

        // ==================================================
        // Base Parameters
        // ==================================================

        /// <summary>
        /// <see cref="CustomSpinners"/> member specifying the custom spinner definition to display.
        /// Default value is SwingingBall.
        /// </summary>
        [Parameter]
        public CustomSpinners Spinner { get; set; } = CustomSpinners.SwingingBall;

        /// <summary>
        /// Contains the <see cref="RenderFragment" /> composing the header section of the card encapsulating the spinner.
        /// The default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment LoadingMessageContent { get; set; } = null;


        // ==================================================
        // Event Callback Parameters
        // ==================================================



        // ==================================================
        // CSS Styling Parameters
        // ==================================================

        /// <summary>
        /// String value containing CSS class definition(s) that will be injected in the root HTML div element of the Tooltip.
        /// Default value is custom__spinner.
        /// </summary>
        [Parameter]
        public string CssClass { get; set; } = "custom__spinner";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/margin">margin</see> value used for the margin around the card encapsulating the spinner.
        /// The margin CSS shorthand property sets the margin area on all four sides of an element
        /// This parameter is used to position the card encapsulating the spinner on the screen.
        /// Default value is auto.
        /// </summary>
        [Parameter]
        public string SpinnerMargin { get; set; } = "auto";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background">background</see> value used for the Card.
        /// The background shorthand CSS property sets all background style properties at once, such as color, image, origin and size, or repeat method.
        /// Default value is #FFF (background-color).
        /// </summary>
        [Parameter]
        public string SpinnerBackground { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border">border</see> value used for the Card.
        /// The border shorthand CSS property sets an element's border. It sets the values of border-width, border-style, and border-color.
        /// Default value is 1px solid rgba(0,0,0,0.12).
        /// </summary>
        [Parameter]
        public string SpinnerBorder { get; set; } = "1px solid rgba(0,0,0,0.12)";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius">border-radius</see> value used for the Card.
        /// The border-radius CSS property rounds the corners of an element's outer border edge.
        /// Default value is 4px.
        /// </summary>
        [Parameter]
        public string SpinnerBorderRadius { get; set; } = "4px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/box-shadow">box-shadow</see> value used for the Card.
        /// The box-shadow CSS property adds shadow effects around an element's frame.
        /// Default value is none.
        /// </summary>
        [Parameter]
        public string SpinnerBoxShadow { get; set; } = "none";

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
        SimpleCardBase simpleCardBase;                          // The custom spinner is rendered in a SimleCardBase component
        private string spinnerType;                             // Contains the typeof() definition for the custom spinner definition element specified by the Spinner parameter
        Dictionary<string, object> spinnerParams;               // Contains the parameters passed to the <DynamicComponent>
        private bool includeHeader;                             // Indicates if the consumer specified a LoadMessageContent

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

            // Build the master selector
            masterCssSelector = $".{ CssClass }";

            // Determine if HeaderContent is defined
            includeHeader = (LoadingMessageContent is not null);

            // Get the type of the spinner to display
            // Right now an enum is used and the switch statement hard-codes the selected
            //  custon spinner definition element associated with an enum.
            // There should be a better way to do this.
            spinnerType = Spinner switch
            {
                CustomSpinners.SwingingBall => typeof(CustomSpinnerSwingingBall).AssemblyQualifiedName,
                _ => typeof(CustomSpinnerSwingingBall).AssemblyQualifiedName,
            };

            // Build the dictionary of parameters that is passed to the <DynamicComponent>
            // Each custom spinner definition element (e.g., ) must accept these parameters or an exception will be thrown.
            // It would be better to find a way to define parameters for a custom spinner definition uniquely.
            spinnerParams = new Dictionary<string, object>()
            {
                { "Height", "300px" },
                { "Width", "300px" }
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




        #endregion



        #region Private Methods for Internal Use Only
        #endregion
    }
}

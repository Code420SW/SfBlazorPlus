using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Buttons;
using System;
using System.Threading.Tasks;

namespace Code420.SfBlazorPlus.BaseComponents.SwitchBase
{
    public partial class SwitchBase<TChecked> : ComponentBase
    {

        #region Component Parameters

        // ==================================================
        // Base Parameters
        // ==================================================

        /// <summary>
        /// <typeparamref name="TChecked"/> value indicating if the switch is in the
        /// on or off state.
        /// </summary>
        [Parameter]
        public TChecked Value { get; set; }


        /// <summary>
        /// String containing the text displated when the switch is in the on position.
        /// Defauly value is On.
        /// </summary>
        [Parameter]
        public string OnLabel { get; set; } = "On";

        /// <summary>
        /// String containing the text displated when the switch is in the off position.
        /// Default alue is Off
        /// </summary>
        [Parameter]
        public string OffLabel { get; set; } = "Off";

        /// <summary>
        /// Boolean value indicating if the switch is disabled.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool IsDisabled { get; set; } = false;

        /// <summary>
        /// Boolean value indicating if the switch <see cref="Value"/> parameter is
        /// persisted between page reloads.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool EnablePersistence { get; set; } = false;

        /// <summary>
        /// String value that defines CSS name attribute for the HTML input element.
        /// Default value is null.
        /// </summary>
        [Parameter]
        public string NameAttribute { get; set; }

        /// <summary>
        /// String value that defines CSS value attribute for the HTML input element.
        /// Default value is null.
        /// </summary>
        [Parameter]
        public string ValueAttribute { get; set; }


        // ==================================================
        // Event Callback Parameters
        // ==================================================

        /// <summary>
        /// An <see cref="EventCallback<typeparamref name="TChecked"/>"/> containng the consumer's 
        /// method called when the switch value changes.
        /// </summary>
        [Parameter]
        public EventCallback<ChangeEventArgs<TChecked>> ValueChanged { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containg the consumer's 
        /// method called when the Masked Textbox is created.
        /// </summary>
        [Parameter]
        public EventCallback<object> Created { get; set; }


        // ==================================================
        // CSS Styling Parameters
        // ==================================================

        /// <summary>
        /// String value containing CSS class definition(s) that will be injected in the root HTML div element of the Masked Textbox.
        /// Default value is switch__.
        /// </summary>
        [Parameter]
        public string CssClass { get; set; } = "switch__";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/height">height</see> value used for the switch.
        /// The height CSS property specifies the height of an element.
        /// Default value is 16px.
        /// </summary>
        [Parameter]
        public string Height { get; set; } = "16px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/width">width</see> value used for the switch.
        /// The width CSS property sets an element's width.
        /// Default value is 38px.
        /// </summary>
        [Parameter]
        public string Width { get; set; } = "38px";


        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value used for the switch.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 12px.
        /// </summary>
        [Parameter]
        public string LabelFontSize { get; set; } = "12px";


        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value used for the switch.
        /// The color CSS property sets the foreground color value of an element's text and text decorations.
        /// Default value is #FFF
        /// </summary>
        [Parameter]
        public string LabelFontColor { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background</see> value used for the switch.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is #007BFF.
        /// </summary>
        [Parameter]
        public string BackgroundColor { get; set; } = "#007BFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-color">border-color</see> value used for the switch.
        /// The border-color shorthand CSS property sets the color of an element's border.
        /// Default value is #ADB5BD.
        /// </summary>
        [Parameter]
        public string BorderColor { get; set; } = "#ADB5BD";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background</see> value used for the switch when hovered.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is #007BFF.
        /// </summary>
        [Parameter]
        public string HoverBackgroundColor { get; set; } = "#007BFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-color">border-color</see> value used for the switch when hovered.
        /// The border-color shorthand CSS property sets the color of an element's border.
        /// Default value is <see cref="BorderColor"/> if set, otherwise the bootstrap default is used.
        /// </summary>
        [Parameter]
        public string HoverBorderColor { get; set; } = String.Empty;

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background</see> value used for the switch handle when hovered.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is #FFF.
        /// </summary>
        [Parameter]
        public string HandleHoverBackgroundColor { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background</see> value used for the switch handle.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is #ADB5BD.
        /// </summary>
        [Parameter]
        public string HandleBackgroundColor { get; set; } = "#ADB5BD";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/height">height</see> value used for the switch handle.
        /// The height CSS property specifies the height of an element.
        /// Since the switch handle is round, the same value is used for the CSS width style.
        /// Default value is 12px
        /// </summary>
        [Parameter]
        public string HandleHeight { get; set; } = "12px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/margin">margin</see> value used for the switch margin.
        /// The margin CSS shorthand property sets the margin area on all four sides of an element
        /// Default value is 0px all sides.
        /// </summary>
        [Parameter]
        public string Margin { get; set; } = "0px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value used for the switch padding.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Default value is 0px all sides.
        /// </summary>
        [Parameter]
        public string Padding { get; set; } = "0px";

        #endregion


        #region Callback Events from Underlying Components

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

        private SfSwitch<TChecked> sfSwitch;

        private string masterDivSelector = String.Empty;        // The master selector for the HTML div element

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

            // Set parameter defaults
            if (HoverBorderColor == String.Empty) HoverBorderColor = BorderColor;

            // Build the master selector
            //masterLabelSelector = ((CssId == String.Empty) ? "#label_" : $"#label_{ CssId }");
            masterDivSelector = ((CssClass == String.Empty) ? ".e-switch-wrapper" : $".{ CssClass }.e-switch-wrapper");
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


        #region Methods Providing Access to Component Properties to the Consumer

        // ==================================================
        // Public Methods providing access to the underlying component to the consumer
        // ==================================================

        /// <summary>
        /// Disables the switch.
        /// </summary>
        public void Disable()
        {
            this.IsDisabled = true;
            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Enables the switch.
        /// </summary>
        public void Enable()
        {
            this.IsDisabled = false;
            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Sets the focus to SfSwitch component for interaction.
        /// </summary>
        public async Task FocusAsync() => await this.sfSwitch.FocusAsync();

        #endregion


        #region Private Methods for Internal Use Only
        #endregion

    }
}

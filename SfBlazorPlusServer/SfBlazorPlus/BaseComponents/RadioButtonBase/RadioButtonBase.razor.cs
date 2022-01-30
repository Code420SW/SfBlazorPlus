using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Buttons;
using System;
using System.Threading.Tasks;

namespace Code420.SfBlazorPlus.BaseComponents.RadioButtonBase
{

    //
    //
    //

    public partial class RadioButtonBase<TChecked> : ComponentBase
    {

        #region Component Parameters

        // ==================================================
        // Base Parameters
        // ==================================================


        /// <summary>
        /// <typeparamref name="TChecked"/> value indicating if the radio button is in the selected/unselected state.
        /// </summary>
        [Parameter]
        public TChecked Checked { get; set; }

        /// <summary>
        /// String value specifying the text element displayed with the Radio Button.
        /// The Label parameter is the display element of the radio button whereas the <see cref="Value" /> parameter is the data element for the radio button.
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string Label { get; set; } = String.Empty;

        /// <summary>
        /// <see cref="Syncfusion.Blazor.Buttons.LabelPosition"/> member specifying the position of the label with respect to the radio button.
        /// Before: The label is positioned to left of the RadioButton. After: The label is positioned to right of the RadioButton.
        /// Default value is After.
        /// </summary>
        [Parameter]
        public LabelPosition LabelPosition { get; set; } = LabelPosition.After;

        /// <summary>
        /// Boolean value indicating if the radio button is disabled.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool Disabled { get; set; } = false;

        /// <summary>
        /// Boolean value indicating if the radio button's state persists between page reloads..
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool EnablePersistance { get; set; } = false;

        /// <summary>
        /// String value specifying the Name attribute of the RadioButton.
        /// All radio buttons with the same Name attribute are considered part of a group.
        /// Only one radio button in a group can be selected.
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string Name { get; set; } = String.Empty;

        /// <summary>
        /// String value specifying the Value attribute of the Radio Button.
        /// The Value parameter is the data element of the radio button whereas the <see cref="Label" /> parameter is the displayed text element.
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string Value { get; set; } = String.Empty;



        // ==================================================
        // Event Callback Parameters
        // ==================================================

        /// <summary>
        /// An <see cref="EventCallback"/> containg the consumer's method invoked when the RadioButton state has been changed by user interaction.
        /// </summary>
        [Parameter]
        public EventCallback<ChangeArgs<TChecked>> ValueChange { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containg the consumer's method invoked when the Radio Button is created.
        /// </summary>
        [Parameter]
        public EventCallback<object> Created { get; set; }



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
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value for padding inside the wrapper surrounding the radio button.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Specify the padding in top, right, bottom, left order. Or use any of the padding shorhands.
        /// Default value is: 0px all sides.
        /// </summary>
        [Parameter]
        public string RadioButtonPadding { get; set; } = "0px";

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/margin">margin</see> value for marins surrounding the radio button (inside the surrounding wrapper).
        /// The margin CSS shorthand property sets the margin area on all four sides of an element.
        /// Specify the margin in top, right, bottom, left order. Or use any of the margin shorhands.
        /// Default value is: 0px on all sides.
        /// </summary>
        [Parameter]
        public string RadioButtonMargin { get; set; } = "0px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background-color</see> value used for the outer ring of the radio button in the checked state.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is #007BFF.
        /// </summary>
        [Parameter]
        public string CheckedOuterBackgroundColor { get; set; } = "#007BFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border">border</see> value set used for the outer ring of the radio button in the checked state.
        /// The border shorthand CSS property sets an element's border. It sets the values of border-width, border-style, and border-color.
        /// Default value is 1px solid #007BFF.
        /// </summary>
        [Parameter]
        public string CheckedOuterBorder { get; set; } = "1px solid #007BFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background-color</see> value used for the outer ring of the radio button in the unchecked state.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is #FFF.
        /// </summary>
        [Parameter]
        public string UncheckedOuterBackgroundColor { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border">border</see> value set used for the outer ring of the radio button in the unchecked state.
        /// The border shorthand CSS property sets an element's border. It sets the values of border-width, border-style, and border-color.
        /// Default value is 1px solid #ADB5BD.
        /// </summary>
        [Parameter]
        public string UncheckedOuterBorder { get; set; } = "1px solid #ADB5BD";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/height">height</see> value set used for the size of the outer ring of the radio button.
        /// The height CSS property specifies the height of an element. By default, the property defines the height of the content area.
        /// This parameter sets the CSS height and width styling since radio buttons are round.
        /// Default value is 14px.
        /// </summary>
        [Parameter]
        public string RadioButtonOuterSize { get; set; } = "14px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value for the label font color.
        /// The color CSS property sets the foreground color value of an element's text and text decorations, and sets the currentcolor value.
        /// Default value is #212529.
        /// </summary>
        [Parameter]
        public string LabelColor { get; set; } = "#212529";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value for the label.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 14px.
        /// </summary>
        [Parameter]
        public string LabelFontSize { get; set; } = "14px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight">font-weight</see> value for the label.
        /// The font-weight CSS property sets the weight (or boldness) of the font. The weights available depend on the font-family that is currently set.
        /// Default value is normal.
        /// </summary>
        [Parameter]
        public string LabelFontWeight { get; set; } = "normal";

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value for the label.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Specify the padding in top, right, bottom, left order. Or use any of the padding shorhands.
        /// Default value is: 0px 0px 0px 24px.
        /// </summary>
        [Parameter]
        public string LabelPadding { get; set; } = "0px 0px 0px 24px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background-color</see> value used for the radio button inner background color in the checked state.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is #FFF.
        /// </summary>
        [Parameter]
        public string CheckedInnerBackgroundColor { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value for the radio button inner color when in checked state..
        /// The color CSS property sets the foreground color value of an element's text and text decorations, and sets the currentcolor value.
        /// Default value is #FFF.
        /// </summary>
        [Parameter]
        public string CheckedInnerColor { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/height">height</see> value set used for the size of the inner portion of the radio button.
        /// The height CSS property specifies the height of an element. By default, the property defines the height of the content area.
        /// This parameter sets the CSS height and width styling since radio buttons are round.
        /// Default value is 6px.
        /// </summary>
        [Parameter]
        public string RadioButtonInnerSize { get; set; } = "6px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/top">top</see> value set used to position the inner portion of the radio button.
        /// The height CSS property specifies the height of an element. By default, the property defines the height of the content area.
        /// This parameter sets the CSS top and left styling since radio buttons are round and the inner portion is centered.
        /// Default value is 4px.
        /// </summary>
        [Parameter]
        public string RadioButtonInnerPosition { get; set; } = "4px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border">border</see> value set used for the border of the inner portion of the radio button.
        /// The border shorthand CSS property sets an element's border. It sets the values of border-width, border-style, and border-color.
        /// Default value is 1px solid currentcolor.
        /// </summary>
        [Parameter]
        public string RadioButtonInnerBorder { get; set; } = "1px solid currentcolor";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border">border</see> value set used for the border of the inner portion of the radio button.
        /// The border shorthand CSS property sets an element's border. It sets the values of border-width, border-style, and border-color.
        /// The box shadow color is usually the the same as <see cref="CheckedOuterBackgroundColor"/> with 25% oppacity applied.
        /// Default value is 0 0 0 3px rgba(0,123,255,0.25).
        /// </summary>
        [Parameter]
        public string RadioButtonFocusBoxShadow { get; set; } = "0 0 0 3px rgba(0,123,255,0.25)";


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

        private SfRadioButton<TChecked> sfRadioButton;          // SF Radio Button component
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

            // Build the master selector
            masterCssSelector = ((CssClass == String.Empty) ? ".e-radio-wrapper" : $".{ CssClass }.e-radio-wrapper");
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
        /// Sets the focus to SfRadioButton component for interaction.
        /// </summary>
        public async Task FocusAsync() => await this.sfRadioButton.FocusAsync();

        //public TChecked OnCheckedChanged()
        //{
        //    //return (TChecked)Value;
        //}

        #endregion



        #region Private Methods for Internal Use Only
        #endregion
    }
}

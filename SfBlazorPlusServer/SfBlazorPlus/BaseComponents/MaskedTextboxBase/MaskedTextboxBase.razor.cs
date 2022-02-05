using Code420.SfBlazorPlus.Code.CssUtilities;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Syncfusion.Blazor.Inputs;

namespace Code420.SfBlazorPlus.BaseComponents.MaskedTextboxBase
{
    public partial class MaskedTextboxBase : ComponentBase
    {

        #region Component Parameters

        // ==================================================
        // Base Parameters
        // ==================================================


        /// <summary>
        /// String value containing the contents of the Masked Textbox.
        /// </summary>
        [Parameter]
        public string Value { get; set; }

        /// <summary>
        /// Collection of values to be mapped for non-mask elements (literals) which  have been set in the mask of Masked TextBox. 
        /// This is a <see cref="Dictionary{TKey, TValue}"/> where TKey and TValue are <see cref="string"/>.
        /// </summary>
        [Parameter]
        public Dictionary<string, string> CustomCharacters { get; set; }

        /// <summary>
        /// Boolean value indicating if the Masked Textbox is enabled.
        /// Default value is true.
        /// </summary>
        [Parameter]
        public bool Enabled { get; set; } = true;

        /// <summary>
        /// Boolean value indicating if the Masked Textbox <see cref="Value"/> parameter is persisted between page reloads.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool EnablePersistence { get; set; } = false;

        /// <summary>
        /// A <see cref="Syncfusion.Blazor.Inputs.FloatLabelType"/> that specifies the floating label behavior of the Masked TextBox.
        /// Valid values are Never, Always and Auto (label floats above the textbox after focusing it or when enters the value in it).
        /// Default value is Auto.
        /// </summary>
        [Parameter]
        public FloatLabelType FloatLabelType { get; set; } = FloatLabelType.Auto;

        /// <summary>
        /// String value containing the mask based on the <see href="https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.maskedtextbox.mask">MSDN</see> standard to allow/validate the user input.
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string Mask { get; set; } = String.Empty;

        /// <summary>
        /// String value containing the text that is shown as a hint or placeholder until the user focuses or enter a value in the Masked Textbox. 
        /// Use of this property depends on the <see cref="FloatLabelType"/> property setting.
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string Placeholder { get; set; } = String.Empty;

        /// <summary>
        /// String value whose first character is used as the prompting symbol for the masked value.
        /// Default value is '_'.
        /// </summary>
        [Parameter]
        public string PromptCharacter { get; set; } = "_";

        /// <summary>
        /// Boolean value indicating if the Masked Textbox allows the user to change the text.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool ReadOnly { get; set; } = false;

        /// <summary>
        /// Boolean value indicating if the clear button is displayed in the Masked Textbox.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool ShowClearButton { get; set; } = false;

        /// <summary>
        /// Integer value specifying the tab order of the Masked Textbox relative to other HTML elements ob the page.
        /// </summary>
        [Parameter]
        public int TabIndex { get; set; }



        // ==================================================
        // Event Callback Parameters
        // ==================================================


        /// <summary>
        /// An <see cref="EventCallback"/> containng the consumer's method invoked when the textbox value changes and loses focus.
        /// </summary>
        [Parameter]
        public EventCallback<MaskChangeEventArgs> ValueChange { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containng the consumer's method invoked when the textbox value changes.
        /// </summary>
        [Parameter]
        public EventCallback<string> ValueChanged { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containg the consumer's method invoked when the Masked Textbox loses focus.
        /// </summary>
        [Parameter]
        public EventCallback<MaskBlurEventArgs> Blur { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containg the consumer's method invoked when the Masked Textbox is created.
        /// </summary>
        [Parameter]
        public EventCallback<object> Created { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containg the consumer's method invoked when the Masked Textbox is destroyed.
        /// </summary>
        [Parameter]
        public EventCallback<object> Destroyed { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containg the consumer's method invoked when the Masked Textbox gets focus.
        /// </summary>
        [Parameter]
        public EventCallback<MaskFocusEventArgs> Focus { get; set; }



        // ==================================================
        // CSS Styling Parameters
        // ==================================================


        /// <summary>
        /// String value containing CSS class definition(s) that will be injected in the root HTML div element of the Masked Textbox.
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string CssClass { get; set; } = String.Empty;

        /// <summary>
        /// String value that specifies the CSS ID assigned to the HTML input element  of the Masked Textbox. 
        /// The Id is also injected into the HTML label element when the <see cref="FloatLabelType"/> parameter is set to Always or Auto.
        /// The IOd is used by the and is used by the UpdatePlaceholderAsync() method.
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string CssId { get; set; } = String.Empty;

        /// <summary>
        /// Collection of additional HTML attributes such as styles, class, and more that are injected in root element. 
        /// If both property and equivalent HTML attribute are configured, the component considers the property value. 
        /// This is a <see cref="Dictionary{TKey, TValue}"/> where TKey is a <see cref="string"/> and TValue is an <see cref="object"/>.
        /// </summary>
        [Parameter]
        public Dictionary<string, object> HtmlAttributes { get; set; }

        /// <summary>
        /// Collection of additional input attributes such as disabled, value, and more that are injected in root element. 
        /// If both property and equivalent input attribute are configured, the component considers the property value. 
        /// This is a <see cref="Dictionary{TKey, TValue}"/> where TKey is a <see cref="string"/> and TValue is an <see cref="object"/>.
        /// </summary>
        [Parameter]
        public Dictionary<string, object> InputAttributes { get; set; }

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/width">width</see> value used for the textbox.
        /// The width CSS property sets an element's width.
        /// Default value is 200px.
        /// </summary>
        [Parameter]
        public string Width { get; set; } = "200px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/height">height</see> value used for the textbox.
        /// The height CSS property specifies the height of an element.
        /// Default value is 29px.
        /// </summary>
        [Parameter]
        public string Height { get; set; } = "29px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background</see> value used for the textbox.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is #FFF.
        /// </summary>
        [Parameter]
        public string TextboxBackgroundColor { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-color">border-color</see> value used for the textbox.
        /// The border-color shorthand CSS property sets the color of an element's border.
        /// Default value is black.
        /// </summary>
        [Parameter]
        public string TextboxBorderColor { get; set; } = "black";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-width">border-width</see> value used for the textbox.
        /// The border-width shorthand CSS property sets the width of an element's border.
        /// Default value is 1px.
        /// </summary>
        [Parameter]
        public string TextboxBorderWidth { get; set; } = "1px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius">border-radius</see> value used for the textbox.
        /// The border-radius CSS property rounds the corners of an element's outer border edge.
        /// Default value is 4px.
        /// </summary>
        [Parameter]
        public string TextboxBorderRadius { get; set; } = "4px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-color">border-color</see> value used for the textbox when active.
        /// The border-color shorthand CSS property sets the color of an element's border..
        /// Default value is #80BDFF.
        /// </summary>
        [Parameter]
        public string TextboxActiveBorderColor { get; set; } = "#80BDFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value used for the textbox font size.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 14px.
        /// </summary>
        [Parameter]
        public string TextboxFontSize { get; set; } = "14px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value used for the textbox font color.
        /// The color CSS property sets the foreground color value of an element's text and text decorations.
        /// Default value is #495057.
        /// </summary>
        [Parameter]
        public string TextboxFontColor { get; set; } = "#495057";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight">font-weigh</see> value used for the textbox font.
        /// The font-weight CSS property sets the weight (or boldness) of the font. The weights available depend on the font-family that is currently set.
        /// Default value is 400.
        /// </summary>
        [Parameter]
        public string TextboxFontWeight { get; set; } = "400";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/line-height">line-height</see> value used for the textbox line height.
        /// The line-height CSS property sets the height of a line box. It's commonly used to set the distance between lines of text.
        /// Default value is 1.4.
        /// </summary>
        [Parameter]
        public string TextboxLineHeight { get; set; } = "1.4";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/margin">margin</see> value used for the textbox margin.
        /// The margin CSS shorthand property sets the margin area on all four sides of an element
        /// Default value is 24px 0px 0px 0px.
        /// </summary>
        [Parameter]
        public string TextboxMargin { get; set; } = "24px 0px 0px 0px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding-top">padding-top</see> value used for the textbox padding.
        /// The padding-top CSS property sets the height of the padding area on the top of an element.
        /// Default value is 0px.
        /// </summary>
        [Parameter]
        public string TextboxPaddingTop { get; set; } = "0px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding-left">padding-left</see> value used for the textbox padding.
        /// The padding-left CSS property sets the width of the padding area to the left of an element.
        /// Default value is 8px.
        /// </summary>
        [Parameter]
        public string TextboxPaddingLeft { get; set; } = "8px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/text-indent">text-indent</see> value used for the textbox contents.
        /// The text-indent CSS property sets the length of empty space (indentation) that is put before lines of text in a block.
        /// Default value is 0px.
        /// </summary>
        [Parameter]
        public string TextboxTextIndent { get; set; } = "0px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value used for the textbox placeholder font.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 14px.
        /// </summary>
        [Parameter]
        public string PlaceholderFontSize { get; set; } = "14px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight">font-weigh</see> value used for the textbox placeholder font.
        /// The font-weight CSS property sets the weight (or boldness) of the font. The weights available depend on the font-family that is currently set.
        /// Default value is 400.
        /// </summary>
        [Parameter]
        public string PlaceholderFontWeight { get; set; } = "400";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value used for the textbox placeholder font its normal (non-floating) position.
        /// The color CSS property sets the foreground color value of an element's text and text decorations.
        /// Default value is #6C757D.
        /// </summary>
        [Parameter]
        public string PlaceholderNormalColor { get; set; } = "#6C757D";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value used for the textbox placeholder font in its floating position.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 14px.
        /// </summary>
        [Parameter]
        public string PlaceholderFloatingFontSize { get; set; } = "14px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight">font-weigh</see> value used for the textbox placeholder font in its floating position.
        /// The font-weight CSS property sets the weight (or boldness) of the font. The weights available depend on the font-family that is currently set.
        /// Default value is 400.
        /// </summary>
        [Parameter]
        public string PlaceholderFloatingFontWeight { get; set; } = "400";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value used for the textbox placeholder font its floating position.
        /// The color CSS property sets the foreground color value of an element's text and text decorations.
        /// Default value is #212529.
        /// </summary>
        [Parameter]
        public string PlaceholderFloatingColor { get; set; } = "#212529";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value used for the close button's <see cref="ShowClearButton"/> icon.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 12px.
        /// </summary>
        [Parameter]
        public string ClearButtonIconSize { get; set; } = "12px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value used for the close button's <see cref="ShowClearButton"/> icon..
        /// The color CSS property sets the foreground color value of an element's text and text decorations.
        /// Default value is rgba(0,0,0,0.5).
        /// </summary>
        [Parameter]
        public string ClearButtonIconColor { get; set; } = "rgba(0,0,0,0.5)";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background</see> value used for the close button's <see cref="ShowClearButton"/> icon.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is transparent.
        /// </summary>
        [Parameter]
        public string ClearButtonIconBackgroundColor { get; set; } = "transparent";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/min-width">min-width</see> value used for the close button's <see cref="ShowClearButton"/> icon.
        /// The min-width CSS property sets the minimum width of an element. It prevents the used value of the width property from becoming smaller than the value specified for min-width.
        /// Default value is 24px.
        /// </summary>
        [Parameter]
        public string ClearButtonMinimumWidth { get; set; } = "24px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value used for the close button padding.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Default value is 0px on all sides.
        /// </summary>
        [Parameter]
        public string ClearButtonPadding { get; set; } = "0px";

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

        private SfMaskedTextBox sfMaskedTextBox;                // SF Masked Textbox component
        private string masterDivSelector = String.Empty;        // The master selector for the HTML div element
        private string masterLabelSelector = String.Empty;      // The master selector for the HTML label element
        private string boxShadowRgba = String.Empty;            // The RGBA value when styling the box shadow used when the textbox is active

        #endregion


        #region Injected Dependencies

        // Injected Dependencies
        private IJSRuntime _jsRuntime;
        private ICssUtilities _cssUtilities;


        // Dependency Injection
        [Inject]
        IJSRuntime jsRuntime { get => _jsRuntime; set => _jsRuntime = value; }

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

            // Need to ensure PromptCharacter parameter is not zero-length.
            if (PromptCharacter.Length == 0) PromptCharacter = "_";

            // Build the master selector
            masterLabelSelector = ((CssId == String.Empty) ? "#label_" : $"#label_{ CssId }");
            masterDivSelector = ((CssClass == String.Empty) ? ".e-control-wrapper" : $".{ CssClass }.e-control-wrapper");

            // Pre-calculate the box-shadow RGBA values used when the textbox is active
            boxShadowRgba = await _cssUtilities.ConvertToRgba(TextboxActiveBorderColor, 0.25m);
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
        /// Disables the textbox.
        /// </summary>
        public void Disable()
        {
            this.Enabled = false;
            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Enables the textbox.
        /// </summary>
        public void Enable()
        {
            this.Enabled = true;
            InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Update the value of the Placeholder property. Uses to JS to find the
        /// label_CssId HTML Id element and sets its innerHTLM to the passed value.
        /// To ensure proper operation, ensure the CssId property is set to a unique value.
        /// </summary>
        /// <param name="value">The new Placeholder property value</param>
        public async Task UpdatePlaceholderAsync(string value)
        {
            string id = "label_" + this.sfMaskedTextBox.ID;
            await _jsRuntime.InvokeVoidAsync("Code420.setMaskedTextboxPlaceholder", id, value);
        }

        /// <summary>
        /// Sets the focus to SfMaskedTextBox component for interaction.
        /// </summary>
        public async Task FocusAsync() => await this.sfMaskedTextBox.FocusAsync();

        /// <summary>
        /// Remove the focus from SfMaskedTextBox component, if the component is in focus state.
        /// </summary>
        public async Task FocusOutAsync() => await this.sfMaskedTextBox.FocusOutAsync();

        /// <summary>
        /// Returns the value of MaskedTextBox with respective mask
        /// </summary>
        public string GetMaskedValue() => this.sfMaskedTextBox.GetMaskedValue();

        /// <summary>
        /// Gets the properties to be maintained in the persisted state
        /// </summary>
        public async void GetPersistDataAsync() => await this.sfMaskedTextBox.GetPersistDataAsync();


        #endregion


        #region Private Methods for Internal Use Only
        #endregion
    }
}

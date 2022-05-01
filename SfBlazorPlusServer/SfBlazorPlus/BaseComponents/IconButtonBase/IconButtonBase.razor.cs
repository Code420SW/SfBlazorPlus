using Code420.SfBlazorPlus.Code.CssUtilities;
using Code420.SfBlazorPlus.Code.Enums;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Buttons;

namespace Code420.SfBlazorPlus.BaseComponents.IconButtonBase
{
    public partial class IconButtonBase : ComponentBase
    {
        #region Component Parameters

        // ==================================================
        // Base Parameters
        // ==================================================


        /// <summary>
        /// Boolean value indicating if the button is disabled.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool IsDisabled { get; set; } = false;


        /// <summary>
        /// Boolean value indicating if the button has toggled states (e.g., active/inactive, play/pause).
        /// Makes the Button toggle, when set to true. When you click it, the state changes from normal to active or viceversa.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool IsToggle { get; set; } = false;


        /// <summary>
        /// Boolean value indicating if the button is a primary button. 
        /// This setting may override the styling associated with the <see cref="IconButtonStyle"/> property, depending on the button style. 
        /// This setting will also override any setting specified in the <see cref="ButtonNormalBackgroundColor"/>, <see cref="ButtonHoverBackgroundColor"/> or <see cref="ButtonActiveBackgroundColor"/> parameters.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool IsPrimary { get; set; } = false;


        /// <summary>
        /// Sets the position of the icon in the button.
        /// One of the settings in <see cref="Syncfusion.Blazor.Buttons.IconPosition" />. 
        /// The default value is Left.
        /// </summary>
        [Parameter]
        public IconPosition IconPosition { get; set; } = IconPosition.Left;


        /// <summary>
        /// Sets the type <see cref="Code420.CanXtracShared.Enums.IconButtonStyle" /> of the button. 
        /// The default value is Default.
        /// </summary>
        [Parameter]
        public IconButtonStyle IconButtonStyle { get; set; } = IconButtonStyle.Default;



        // ==================================================
        // Event Callback Parameters
        // ==================================================

        /// <summary>
        /// An <see cref="EventCallback"/> cast as an <see cref="Action"/> that encapsulated consumer's method invoked when the button is clicked.
        /// </summary>
        [Parameter]
        public Action OnClick { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containg the consumer's method invoked when the Icon Button is created.
        /// </summary>
        [Parameter]
        public EventCallback<object> Created { get; set; }



        // ==================================================
        // CSS Styling Parameters
        // ==================================================

        /// <summary>
        /// String value containing CSS class definition(s) that will be injected in the HTML. 
        /// Injecting a class will provide styling segregation when multiple icon buttons are on the same page.
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string CssClass { get; set; } = String.Empty;


        /// <summary>
        /// String value containing CSS icon definition(s) that will be injected in the span tag of the button's HTML.
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string IconCss { get; set; } = String.Empty;



        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value for the button icon.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 1em.
        /// </summary>
        [Parameter]
        public string IconFontSize { get; set; } = "1em";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value applied to the button icon.
        /// The color CSS property sets the foreground color value of an element's text and text decorations, and sets the currentcolor value.
        /// Default value is white.
        /// </summary>
        [Parameter]
        public string IconFontColor { get; set; } = "white";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/text-align">text-align</see> value applied to the button icon.
        /// The text-align CSS property sets the horizontal alignment of the content inside a block element or table-cell box.
        /// Default value is center.
        /// </summary>
        [Parameter]
        public string IconFontTextAlign { get; set; } = "center";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/vertical-align">vertical-align</see> value applied to the button icon.
        /// The vertical-align CSS property sets vertical alignment of an inline, inline-block or table-cell box.
        /// Default value is middle.
        /// </summary>
        [Parameter]
        public string IconFontVerticalAlign { get; set; } = "middle";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/line-height">line-height</see> value applied to the button icon.
        /// The line-height CSS property sets the height of a line box. It's commonly used to set the distance between lines of text. On block-level elements, it specifies the minimum height of line boxes within the element.
        /// Default value is 1.0.
        /// </summary>
        [Parameter]
        public string IconFontLineHeight { get; set; } = "1.0";



        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background-color</see> value for the button icon.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is String.Empty indicating the default color associated with the <see cref="IconButtonStyle"/> is used. 
        /// When the <see cref="IsPrimary"/> is set to true, it will override this parameter.
        /// </summary>
        [Parameter]
        public string ButtonNormalBackgroundColor { get; set; } = String.Empty;

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border">border</see> value used for the icon button in its normal and disabled state.
        /// The border shorthand CSS property sets an element's border. It sets the values of border-width, border-style, and border-color.
        /// Default value is 1px solid #000.
        /// </summary>
        [Parameter]
        public string ButtonNormalBorder { get; set; } = "1px solid #000";

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background-color</see> value for the button when hovered or has the focus.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is String.Empty indicating the color of the button when hovered/focused will the the complemetary color of <see cref="ButtonNormalBackgroundColor"/>.
        /// When the <see cref="IsPrimary"/> is set to true, it will override this parameter.
        /// </summary>
        [Parameter]
        public string ButtonHoverBackgroundColor { get; set; } = String.Empty;

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border">border</see> value used for the icon button in its hovered state.
        /// The border shorthand CSS property sets an element's border. It sets the values of border-width, border-style, and border-color.
        /// Default value is 1px solid #000.
        /// </summary>
        [Parameter]
        public string ButtonHoverBorder { get; set; } = "1px solid #000";

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background-color</see> value for the button when active.
        /// The background-color CSS property sets the background color of an element.
        /// Default value is String.Empty indicating the default color associated with the <see cref="IconButtonStyle"/> is used (a slightly brighter version of the normal or hover/focus color). 
        /// When the <see cref="IsPrimary"/> is set to true, it will override this parameter.
        /// </summary>
        [Parameter]
        public string ButtonActiveBackgroundColor { get; set; } = String.Empty;

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-color">border-color</see> value used for the icon button in its active state.
        /// The border-color shorthand CSS property sets the color of an element's border.
        /// Default value is #000.
        /// </summary>
        [Parameter]
        public string ButtonActiveBorderColor { get; set; } = "#000";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/opacity">opacity </see> value used for the icon button in its disabled state.
        /// The opacity CSS property sets the opacity of an element. Opacity is the degree to which content behind an element is hidden, and is the opposite of transparency.
        /// Default value is .65.
        /// </summary>
        [Parameter]
        public string ButtonDisabledOpacity { get; set; } = ".65";

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/height">height</see> value for the button.
        /// The height CSS property specifies the height of an element. By default, the property defines the height of the content area. If box-sizing is set to border-box, however, it instead determines the height of the border area.
        /// Default value is String.Empty indicating that the height will be calculated by the base class.
        /// </summary>
        [Parameter]
        public string ButtonHeight { get; set; } = String.Empty;

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/width">width</see> value for the button.
        /// The width CSS property sets an element's width. By default, it sets the width of the content area, but if box-sizing is set to border-box, it sets the width of the border area.
        /// Default value is String.Empty indicating that the width will be calculated by the base class.
        /// </summary>
        [Parameter]
        public string ButtonWidth { get; set; } = String.Empty;

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/transform">transform: scale()</see> value that the button will grow/shrink when hovered.
        /// The transform CSS property lets you rotate, scale, skew, or translate an element. It modifies the coordinate space of the CSS visual formatting model.
        /// Must be a positive value.
        /// Values greater than 1.0 cause the button to grow. 
        /// Values less than 1.0 cause the button to shrink.
        /// Default value is 1.0 indicating the button will not change size. 
        /// </summary>
        [Parameter]
        public decimal HoverScale { get; set; } = 1.0m;



        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/margin">margin</see> value used for the icon button.
        /// The margin CSS shorthand property sets the margin area on all four sides of an element.
        /// Specify the margin in top, right, bottom, left order. Or use any of the margin shorhands.
        /// Default value is: 0px on all sides.
        /// </summary>
        [Parameter]
        public string Margin { get; set; } = "0px";

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value used for the icon button.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Specify the padding in top, right, bottom, left order. Or use any of the padding shorhands.
        /// Default value is: 0px on all sides.
        /// </summary>
        [Parameter]
        public string Padding { get; set; } = "0px";

        #endregion



        #region Callback Events Invoked from Underlying Components

        /// <summary>
        /// An <see cref="EventCallback"/> cast as an <see cref="Action"/> that encapsulated
        /// consumer's method called when the button is clicked.
        /// </summary>
        public void Click() => OnClick.Invoke();

        #endregion



        #region Instance Variables

        private SfButton sfButton;
        private string masterCssSelector;
        private string boxShadowRgba = String.Empty;            // The RGBA value when styling the box shadow used when the icon button is active

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

            // Build the master selector
            masterCssSelector = ((CssClass == String.Empty) ? ".e-btn" : string.Format(".{0}.e-btn", CssClass));

            // Make sure the HoverScale parameter is non-negative
            if (HoverScale < 0.0m) HoverScale = 1.0m;

            // If IsPrimary is true, override all button color parameters
            if (IsPrimary)
            {
                ButtonNormalBackgroundColor = String.Empty;
                ButtonHoverBackgroundColor = String.Empty;
                ButtonActiveBackgroundColor = String.Empty;
            }

            // Pre-calculate the box-shadow RGBA values used when the button is active
            //boxShadowRgba = await _cssUtilities.ConvertToRgba(ButtonActiveBorderColor, 0.25m);
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

            if (!firstRender)
            {
                // Pre-calculate the box-shadow RGBA values used when the button is active
                boxShadowRgba = await _cssUtilities.ConvertToRgba(ButtonActiveBorderColor, 0.25m);
            }
        }

        #endregion



        #region Public Methods Providing Access to the Underlying Components to the Consumer

        /// <summary>
        /// Disables the button.
        /// </summary>
        public async Task DisableAsync()
        {
            this.IsDisabled = true;
            await InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Enables the button.
        /// </summary>
        public async Task EnableAsync()
        {
            this.IsDisabled = false;
            await InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Sets the focus to SfButton component for interaction.
        /// </summary>
        public async Task FocusAsync() => await this.sfButton.FocusAsync();

        #endregion



        #region Private Methods for Internal Use Only
        #endregion

    }
}

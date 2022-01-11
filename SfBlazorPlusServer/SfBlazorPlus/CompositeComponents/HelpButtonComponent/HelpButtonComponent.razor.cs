using Code420.SfBlazorPlus.BaseComponents.IconButtonBase;
using Code420.SfBlazorPlus.BaseComponents.ToolTipBase;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Popups;

namespace Code420.SfBlazorPlus.CompositeComponents.HelpButtonComponent
{
    /// <summary>
    /// Composite component consisting of an icon button and a tooltip.
    /// The help button is displayed in the parent container and when hovered,
    /// the tooltip is displayed.
    /// 
    /// The component can be used as-is but is typically uses by topic-specific
    /// Help System components.
    /// </summary>

    public partial class HelpButtonComponent : ComponentBase
    {

        #region Component Parameters

        // ==================================================
        // Base Parameters
        // ==================================================

        /// <summary>
        /// Boolean value indicating if the help button is disabled.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool HelpButtonDisabled { get; set; } = false;

        /// <summary>
        /// Boolean value indicating if the Tooltip is displayed in an open state until it is closed manually.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool IsSticky { get; set; } = false;

        /// <summary>
        /// Contains the <see cref="RenderFragment" /> composing the tooltip contents.
        /// This property will be used only if <see cref="Content"/> is not set.
        /// The default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment TooltipContent { get; set; }

        // ==================================================
        // Event Callback Parameters
        // ==================================================


        // ==================================================
        // CSS Styling Parameters
        // ==================================================

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/margin">margin</see> value used for the help button.
        /// The margin CSS shorthand property sets the margin area on all four sides of an element.
        /// Default value is: 0px on all sides.
        /// </summary>
        [Parameter]
        public string Margin { get; set; } = "0px";

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value used for the help button.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Default value is: 0px on all sides.
        /// </summary>
        [Parameter]
        public string Padding { get; set; } = "0px";

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
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value used for the tooltip content.
        /// The font-size CSS property sets the size of the font. Changing the font size also updates the sizes of the font size-relative <length> units, such as em, ex, and so forth.
        /// This becomes the base em unit (=1em) for the tooltip contents and can be used to size child elements prepotionally.
        /// Default value is 12px.
        /// </summary>
        [Parameter]
        public string ContentFontSize { get; set; } = "12px";

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value used for the tooltip content.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Specify the padding in top, right, bottom, left order.
        /// Default value is: 4px 8px 4px 8px.
        /// </summary>
        [Parameter]
        public string ContentPadding { get; set; } = "4px 8px 4px 8px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/filter">filter</see> value applied to the tooltip HTML element.
        /// The filter CSS property applies graphical effects like blur or color shift to an element. Filters are commonly used to adjust the rendering of images, backgrounds, and borders.
        /// Default value is none.
        /// </summary>
        [Parameter]
        public string TooltipFilter { get; set; } = "none";

        #endregion



        #region Callback Events Invoked from Underlying Components

        // ==================================================
        // Methods used as Callback Events from the underlying component(s)
        // ==================================================

        // Called by the help button's OnClick event.
        //  This isn't really needed since typically the HelpButtonDisabled
        //  parameter should be true AND the tooltip is displated on hover.
        //  The method is included just in case HelpButtonDisabled is true
        //  and the underlying IconButtonBase wants a callback.
        private async Task OnHelpButtonClickAsync()
        {
            await this.tooltipBase.OpenAsync();
        }


        #endregion



        #region Instance Variables

        // ==================================================
        // Instance variables
        // ==================================================

        // Base components used in this composite component
        private IconButtonBase helpIconButtonBase;          // Invocation button
        private ToolTipBase tooltipBase;                    // Tooltip


        // General variables


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

            // Get the current MetrcTagInputMode and MetrcTagInputLength from _metrcTagConfig
            // These are used by the dialog box switch and slider and will be saved back to
            // _metrcTagConfig when the Save button is clicked
            //metrcTagScanMode = (_metrcTagConfig.MetrcTagInputMode == MetrcTagInputMode.Scan);
            //currentKeyInValue = _metrcTagConfig.MetrcTagInputLength;
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

        #region Public Methods for the TooltipBase

        // ==================================================
        // Public Methods providing access to the underlying component to the consumer
        // ==================================================

        /// <summary>
        /// Used to hide the Tooltip with a specific animation effect.
        /// </summary>
        /// <param name="animation"><see cref="Syncfusion.Blazor.Popups.TooltipAnimationSettings"/> settings for tooltip close action</param>
        /// <returns></returns>
        public async Task CloseTooltipAsync(TooltipAnimationSettings animation = null)
        {
            await tooltipBase.CloseAsync(animation);
        }

        /// <summary>
        /// Used to show the Tooltip on the specified target with specific animation settings. 
        /// You can also pass the additional arguments like target element in which the tooltip should appear and animation settings for the tooltip open action.
        /// </summary>
        /// <param name="element">Target element in which the tooltip should appear.</param>
        /// <param name="animation"><see cref="Syncfusion.Blazor.Popups.AnimationModel"/> settings for the tooltip open action.</param>
        /// <returns></returns>
        public async Task OpenTooltipAsync(Nullable<ElementReference> element = null, TooltipAnimationSettings animation = null) =>
            await this.tooltipBase.OpenAsync(element, animation);

        /// <summary>
        /// Refresh the tooltip component when the target element is dynamically used.
        /// </summary>
        public async Task RefreshTooltipAsync() => await this.tooltipBase.RefreshAsync();

        /// <summary>
        /// Dynamically refreshes the tooltip element position based on the target element.
        /// </summary>
        /// <param name="target">The target element.</param>
        /// <returns></returns>
        public async Task RefreshTooltipPositionAsync(Nullable<ElementReference> target = null) => await this.tooltipBase.RefreshPositionAsync(target);

        #endregion


        #region Public Methods for IconButtonBase

        /// <summary>
        /// Set icon button state to enabled.
        /// </summary>
        /// <returns></returns>
        public async Task EnableIconButton() => await helpIconButtonBase.EnableAsync();

        /// <summary>
        /// Set icon button state to disabled.
        /// </summary>
        /// <returns></returns>
        public async Task DisableIconButton() => await helpIconButtonBase.DisableAsync();

        /// <summary>
        /// Set focus to the icon button.
        /// </summary>
        /// <returns></returns>
        public async Task FocusIconButton() => await helpIconButtonBase.FocusAsync();

        #endregion

        #endregion



        #region Private Methods for Internal Use Only

        // ==================================================
        // Private Methods 
        // ==================================================

        #endregion

    }
}

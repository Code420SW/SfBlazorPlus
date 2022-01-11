using Code420.SfBlazorPlus.Code.Enums;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor.Popups;
using DragEventArgs = Syncfusion.Blazor.Popups.DragEventArgs;

namespace Code420.SfBlazorPlus.BaseComponents.DialogBoxBase
{
    public partial class DialogBoxBase : ComponentBase
    {
        // TODO: May be able to improve the overlay functionality
        //          by using box-shadow with 100vh and 100vw
        //          https://www.youtube.com/watch?v=TZRSXNc0T1k

        // TODO: (LOW) Create a way to handle freeform PositionX/PositionY numeric values as a string

        #region Component Parameters

        // ==================================================
        // Base Parameters
        // ==================================================

        /// <summary>
        /// Boolean value specifying whether the dialog component can be dragged by the user. 
        /// The dialog allows a user to drag by selecting the header and dragging it for re-positioning the dialog.
        /// Default value is true.
        /// </summary>
        [Parameter]
        public bool AllowDragging { get; set; } = true;

        /// <summary>
        /// Boolean value specifying whether the Dialog element re-renders or not when the Dialog gets open.
        /// When disabled, the Dialog component DOM element will be destroyed when closing and re-rendered when the dialog DOM element is opened. 
        /// Otherwise, the dialog will be shown when opening it and remain hidden while closed.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool AllowPrerender { get; set; } = false;

        /// <summary>
        /// Specifies the type of animation effects used when opning and closing the dialog box.
        /// One of the types specified in <see cref="DialogEffect" />.
        /// Default value is FadeZoom.
        /// </summary>
        [Parameter]
        public DialogEffect AnimationEffect { get; set; } = DialogEffect.FadeZoom;

        /// <summary>
        /// Double value specifying the delay (in milliseconds) before the animation effect begins.
        /// Default value is 0ms.
        /// </summary>
        [Parameter]
        public double AnimationDelay { get; set; } = 0;

        /// <summary>
        /// Double value specifying the amount of time (in millisecond) in which the animation effect will take place.
        /// The default value is 400ms.
        /// </summary>
        [Parameter]
        public double AnimationDuration { get; set; } = 400;

        /// <summary>
        /// Contains the <see cref="RenderFragment" /> composing the content section of the dialog box.
        /// The default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment ContentFragment { get; set; } = null;

        /// <summary>
        /// Boolean value specifying if the dialog box is closed when the user presses the Escape key. 
        /// Default value is true.
        /// </summary>
        [Parameter]
        public bool CloseOnEscape { get; set; } = true;

        /// <summary>
        /// Boolean value specifying whether the dialog component can be resized by the end-user. 
        /// If true, the dialog component creates a grip to resize it in a diagonal direction.
        /// In addition, the borders specified in the <see cref="ResizeHandles"/> can be individually resized.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool EnableResize { get; set; } = false;

        /// <summary>
        /// Contains the <see cref="RenderFragment" /> composing the footer section of the dialog box. 
        /// The default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment FooterFragment { get; set; } = null;

        /// <summary>
        /// Contains the <see cref="RenderFragment" /> composing the footer section of the dialog box. 
        /// The default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment HeaderFragment { get; set; } = null;

        /// <summary>
        /// Collection of additional HTML attributes such as styles, class, and more that are injected in root dialog box HTML element. 
        /// If both property and equivalent HTML attribute are configured, the component considers the property value. 
        /// This is a <see cref="Dictionary{TKey, TValue}"/> where TKey is a <see cref="string"/> and TValue is an <see cref="object"/>.
        /// Default value is null.
        /// </summary>
        [Parameter]
        public Dictionary<string, object> HtmlAttributes { get; set; }

        /// <summary>
        /// Boolean value specifying whether the dialog can be displayed as modal or non-modal. 
        /// Modal: Creates an overlay that disables interaction with the parent application and the user must close the dialog before continuing with other applications. 
        /// Modeless: Does not prevent user interaction with the parent application.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool IsModal { get; set; } = false;

        /// <summary>
        /// Boolean value indicating if the dialog box's position is maintained when the user scrolls the main window.
        /// Has no effect if <see cref="IsModal"/> parameter is set to true.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool MaintainPositionOnScroll { get; set; } = false;

        /// <summary>
        /// Specifies the horizontal position of the dialog box. 
        /// Contains one of the values in <see cref="DialogBoxPositionPreset"/>.
        /// Valid values include: Left. Center and Right. 
        /// The default value is Center.
        /// </summary>
        [Parameter]
        public DialogBoxPositionPreset PositionX { get; set; } = DialogBoxPositionPreset.Center;


        /// <summary>
        /// Specifies the vertical position of the dialog box. 
        /// Contains one of the values in <see cref="DialogBoxPositionPreset"/>.
        /// Valid values include: Top, Center and Bottom. 
        /// The default value is Center.
        /// </summary>
        [Parameter]
        public DialogBoxPositionPreset PositionY { get; set; } = DialogBoxPositionPreset.Center;

        /// <summary>
        /// Specifies the available resize handles for the dialog box.
        /// Applicable when <see cref="EnableResize"/> parameter is set to true.
        /// The parameter contains one or more of of the values in <see cref="ResizeDirection"/>.
        /// The default value is All.
        /// </summary>
        [Parameter]
        public ResizeDirection[] ResizeHandles { get; set; }

        /// <summary>
        /// Boolean value indicating if the close (X) icon is shown in the upper right corner of header section in the dialog box.
        /// Default value is true.
        /// </summary>
        [Parameter]
        public bool ShowCloseIcon { get; set; } = true;

        /// <summary>
        /// String value containing the CSS Id of the dialog box's parent. 
        /// The target must exist on the page.
        /// The dialog box will be rendered completely within the HTML element associated with the CSS Id.
        /// The Taget parameter should be a proper CSS Id selector (e.g., #target-id).
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string Target { get; set; } = String.Empty;


        /// <summary>
        /// Boolean value indicating if the dialog box is displayed.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool Visible { get; set; } = false;



        // ==================================================
        // Event Callback Parameters
        // ==================================================

        /// <summary>
        /// An <see cref="EventCallback"/> method invoked when the dialog box is closed.
        /// </summary>
        [Parameter]
        public EventCallback<CloseEventArgs> Closed { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> method invoked when the dialog box is created.
        /// </summary>
        [Parameter]
        public EventCallback<object> Created { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> method invoked when the dialog box is destroyed.
        /// </summary>
        [Parameter]
        public EventCallback<object> Destroyed { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> method invoked when the dialog box is about to close.
        /// Event triggers before the dialog is closed. 
        /// If you cancel this event, the dialog remains opened.
        /// </summary>
        [Parameter]
        public EventCallback<BeforeCloseEventArgs> OnClose { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> method invoked whhen the user drags the dialog box.
        /// Event triggers when the user drags the dialog.
        /// </summary>
        [Parameter]
        public EventCallback<DragEventArgs> OnDrag { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> method invoked when the user starts draging the dialog box.
        /// Event triggers when the user begins dragging the dialog.
        /// </summary>
        [Parameter]
        public EventCallback<DragStartEventArgs> OnDragStart { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> method invoked when the user stops dragging the dialog box.
        /// Event triggers when the user stops dragging the dialog.
        /// </summary>
        [Parameter]
        public EventCallback<DragStopEventArgs> OnDragStop { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> method invoked when the dialog box is about to open.
        /// Event triggers when the dialog is being opened. 
        /// If you cancel this event, the dialog remains closed.
        /// </summary>
        [Parameter]
        public EventCallback<BeforeOpenEventArgs> OnOpen { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> method called when the dialog box's overlay is clicked.
        /// Event triggers when the overlay of the dialog is clicked.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnOverlayClick { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> method called when the dialog box's overlay is clicked.
        /// Event triggers when the overlay of the dialog is clicked.
        /// </summary>
        [Parameter]
        public EventCallback<OverlayModalClickEventArgs> OnOverlayModalClick { get; set; }


        /// <summary>
        /// An <see cref="EventCallback"/> method invoked when the user starts resizing the dialog box.
        /// Event triggers when the user begins to resize a dialog.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnResizeStart { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> method invoked when the user stops resizing the dialog box.
        /// Event triggers when the user stops to resize a dialog.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> OnResizeStop { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> method invoked when the dialog box is opened.
        /// Event triggers when a dialog is opened.
        /// </summary>
        [Parameter]
        public EventCallback<OpenEventArgs> Opened { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> method invoked when the user resizes the dialog.
        /// Event triggers when the user resizes the dialog.
        /// </summary>
        [Parameter]
        public EventCallback<MouseEventArgs> Resizing { get; set; }



        // ==================================================
        // CSS Styling Parameters
        // ==================================================

        // TODO: (MEDIUM) Add support for CSS max-height and min/max-width since the user may be allowed to resize the dialog box.

        /// <summary>
        /// String value containing the CSS ID that will be injected in the HTML.
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string CssId { get; set; } = String.Empty;

        /// <summary>
        /// String value containing CSS class definition(s) that will be injected in the HTML.
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string CssClass { get; set; } = String.Empty;

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/height">height</see> of the dialog box.
        /// The height CSS property specifies the height of an element.
        /// Default value is 300px.
        /// </summary>
        [Parameter]
        public string Height { get; set; } = "300px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/min-height">min-height</see> value of the dialog box.
        /// The min-height CSS property sets the minimum height of an element. It prevents the used value of the height property from becoming smaller than 
        /// the value specified for min-height.
        /// Default value is 100px.
        /// </summary>
        [Parameter]
        public string MinHeight { get; set; } = "100px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/width">width</see> of the dialog box.
        /// The width CSS property sets an element's width.
        /// Default value is 300px.
        /// </summary>
        [Parameter]
        public string Width { get; set; } = "300px";



        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background-color</see> value 
        /// used to render the overlay of the dialog box.
        /// The background-color CSS property sets the background color of an element.
        /// Applicable when the <see cref="IsModal"/> parameter is set to true. 
        /// The default value is slategray.
        /// </summary>
        [Parameter]
        public string OverlayBackgroundColor { get; set; } = "slategray";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/opacity">opacity</see> value of dialog box's overlay.
        /// The opacity CSS property sets the opacity of an element. Opacity is the degree to which content behind an element is hidden, and is the opposite of transparency.
        /// Applicable when the <see cref="IsModal"/> parameter is set to true.  
        /// The value must be between 0.0 and 1.0. 
        /// The default value is 0.6.
        /// </summary>
        [Parameter]
        public string OverlayOpacity { get; set; } = "0.6";



        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value used to render the close button in the header portion of the dialog box.
        /// The font-size CSS property sets the size of the font.
        /// It is recommended that pixel units are used since the parent element is not directly addressible so relative units (em) are not related to any addressible content style.
        /// The default value is 14px.
        /// </summary>
        [Parameter]
        public string CloseButtonFontSize { get; set; } = "14px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value used to render the close button in the header portion of the dialog box.
        /// The color CSS property sets the foreground color value of an element's text and text decorations, and sets the currentcolor value. 
        /// The default value is black.
        /// </summary>
        [Parameter]
        public string CloseButtonColor { get; set; } = "black";



        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value used to render the text in the the dialog box.
        /// Sets the base font size for the entire dialog box container which means that subordinate elements can use relative font sizes (e.g., em) for both the
        /// section font sizes (e.g., <see cref="HeaderFontSize"/> and <see cref="ContentFontSize"/>) as well as the 
        /// associated RenderFragments (e.g., <see cref="HeaderFragment"/>, <see cref="ContentFragment"/> and <see cref="FooterFragment"/>)
        /// The default value is 12px
        /// </summary>
        [Parameter]
        public string DialogBaseFontSize { get; set; } = "12px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border">border</see> value set used for the tooltip border.
        /// The border shorthand CSS property sets an element's border. It sets the values of border-width, border-style, and border-color.
        /// Default value is 1px solid #000.
        /// </summary>
        [Parameter]
        public string DialogBorder { get; set; } = "1px solid rgba(0, 0, 0, 0.2)";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius">border-radius</see> value used for the tooltip border radius.
        /// The border-radius CSS property rounds the corners of an element's outer border edge.
        /// Default value is 3px.
        /// </summary>
        [Parameter]
        public string DialogBorderRadius { get; set; } = "3px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/box-shadow">box-shadow</see> value used for the tooltip.
        /// The box-shadow CSS property adds shadow effects around an element's frame. 
        /// You can set multiple effects separated by commas. A box shadow is described by X and Y offsets relative to the element, blur and spread radius, and color.
        /// Default value is: 0 5px 15px rgba(0,0,0,0.5).
        /// </summary>
        [Parameter]
        public string DialogBoxShadow { get; set; } = "0 5px 15px rgba(0,0,0,0.5)";



        /// <summary>
        /// String value that specifies a CSS <see href= "https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value used to render the text in the header section of the dialog box.
        /// The color CSS property sets the foreground color value of an element's text and text decorations, and sets the currentcolor value.
        /// The default value is black.
        /// </summary>
        [Parameter]
        public string HeaderFontColor { get; set; } = "black";

        /// <summary>
        /// String value that specifies the CSS <see href= "https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value used to render the text in the the header section of the dialog box.
        /// Sets the base font size for the entire header section which means that subordinate elements can use relative font sizes (e.g., em) for the <see cref="HeaderFragment"/>.
        /// The default value is 1.25em (relative to the <see cref="DialogBaseFontSize"/> parameter)
        /// </summary>
        [Parameter]
        public string HeaderFontSize { get; set; } = "1.25em";

        /// <summary>
        /// String value that specifies the CSS <see href= "https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight">font-weight</see> value used to render the text in the header section of the dialog box.
        /// The font-weight CSS property sets the weight (or boldness) of the font. The weights available depend on the font-family that is currently set.
        /// The default value is normal
        /// </summary>
        [Parameter]
        public string HeaderFontWeight { get; set; } = "normal";

        /// <summary>
        /// String value that specifies the CSS <see href= "https://developer.mozilla.org/en-US/docs/Web/CSS/line-height">line-height</see> value applied to the header section of the dialog box.
        /// The line-height CSS property sets the height of a line box. It's commonly used to set the distance between lines of text.
        /// The default value is normal.
        /// </summary>
        [Parameter]
        public string HeaderLineHeight { get; set; } = "normal";

        /// <summary>
        /// String value that specifies a CSS <see href= "https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background-color</see> value used to render the background in the header section of the dialog box.
        /// The background-color CSS property sets the background color of an element.
        /// The default value is transparent.
        /// </summary>
        [Parameter]
        public string HeaderBackgroundColor { get; set; } = "transparent";

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value used for the dialog header.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Specify the padding in top, right, bottom, left order.
        /// Default value is: 14px.
        /// </summary>
        [Parameter]
        public string HeaderPadding { get; set; } = "14px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom">border-bottom</see> value set used for the border below the header section.
        /// The border-bottom shorthand CSS property sets an element's bottom border. It sets the values of border-bottom-width, border-bottom-style and border-bottom-color.
        /// Default value is 1px solid #E9ECEF.
        /// </summary>
        [Parameter]
        public string HeaderBottomBorder { get; set; } = "1px solid #E9ECEF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius">border-radius</see> value used for the header border radius.
        /// The border-radius CSS property rounds the corners of an element's outer border edge.
        /// Default value is 3px 3px 0px 0px.
        /// </summary>
        [Parameter]
        public string HeaderBorderRadius { get; set; } = "3px 3px 0px 0px";



        /// <summary>
        /// String value that specifies a CSS <see href= "https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value used to render the text in the content section of the dialog box.
        /// The color CSS property sets the foreground color value of an element's text and text decorations, and sets the currentcolor value.
        /// The default value is black.
        /// </summary>
        [Parameter]
        public string ContentFontColor { get; set; } = "black";

        /// <summary>
        /// String value that specifies the CSS <see href= "https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value used to render the text in the the content section of the dialog box.
        /// Sets the base font size for the entire content section which means that subordinate elements can use relative font sizes (e.g., em) for the <see cref="ContentFragment"/>.
        /// The default value is 1em (relative to the <see cref="DialogBaseFontSize"/> parameter)
        /// </summary>
        [Parameter]
        public string ContentFontSize { get; set; } = "1em";

        /// <summary>
        /// String value that specifies the CSS <see href= "https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight">font-weight</see> value used to render the text in the content section of the dialog box.
        /// The font-weight CSS property sets the weight (or boldness) of the font. The weights available depend on the font-family that is currently set.
        /// The default value is normal
        /// </summary>
        [Parameter]
        public string ContentFontWeight { get; set; } = "normal";

        /// <summary>
        /// String value that specifies the CSS <see href= "https://developer.mozilla.org/en-US/docs/Web/CSS/line-height">line-height</see> value applied to the content section of the dialog box.
        /// The line-height CSS property sets the height of a line box. It's commonly used to set the distance between lines of text.
        /// The default value is normal.
        /// </summary>
        [Parameter]
        public string ContentLineHeight { get; set; } = "normal";

        /// <summary>
        /// String value that specifies a CSS <see href= "https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background-color</see> value used to render the background in the content section of the dialog box.
        /// The background-color CSS property sets the background color of an element.
        /// The default value is transparent.
        /// </summary>
        [Parameter]
        public string ContentBackgroundColor { get; set; } = "transparent";

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value used for the dialog content.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Specify the padding in top, right, bottom, left order.
        /// Default value is: 14px.
        /// </summary>
        [Parameter]
        public string ContentPadding { get; set; } = "14px";



        /// <summary>
        /// String value that specifies a CSS <see href= "https://developer.mozilla.org/en-US/docs/Web/CSS/background-color">background-color</see> value used to render the background in the footer portion of the dialog box.
        /// The background-color CSS property sets the background color of an element.
        /// The default value is transparent.
        /// </summary>
        [Parameter]
        public string FooterBackgroundColor { get; set; } = "transparent";

        /// <summary>
        /// String containing the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value used for the dialog footer.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Specify the padding in top, right, bottom, left order.
        /// Default value is: 14px.
        /// </summary>
        [Parameter]
        public string FooterPadding { get; set; } = "14px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-top">border=top</see> value set used for the 
        /// border above the footer section.
        /// The border shorthand CSS property sets an element's border. It sets the values of border-width, border-style, and border-color.
        /// Default value is 1px solid #E9ECEF.
        /// </summary>
        [Parameter]
        public string FooterTopBorder { get; set; } = "1px solid #E9ECEF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius">border-radius</see> value used for the footer section border radius.
        /// The border-radius CSS property rounds the corners of an element's outer border edge.
        /// Default value is 0px 0px 3px 3px.
        /// </summary>
        [Parameter]
        public string FooterBorderRadius { get; set; } = "0px 0px 3px 3px";

        #endregion



        #region Callback Events from Underlying Components

        // ==================================================
        // Methods used as Callback Events from the underlying component(s)
        // ==================================================

        #endregion



        #region Instance Variables

        // ==================================================
        // Instance variables
        // ==================================================

        private SfDialog sfDialog;                  // SF Dialog component
        private string masterCssSelector;           // The master selector for the HTML div element
        private string dialogPositionValue;         // Contains the CSS position for the dialog box based on MaintainPositionOnScroll parameter

        #endregion



        #region Injected Dependencies

        // Injected Dependencies



        // Dependency Injection


        #endregion



        #region Constructors

        //
        // Constructors
        //

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

            // Perform error-checking on OverlayOpacity
            if (double.TryParse(this.OverlayOpacity, out double temp) == false)
            {
                this.OverlayOpacity = "0.6";
            }
            else if (temp < 0.0 || temp > 1.0)
            {
                this.OverlayOpacity = "0.6";
            }

            // Build the master selector
            masterCssSelector = (CssClass == String.Empty) ? ".e-dialog" : $".{ CssClass }.e-dialog";

            // Set the dialog position value
            dialogPositionValue = (MaintainPositionOnScroll ? "fixed" : "absolute");

            // Set the default value for the ResizeHandles parameter
            if (ResizeHandles is null) ResizeHandles = new ResizeDirection[] { ResizeDirection.All };
        }

        // Once the state from the ParameterCollection has been assigned to the component’s
        //  [Parameter] properties, these methods are executed. This is useful in the same way
        //  as SetParametersAsync, except it is possible to use the component’s state.
        // This method is only executed once when the component is first created.If the parent
        //  changes the component’s parameters at a later time, this method is skipped.
        // When the component is a @page, and our Blazor app navigates to a new URL that renders
        //  the same page, Blazor will reuse the current object instance for that page.Because the
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
        /// Sets the visibility of the dialog box <see cref="Visible"/>.
        /// </summary>
        /// <param name="value">Boolean value indicating the visibility.</param>
        public async Task SetVisibilityAsync(bool value)
        {
            this.Visible = value;
            await InvokeAsync(StateHasChanged);
        }

        /// <summary>
        /// Opens the dialog if it is in a hidden state.
        /// </summary>
        /// <param name="isFullScreen">To open the dialog with full-screen width, set the parameter as true.</param>
        public async Task ShowAsync(Nullable<bool> isFullScreen = null) => await this.sfDialog.ShowAsync(isFullScreen);

        /// <summary>
        /// Used to hide the Dialog Box.
        /// </summary>
        public async Task HideAsync() => await this.sfDialog.HideAsync();

        /// <summary>
        /// Refreshes the dialog's position when the user changes its height and width dynamically.
        /// </summary>
        public async Task RefreshPositionAsync() => await this.sfDialog.RefreshPositionAsync();

        /// <summary>
        /// Refreshes the dialog's position when the user changes its height and width dynamically.
        /// </summary>
        /// <returns><see cref="DialogDimension"/> object containg the width and hight of the dialog box</returns>
        public async Task<DialogDimension> GetDimensionAsync() => await this.sfDialog.GetDimension();

        #endregion



        #region Private Methods for Internal Use Only
        #endregion
    }
}

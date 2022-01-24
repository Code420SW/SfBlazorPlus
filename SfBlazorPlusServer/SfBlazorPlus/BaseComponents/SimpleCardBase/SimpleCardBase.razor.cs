using Microsoft.AspNetCore.Components;

namespace Code420.SfBlazorPlus.BaseComponents.SimpleCardBase
{
    //
    // The component provides a simple card consisting of a container that encapsulates 
    // header, body and footer elements. The header and footer elements are flexboxes.
    // Any element whose renfer fragment is not defined by the consumer will be omitted
    // from the DOM.
    //

    public partial class SimpleCardBase : ComponentBase
    {

        #region Component Parameters

        // ==================================================
        // Base Parameters
        // ==================================================

        /// <summary>
        /// Contains the <see cref="RenderFragment" /> composing the body section of the Card.
        /// The default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment BodyContent { get; set; } = null;

        /// <summary>
        /// Contains the <see cref="RenderFragment" /> composing the header section of the Card.
        /// The default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment HeaderContent { get; set; } = null;

        /// <summary>
        /// Contains the <see cref="RenderFragment" /> composing the footer section of the Card.
        /// The default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment FooterContent { get; set; } = null;


        // ==================================================
        // Event Callback Parameters
        // ==================================================


        // ==================================================
        // CSS Styling Parameters
        // ==================================================

        /// <summary>
        /// String value containing CSS class definition(s) that will be injected in
        /// the root HTML ?????? element of the Card.
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string CssClass { get; set; } = String.Empty;

        /// <summary>
        /// String value that specifies the CSS ID assigned to the HTML ??????? element
        /// of the Card.
        /// Default value is String.Empty.
        /// </summary>
        [Parameter]
        public string CssId { get; set; } = String.Empty;

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value used for the Card font size.
        /// The font-size CSS property sets the size of the font.
        /// This is the base font size for the entire card (=1em). Relative font sizes for child components are based on this font size.
        /// Default value is 15px.
        /// </summary>
        [Parameter]
        public string CardFontSize { get; set; } = "15px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value used for the Card font color.
        /// The color CSS property sets the foreground color value of an element's text and text decorations.
        /// Default value is #212529.
        /// </summary>
        [Parameter]
        public string CardFontColor { get; set; } = "#212529";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/line-height">line-height</see> value used for the Card line height.
        /// The line-height CSS property sets the height of a line box. It's commonly used to set the distance between lines of text.
        /// Default value is 36px.
        /// </summary>
        [Parameter]
        public string CardLineHeight { get; set; } = "36px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/height">height</see> value used for the Card.
        /// The height CSS property specifies the height of an element.
        /// Default value is auto.
        /// </summary>
        [Parameter]
        public string CardHeight { get; set; } = "auto";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/width">width</see> value used for the Card.
        /// The width CSS property sets an element's width.
        /// Default value is 300px.
        /// </summary>
        [Parameter]
        public string CardWidth { get; set; } = "300px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/min-height">min-height</see> value used for the Card.
        /// The min-height CSS property sets the minimum height of an element.
        /// Default value is 36px.
        /// </summary>
        [Parameter]
        public string CardMinimumHeight { get; set; } = "36px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background">background</see> value used for the Card.
        /// The background shorthand CSS property sets all background style properties at once, such as color, image, origin and size, or repeat method.
        /// Default value is #FFF (background-color).
        /// </summary>
        [Parameter]
        public string CardBackground { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border">border</see> value used for the Card.
        /// The border shorthand CSS property sets an element's border. It sets the values of border-width, border-style, and border-color.
        /// Default value is 1px solid rgba(0,0,0,0.12).
        /// </summary>
        [Parameter]
        public string CardBorder { get; set; } = "1px solid rgba(0,0,0,0.12)";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-radius">border-radius</see> value used for the Card.
        /// The border-radius CSS property rounds the corners of an element's outer border edge.
        /// Default value is 4px.
        /// </summary>
        [Parameter]
        public string CardBorderRadius { get; set; } = "4px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/box-shadow">box-shadow</see> value used for the Card.
        /// The box-shadow CSS property adds shadow effects around an element's frame.
        /// Default value is none.
        /// </summary>
        [Parameter]
        public string CardBoxShadow { get; set; } = "none";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/outline">outline</see> value used for the Card.
        /// The outline CSS shorthand property set all the outline properties in a single declaration.
        /// Default value is none.
        /// </summary>
        [Parameter]
        public string CardOutline { get; set; } = "none";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/margin">margin</see> value used for the Card margin.
        /// The margin CSS shorthand property sets the margin area on all four sides of an element
        /// Default value is 0px.
        /// </summary>
        [Parameter]
        public string CardMargin { get; set; } = "0px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value used for the Card padding.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Default value is 0px.
        /// </summary>
        [Parameter]
        public string CardPadding { get; set; } = "0px";



        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/width">width</see> value used for the Card header.
        /// The width CSS property sets an element's width.
        /// Default value is 100% (= CardWidth).
        /// </summary>
        [Parameter]
        public string HeaderWidth { get; set; } = "100%";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/min-height">min-height</see> value used for the Card header.
        /// The min-height CSS property sets the minimum height of an element.
        /// Default value is 24px.
        /// </summary>
        [Parameter]
        public string HeaderMinimumHeight { get; set; } = "24px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/flex-direction">flex-direction</see> value used for the Card header.
        /// The flex-direction CSS property sets how flex items are placed in the flex container defining the main axis and the direction (normal or reversed).
        /// Default value is row.
        /// </summary>
        [Parameter]
        public string HeaderFlexDirection { get; set; } = "row";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/justify-content">justify-content</see> value used for the Card header.
        /// The CSS justify-content property defines how the browser distributes space between and around content items along the main-axis of a flex container.
        /// Default value is center.
        /// </summary>
        [Parameter]
        public string HeaderJustifyContent { get; set; } = "center";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/align-content">align-content</see> value used for the Card header.
        /// The CSS align-content property sets the distribution of space between and around content items along a flexbox's cross-axis.
        /// Default value is center.
        /// </summary>
        [Parameter]
        public string HeaderAlignContent { get; set; } = "center";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value used for the Header content.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 1em.
        /// </summary>
        [Parameter]
        public string HeaderFontSize { get; set; } = "1em";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight">font-weigh</see> value used for the Header content.
        /// The font-weight CSS property sets the weight (or boldness) of the font. The weights available depend on the font-family that is currently set.
        /// Default value is normal.
        /// </summary>
        [Parameter]
        public string HeaderFontWeight { get; set; } = "normal";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value used for the Header content.
        /// The color CSS property sets the foreground color value of an element's text and text decorations.
        /// Default value is #212529.
        /// </summary>
        [Parameter]
        public string HeaderFontColor { get; set; } = "#212529";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/line-height">line-height</see> value used for the Card header line height.
        /// The line-height CSS property sets the height of a line box. It's commonly used to set the distance between lines of text.
        /// Default value is normal.
        /// </summary>
        [Parameter]
        public string HeaderLineHeight { get; set; } = "normal";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/overflow">overflow</see> value used for the Header content.
        /// The overflow CSS shorthand property sets the desired behavior for an element's overflow — i.e. when an element's content is too big to fit in its block formatting context — in both directions.
        /// Default value is auto.
        /// </summary>
        [Parameter]
        public string HeaderOverflow { get; set; } = "auto";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/text-overflow">text-overflow</see> value used for the Header content.
        /// The text-overflow CSS property sets how hidden overflow content is signaled to users. It can be clipped, display an ellipsis ('…'), or display a custom string.
        /// Default value is ellipsis.
        /// </summary>
        [Parameter]
        public string HeaderTextOverflow { get; set; } = "ellipsis";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/white-space">white-space</see> value used for the Header content.
        /// The white-space CSS property sets how white space inside an element is handled.
        /// Default value is normal.
        /// </summary>
        [Parameter]
        public string HeaderWhiteSpace { get; set; } = "normal";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background">background</see> value used for the Header.
        /// The background shorthand CSS property sets all background style properties at once, such as color, image, origin and size, or repeat method.
        /// Default value is #FFF (background-color).
        /// </summary>
        [Parameter]
        public string HeaderBackground { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value used for the Card header padding.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Default value is normal.
        /// </summary>
        [Parameter]
        public string HeaderPadding { get; set; } = "16px";



        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-bottom">border-bottom</see> value used for the Card header separator.
        /// The border-bottom shorthand CSS property sets an element's bottom border. It sets the values of border-bottom-width, border-bottom-style and border-bottom-color.
        /// Default value is 1px solid rgba(0,0,0,0.12).
        /// </summary>
        [Parameter]
        public string HeaderSeparatorBottomBorder { get; set; } = "1px solid rgba(0,0,0,0.12)";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding-bottom">padding-bottom</see> value used for the Card header separator.
        /// The padding-bottom CSS property sets the height of the padding area on the bottom of an element.
        /// Default value is 0px.
        /// </summary>
        [Parameter]
        public string HeaderSeparatorBottomPadding { get; set; } = "0px";



        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/width">width</see> value used for the Card content.
        /// The width CSS property sets an element's width.
        /// Default value is 100% (= CardWidth).
        /// </summary>
        [Parameter]
        public string ContentWidth { get; set; } = "100%";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/min-height">min-height</see> value used for the Card content.
        /// The min-height CSS property sets the minimum height of an element.
        /// Default value is 24px.
        /// </summary>
        [Parameter]
        public string ContentMinimumHeight { get; set; } = "24px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/border-top">border-top</see> value used for the Card footer separator.
        /// The border-top shorthand CSS property sets an element's top border. It sets the values of border-top-width, border-top-style and border-top-color.
        /// Default value is 1px solid rgba(0,0,0,0.12).
        /// </summary>
        [Parameter]
        public string FooterSeparatorTopBorder { get; set; } = "1px solid rgba(0,0,0,0.12)";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding-bottom">padding-bottom</see> value used for the Card footer separator.
        /// The padding-bottom CSS property sets the height of the padding area on the bottom of an element.
        /// Default value is 0px.
        /// </summary>
        [Parameter]
        public string FooterSeparatorTopPadding { get; set; } = "0px";



        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value used for the Card content.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 1em.
        /// </summary>
        [Parameter]
        public string ContentFontSize { get; set; } = "1em";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight">font-weigh</see> value used for the Card content.
        /// The font-weight CSS property sets the weight (or boldness) of the font. The weights available depend on the font-family that is currently set.
        /// Default value is normal.
        /// </summary>
        [Parameter]
        public string ContentFontWeight { get; set; } = "normal";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value used for the Card content.
        /// The color CSS property sets the foreground color value of an element's text and text decorations.
        /// Default value is #212529.
        /// </summary>
        [Parameter]
        public string ContentFontColor { get; set; } = "#212529";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/line-height">line-height</see> value used for the Card content.
        /// The line-height CSS property sets the height of a line box. It's commonly used to set the distance between lines of text.
        /// Default value is normal.
        /// </summary>
        [Parameter]
        public string ContentLineHeight { get; set; } = "normal";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/overflow">overflow</see> value used for the Card content.
        /// The overflow CSS shorthand property sets the desired behavior for an element's overflow — i.e. when an element's content is too big to fit in its block formatting context — in both directions.
        /// Default value is auto.
        /// </summary>
        [Parameter]
        public string ContentOverflow { get; set; } = "auto";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/text-overflow">text-overflow</see> value used for the Card content.
        /// The text-overflow CSS property sets how hidden overflow content is signaled to users. It can be clipped, display an ellipsis ('…'), or display a custom string.
        /// Default value is ellipsis.
        /// </summary>
        [Parameter]
        public string ContentTextOverflow { get; set; } = "ellipsis";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/white-space">white-space</see> value used for the Card content.
        /// The white-space CSS property sets how white space inside an element is handled.
        /// Default value is normal.
        /// </summary>
        [Parameter]
        public string ContentWhiteSpace { get; set; } = "normal";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background">background</see> value used for the Content.
        /// The background shorthand CSS property sets all background style properties at once, such as color, image, origin and size, or repeat method.
        /// Default value is #FFF (background-color).
        /// </summary>
        [Parameter]
        public string ContentBackground { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value used for the Card content.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Default value is 16px.
        /// </summary>
        [Parameter]
        public string ContentPadding { get; set; } = "16px";



        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/width">width</see> value used for the Card footer.
        /// The width CSS property sets an element's width.
        /// Default value is 100% (= CardWidth).
        /// </summary>
        [Parameter]
        public string FooterWidth { get; set; } = "100%";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/min-height">min-height</see> value used for the Card footer.
        /// The min-height CSS property sets the minimum height of an element.
        /// Default value is 24px.
        /// </summary>
        [Parameter]
        public string FooterMinimumHeight { get; set; } = "24px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/flex-direction">flex-direction</see> value used for the Card footer.
        /// The flex-direction CSS property sets how flex items are placed in the flex container defining the main axis and the direction (normal or reversed).
        /// Default value is row.
        /// </summary>
        [Parameter]
        public string FooterFlexDirection { get; set; } = "row";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/justify-content">justify-content</see> value used for the Card footer.
        /// The CSS justify-content property defines how the browser distributes space between and around content items along the main-axis of a flex container.
        /// Default value is center.
        /// </summary>
        [Parameter]
        public string FooterJustifyContent { get; set; } = "center";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/align-content">align-content</see> value used for the Card footer.
        /// The CSS align-content property sets the distribution of space between and around content items along a flexbox's cross-axis.
        /// Default value is center.
        /// </summary>
        [Parameter]
        public string FooterAlignContent { get; set; } = "center";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value used for the Card footer.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 1em.
        /// </summary>
        [Parameter]
        public string FooterFontSize { get; set; } = "1em";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-weight">font-weigh</see> value used for the footer content.
        /// The font-weight CSS property sets the weight (or boldness) of the font. The weights available depend on the font-family that is currently set.
        /// Default value is normal.
        /// </summary>
        [Parameter]
        public string FooterFontWeight { get; set; } = "normal";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/color">color</see> value used for the footer content.
        /// The color CSS property sets the foreground color value of an element's text and text decorations.
        /// Default value is #212529.
        /// </summary>
        [Parameter]
        public string FooterFontColor { get; set; } = "#212529";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/line-height">line-height</see> value used for the Card footer line height.
        /// The line-height CSS property sets the height of a line box. It's commonly used to set the distance between lines of text.
        /// Default value is normal.
        /// </summary>
        [Parameter]
        public string FooterLineHeight { get; set; } = "normal";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/overflow">overflow</see> value used for the Footer content.
        /// The overflow CSS shorthand property sets the desired behavior for an element's overflow — i.e. when an element's content is too big to fit in its block formatting context — in both directions.
        /// Default value is auto.
        /// </summary>
        [Parameter]
        public string FooterOverflow { get; set; } = "auto";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/text-overflow">text-overflow</see> value used for the Footer content.
        /// The text-overflow CSS property sets how hidden overflow content is signaled to users. It can be clipped, display an ellipsis ('…'), or display a custom string.
        /// Default value is ellipsis.
        /// </summary>
        [Parameter]
        public string FooterTextOverflow { get; set; } = "ellipsis";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/white-space">white-space</see> value used for the Footer content.
        /// The white-space CSS property sets how white space inside an element is handled.
        /// Default value is normal.
        /// </summary>
        [Parameter]
        public string FooterWhiteSpace { get; set; } = "normal";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/background">background</see> value used for the Footer.
        /// The background shorthand CSS property sets all background style properties at once, such as color, image, origin and size, or repeat method.
        /// Default value is #FFF (background-color).
        /// </summary>
        [Parameter]
        public string FooterBackground { get; set; } = "#FFF";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/padding">padding</see> value used for the Card footer.
        /// The padding CSS shorthand property sets the padding area on all four sides of an element at once.
        /// Default value is normal.
        /// </summary>
        [Parameter]
        public string FooterPadding { get; set; } = "0px";

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
        private bool includeHeader = true;
        private bool includeFooter = true;
        private bool includeBody = true;

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

            // Build the master selector
            masterCssSelector = ((CssClass == String.Empty) ? ".card" : $".{ CssClass }.card");

            // Determine if the header section should be excluded
            includeHeader = (HeaderContent is not null);

            // Determine if the content section should be excluded
            includeBody = (BodyContent is not null);

            // Determine if the footer section should be excluded
            includeFooter = (FooterContent is not null);

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





        #endregion


        #region Private Methods for Internal Use Only
        #endregion
    }
}

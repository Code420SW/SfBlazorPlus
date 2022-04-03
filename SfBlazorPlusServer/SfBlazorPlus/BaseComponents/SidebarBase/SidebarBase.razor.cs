using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Navigations;
using System.Diagnostics;
using ChangeEventArgs = Syncfusion.Blazor.Navigations.ChangeEventArgs;
using EventArgs = Syncfusion.Blazor.Navigations.EventArgs;

namespace Code420.SfBlazorPlus.BaseComponents.SidebarBase
{
    public partial class SidebarBase : ComponentBase
    {

        #region Component Parameters

        #region Base Parameters

        // ==================================================
        // Base Parameters
        // ==================================================

        /// <summary>
        /// Boolean value specifying if animation transitions on expanding or collapsing the Sidebar are enabled.
        /// Default value is true.
        /// </summary>
        [Parameter]
        public bool Animate { get; set; } = true;

        /// <summary>
        /// Contains the <see cref="RenderFragment" /> composing the Sidebar contents.
        /// The default value is null.
        /// </summary>
        [Parameter]
        public RenderFragment ChildContent { get; set; } = null;

        /// <summary>
        /// Boolean value specifying if the Sidebar is closed when the document area is clicked.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool CloseOnDocumentClick { get; set; } = false;

        /// <summary>
        /// Boolean value specifying the docking state of the Sidebar.
        /// Default value is true.
        /// </summary>
        [Parameter]
        public bool EnableDock { get; set; } = true;

        /// <summary>
        /// Boolean value specifying if swiping gestures to expand/collapse the Sidebar on touch devices are enabled.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool EnableGestures { get; set; } = false;

        /// <summary>
        /// Boolean value specifying if the Sidebar's opened/closed state is persisted between page reloads.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool EnablePersistence { get; set; } = false;

        /// <summary>
        /// Boolean value specifying if the Sidebar is open or closed.
        ///  When the Sidebar type is set to Auto, the component will be expanded in the desktop and collapsed in the mobile mode regardless of the IsOpen property.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool IsOpen { get; set; } = false;

        /// <summary>
        /// One of the <see cref="SidebarPosition"/> values specifying the position of the Sidebar.
        /// Default value is Left.
        /// </summary>
        [Parameter]
        public SidebarPosition Position { get; set; } = SidebarPosition.Left;

        /// <summary>
        /// Boolean value specifying whether to apply overlay options to the main content when the Sidebar is open.
        /// Default value is false.
        /// </summary>
        [Parameter]
        public bool ShowBackdrop { get; set; } = false;

        /// <summary>
        /// String value specifying the CSS class whose HTML element the Sidbar will be placed within.
        /// This must be a full CSS class specification (e.g., .sidebar__target).
        /// Default value is string.Empty.
        /// </summary>
        [Parameter]
        public string Target { get; set; } = string.Empty;

        /// <summary>
        /// One of the <see cref="SidebarType"/> values specifying the interaction of the Sidebar and other HTML elements when open/closed.
        /// Default value is Auto.
        /// </summary>
        [Parameter]
        public SidebarType Type { get; set; } = SidebarType.Auto;

        #endregion


        #region Event Callback Parameters

        // ==================================================
        // Event Callback Parameters
        // ==================================================

        /// <summary>
        /// An <see cref="EventCallback"/> containng the consumer's method invoked when the state(expand/collapse) of the Sidebar is changed.
        /// </summary>
        [Parameter]
        public EventCallback<ChangeEventArgs> Changed { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containng the consumer's method invoked when the state(expand/collapse) of the Sidebar is changed.
        /// </summary>
        [Parameter]
        public EventCallback<object> Created { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containng the consumer's method invoked when the state(expand/collapse) of the Sidebar is changed.
        /// </summary>
        [Parameter]
        public EventCallback<object> Destroyed { get; set; }

        /// <summary>
        /// An <see cref="EventCallback{TValue}"/> where TValue is an <see cref="bool"/>.
        /// The consumer's method is invoked when the Sidebar's open/closed state changes.
        /// The parameter is an boolean value which indicates the state of the Sidebar.
        /// Handling this callback adds the responsibility of updating the IsOpen parameter.
        /// </summary>
        [Parameter]
        public EventCallback<bool> IsOpenChanged { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containng the consumer's method invoked when the Sidebar is ready to close.
        /// </summary>
        [Parameter]
        public EventCallback<EventArgs> OnClose { get; set; }

        /// <summary>
        /// An <see cref="EventCallback"/> containng the consumer's method invoked when the Sidebar is ready to open.
        /// </summary>
        [Parameter]
        public EventCallback<EventArgs> OnOpen { get; set; }

        #endregion


        #region CSS Parameters

        // ==================================================
        // CSS Styling Parameters
        // ==================================================


        /// <summary>
        /// String value containing CSS class definition(s) that will be injected in the root HTML div element of the Tab container.
        /// Default value is string.Empty.
        /// </summary>
        [Parameter]
        public string CssClass { get; set; } = string.Empty;

        /// <summary>
        /// String value containing CSS ID that will be injected in the root HTML div element of the Tab container.
        /// Default value is string.Empty.
        /// </summary>
        [Parameter]
        public string CssId { get; set; } = string.Empty;

        /// <summary>
        /// Collection of additional HTML attributes such as styles, class, and more that are injected in root element. 
        /// If both property and equivalent HTML attribute are configured, the component considers the property value. 
        /// This is a <see cref="Dictionary{TKey, TValue}"/> where TKey is a <see cref="string"/> and TValue is an <see cref="object"/>.
        /// Default value is an empty dictionary.
        /// </summary>
        [Parameter]
        public Dictionary<string, object> HtmlAttributes { get; set; }

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/length">length</see> data type
        /// used to specify the size of the Sidebar in dock state.
        /// The length CSS data type represents a distance value.
        /// Note that only a single pixel value (e.g., 4px) should be set.
        /// Default value is 50px.
        /// </summary>
        [Parameter]
        public string DockSize { get; set; } = "50px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/Media_Queries/Using_media_queries">media query</see>
        /// used to specify the media query string for the resolution when the Sidebar opens.
        /// Media queries are useful when you want to modify your site or app depending on a device's general type 
        /// (such as print vs. screen) or specific characteristics and parameters (such as screen resolution or browser viewport width).
        /// For example: setting the parameter to '(min-width: 600px)' will open the Sidebar only when the provided resolution 
        /// is met else the Sidebar will be in closed state.
        /// Default value is string.Empty.
        /// </summary>
        [Parameter]
        public string MediaQuery { get; set; } = string.Empty;

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/width">width</see> value 
        /// specifying the width of the Sidebar. 
        /// The width CSS property sets an element's width.
        /// By default, the width of the Sidebar sets based on the size of its content. 
        /// Width can also be set in pixel values.
        /// Default value is string.Empty.
        /// </summary>
        [Parameter]
        public string Width { get; set; } = string.Empty;

        /// <summary>
        /// Integer value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/z-index">z-index</see> value 
        /// of the Sidebar. 
        /// The z-index CSS property sets the z-order of a positioned element and its descendants or flex items.
        /// It is applicable only when sidebar act as the overlay type.
        /// Default value is 0.
        /// </summary>
        [Parameter]
        public int ZIndex { get; set; } = 0;


        // ==================== Tab Header Styles ====================




        #endregion

        #endregion



        #region Callback Events Invoked from Underlying Components

        // ==================================================
        // Methods used as Callback Events from the underlying component(s)
        // ==================================================

        private async Task ChangedHandler(ChangeEventArgs args)
        {
            Debug.WriteLine("ChangedHandler method invoked.");
            if (Changed.HasDelegate) await Changed.InvokeAsync(args);
        }

        private async Task CreatedHandler(object args)
        {
            Debug.WriteLine("CreatedHandler method invoked.");
            if (Created.HasDelegate) await Created.InvokeAsync(args);
        }

        private async Task DestroyedHandler(object args)
        {
            Debug.WriteLine("DestroyedHandler method invoked.");
            if (Destroyed.HasDelegate) await Destroyed.InvokeAsync(args);
        }

        private async Task IsOpenChangedHandler(bool state)
        {
            Debug.WriteLine("IsOpenChangedHandler method invoked.");
            if (IsOpenChanged.HasDelegate) await IsOpenChanged.InvokeAsync(state);
            else IsOpen = state;
        }

        private async Task OnCloseHandler(EventArgs args)
        {
            Debug.WriteLine("OnCloseHandler method invoked.");
            if (OnClose.HasDelegate) await OnClose.InvokeAsync(args);
        }

        private async Task OnOpenHandler(EventArgs args)
        {
            Debug.WriteLine("OnOpenHandler method invoked.");
            if (OnOpen.HasDelegate) await OnOpen.InvokeAsync(args);
        }

        #endregion



        #region Instance Variables

        // ==================================================
        // Instance variables
        // ==================================================

        private SfSidebar sidebar;
        private string masterCssSelector;

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

            // Build the master selectors
            masterCssSelector = (CssClass == string.Empty) ? ".e-tab" : $".{ CssClass }.e-tab";

            // If the HtmlAttributes parameter is not set, create it.
            if (HtmlAttributes is null) HtmlAttributes = new();

            // If the CssClass parameter is set, add it to HtmlAttributes if it doesn't already exist.
            if ((CssClass != string.Empty) &&
                ((HtmlAttributes.TryGetValue("class", out object _) == false) && 
                 (HtmlAttributes.TryGetValue("CLASS", out object _) == false)))
            {
                HtmlAttributes.Add("class", CssClass);
            }

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
        /// Removes an entire tab from the collection of tabs.
        /// </summary>
        /// <param name="index">Integer value spefifying the index of the tab to remove.</param>
        //public async Task Hide() => await this.sidebar.Toggle();

        #endregion



        #region Private Methods for Internal Use Only
        #endregion

    }
}

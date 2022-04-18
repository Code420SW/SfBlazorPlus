using Code420.SfBlazorPlus.Pages.Orchestrator;
using Syncfusion.Blazor.Navigations;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using Code420.SfBlazorPlus.BaseComponents.MenuBase;
using Code420.SfBlazorPlus.Code.Models.Orchestrator;

namespace Code420.SfBlazorPlus.OrchestratorComponents.OrchestratorMenu
{
    public partial class OrchestratorMenu : ComponentBase
    {

        #region Component Parameters

        #region Base Parameters

        // ==================================================
        // Base Parameters
        // ==================================================

        /// <summary>
        /// Contains the reference to the <see cref="Orchestrator"/> parent.
        /// Used to subscribe to event handlers provided by the parent.
        /// </summary>
        [Parameter]
        public Orchestrator OrchestratorRef { get; set; }

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/font-size">font-size</see> value 
        /// used for the menu icons when the Sidebar is in the docked (closed) state.
        /// The font-size CSS property sets the size of the font.
        /// Default value is 28px.
        /// </summary>
        [Parameter]
        public string DockedIconFontSize { get; set; } = "28px";

        /// <summary>
        /// String value that specifies the CSS <see href="https://developer.mozilla.org/en-US/docs/Web/CSS/width">width</see> value 
        /// used for the menu when the Sidebar is in the docked (closed) state.
        /// The width CSS property sets an element's width.
        /// This parameter is needed so that the popup sub-menus are displated next to their menu item.
        /// Default value is 50px.
        /// </summary>
        [Parameter]
        public string DockedMenuWidth { get; set; } = "50px";

        /// <summary>
        /// String value containing CSS class  of the Sidebar container.
        /// Used to build the master CSS selector needed to handle menu customizations.
        /// Default value is string.Empty.
        /// </summary>
        [Parameter]
        public string SidebarCssClass { get; set; } = string.Empty;

        #endregion


        #region Event Callback Parameters

        // ==================================================
        // Event Callback Parameters
        // ==================================================


        #endregion


        #region CSS Parameters

        // ==================================================
        // CSS Styling Parameters
        // ==================================================


        #endregion

        #endregion



        #region Callback Events Invoked from Underlying Components

        // ==================================================
        // Methods used as Callback Events from the underlying component(s)
        // ==================================================

        private void MyClosedHandler(OpenCloseMenuEventArgs<OrchestratorMenuItem> args)
        {
            Debug.WriteLine("MyClosedeHandler method invoked");
        }

        private void MyCreatedHandler(object args)
        {
            Debug.WriteLine("MyCreatedHandler method invoked");
        }

        private void MyItemSelectedHandler(MenuEventArgs<OrchestratorMenuItem> args)
        {
            Debug.WriteLine("MyItemSelectedHandler method invoked");
        }

        private void MyOnCloseHandler(BeforeOpenCloseMenuEventArgs<OrchestratorMenuItem> args)
        {
            Debug.WriteLine("MyOnCloseHandler method invoked");
        }

        private void MyOnItemRenderHandler(MenuEventArgs<OrchestratorMenuItem> args)
        {
            Debug.WriteLine("MyOnItemRenderHandler method invoked");
        }

        private void MyOnOpenHandler(BeforeOpenCloseMenuEventArgs<OrchestratorMenuItem> args)
        {
            Debug.WriteLine("MyOnOpenHandler method invoked");
        }

        private void MyOpenedHandler(OpenCloseMenuEventArgs<OrchestratorMenuItem> args)
        {
            Debug.WriteLine("MyOpenedHandler method invoked");
        }

        #endregion



        #region Instance Variables

        // ==================================================
        // Instance variables
        // ==================================================

        private const string menuCssClass = "page__main-sidebar-menu";

        private MenuBase<OrchestratorMenuItem> menubase;
        //private bool isOpen = true;
        private Dictionary<string, object> myHtmlAttributes = new();
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
            masterCssSelector = (SidebarCssClass == string.Empty) ?
                $".e-close .{ menuCssClass }.e-menu-container" : 
                $".{ SidebarCssClass }.e-close .{ menuCssClass }.e-menu-container";
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

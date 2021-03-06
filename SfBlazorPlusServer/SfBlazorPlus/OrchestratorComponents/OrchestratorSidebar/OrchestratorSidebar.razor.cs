using Code420.SfBlazorPlus.BaseComponents.SidebarBase;
using Code420.SfBlazorPlus.OrchestratorComponents.OrchestratorMenu;
using Code420.SfBlazorPlus.Pages.Orchestrator;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using ChangeEventArgs = Syncfusion.Blazor.Navigations.ChangeEventArgs;
using EventArgs = Syncfusion.Blazor.Navigations.EventArgs;

namespace Code420.SfBlazorPlus.OrchestratorComponents.OrchestratorSidebar
{
    /// <summary>
    /// Provides a container for the OrchestratorMenu component.
    /// Responds to events from the OrchestratorSidebarButton (via the Orchestrator) to
    /// change the state (opened/closed) of the Sidebar.
    /// Provides a public method the return the current state of the Sidebar.
    /// </summary>
    public partial class OrchestratorSidebar : ComponentBase
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
        /// Boolean value setting the initial state of the IsOpen parameter.
        /// </summary>
        [Parameter]
        public bool InitialSidebarIsOpen { get; set; }

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

        public async Task MyChangedHandler(ChangeEventArgs args)
        {
            Debug.WriteLine("MyChangedHandler method invoked.");
        }

        private async Task MyCreatedHandler(object args)
        {
            Debug.WriteLine("MyCreatedHandler method invoked.");
        }

        private async Task MyDestroyedHandler(object args)
        {
            Debug.WriteLine("MyDestroyedHandler method invoked.");
        }

        private async Task MyIsOpenChangedHandler(bool state)
        {
            Debug.WriteLine("MyIsOpenChangedHandler method invoked.");
            isOpen = state;
        }

        private async Task MyOnCloseHandler(EventArgs args)
        {
            Debug.WriteLine("MyOnCloseHandler method invoked.");
        }

        private async Task MyOnOpenHandler(EventArgs args)
        {
            Debug.WriteLine("MyOnOpenHandler method invoked.");
        }

        #endregion



        #region Instance Variables

        // ==================================================
        // Instance variables
        // ==================================================

        private const string sidebarCssClass = "page__main-sidebar";
        private SidebarBase sidebarbase;                                                        // Reference to the SidebarBase component
        private OrchestratorMenu.OrchestratorMenu menu;                                         // Reference to the OrchestratorMenu component

        private bool isOpen;                                                                    // Indicates if the Sidebar is opened/closed
        private Dictionary<string, object> myHtmlAttributes = new();       // Discionary passed to SidebarBase

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

            // Set the initial state of the IsOpen parameter
            isOpen = InitialSidebarIsOpen;
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
        /// Opens/Closes the sidebar.
        /// </summary>
        public async Task ToggleSidebarAsync()
        {
            isOpen = !isOpen;
            await InvokeAsync(StateHasChanged);
        }

        public bool GetSidebarState() => isOpen;

        #endregion



        #region Private Methods for Internal Use Only
        #endregion

    }
}

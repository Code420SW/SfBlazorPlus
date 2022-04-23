using Code420.SfBlazorPlus.Code.Models.Menus;
using Code420.SfBlazorPlus.Code.Models.Orchestrator;
using Code420.SfBlazorPlus.OrchestratorComponents.OrchestratorSidebar;
using Code420.SfBlazorPlus.OrchestratorComponents.OrchestratorSidebarButton;
using Code420.SfBlazorPlus.OrchestratorComponents.OrchestratorTabMananger;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Navigations;
using System.Diagnostics;

namespace Code420.SfBlazorPlus.Pages.Orchestrator
{
    public partial class Orchestrator : ComponentBase
    {

        #region Component Parameters

        #region Base Parameters

        // ==================================================
        // Base Parameters
        // ==================================================

        

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


        #endregion



        #region Instance Variables

        // ==================================================
        // Instance variables
        // ==================================================

        private OrchestratorSidebar sidebar;                        // Reference to the Sidebar component
        private OrchestratorSidebarButton buttonSidebarToggle;      // Reference to the Sidebar toggle button
        private OrchestratorTabManager tabmanager;

        private bool initialSidebarIsOpen = true;                   // The initial state of the Sidebar IsOpen parameter


        public List<OrchestratorMenuItem> SidebarMenuItems { get => this.orchestratorParameters.SidebarMenuItems; }
        public List<OrchestratorMenuItem> MainMenuItems { get => this.orchestratorParameters.MainMenuItems; }
        public List<OrchestratorMenuItem> FavoritesMenuItems { get => this.orchestratorParameters.FavoritesMenuItems; }
        public List<OrchestratorTabDefinition> OrchestratorTabs { get => this.orchestratorParameters.OrchestratorTabs; }

        #endregion



        #region Injected Dependencies

        // Injected Dependencies
        IOrchestratorParameters orchestratorParameters;


        // Dependency Injection
        [Inject]
        IOrchestratorParameters _orchestratorParameters { get => orchestratorParameters; set => orchestratorParameters = value; }

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

        public void TabChanged()
        {
        }

        public void MenuItemSelected(string itemId)
        {
            Debug.WriteLine($"MenuItemSelected method invoked: itemId = { itemId }");

            // Get the index of the itemId record in the OrchestratorTabs list

            // Determine if the Tab Item associated with the itemId is already one of the Items()

            // If so, activate the tab

            // Find the highest index in the Tab Managers Item()

            // Otherwise, have the Tab Manager add the Tab Item

        }

        /// <summary>
        /// Toggles the open/close state of the Sidebar
        /// </summary>
        public async Task ToggleSidebarAsync() => await sidebar.ToggleSidebarAsync();

        /// <summary>
        /// Retrieves the current value of the Sidebar IsOpen parameter.
        /// </summary>
        /// <returns>Boolean value indicating if the Sidebar is open.</returns>
        public bool IsSidebarOpen() => (sidebar is not null) ? sidebar.GetSidebarState() : initialSidebarIsOpen;

        /// <summary>
        /// Finds the index of the menuItemId record in the OrchestratorTabs list.
        /// </summary>
        /// <param name="menuItemId">The id of the menu item to be found.</param>
        /// <returns>The index of the record, or -1 if not found.</returns>
        public int FindOrchestratorTabIndex(string menuItemId) =>
            OrchestratorTabs.FindIndex(x => x.MenuItemId == menuItemId);

        #endregion



        #region Private Methods for Internal Use Only


        #endregion

    }
}

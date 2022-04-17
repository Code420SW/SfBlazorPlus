﻿using Code420.SfBlazorPlus.Code.Models.Menus;
using Code420.SfBlazorPlus.OrchestratorComponents.OrchestratorSidebar;
using Code420.SfBlazorPlus.OrchestratorComponents.OrchestratorSidebarButton;
using Code420.SfBlazorPlus.OrchestratorComponents.OrchestratorTabMananger;
using Microsoft.AspNetCore.Components;

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

        private List<SidebarMenu> sidebarMenuItems;                 // Contains the menu its displayed in the Sidebar

        private bool initialSidebarIsOpen = true;                   // The initial state of the Sidebar IsOpen parameter

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

            // Initialize the Sidebar menu items
            InitializeSidebarMenu();

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

        /// <summary>
        /// Toggles the open/close state of the Sidebar
        /// </summary>
        public async Task ToggleSidebarAsync() => await sidebar.ToggleSidebarAsync();

        /// <summary>
        /// Returns the menu items displayed in the sidebar menu.
        /// </summary>
        /// <returns><see cref="List{T}"/> where T is <see cref="SidebarMenu"/> containing the menu items.</returns>
        public List<SidebarMenu> GetSidebarMenu() => sidebarMenuItems;

        /// <summary>
        /// Retrieves the current value of the Sidebar IsOpen parameter.
        /// </summary>
        /// <returns>Boolean value indicating if the Sidebar is open.</returns>
        public bool IsSidebarOpen() => (sidebar is not null) ? sidebar.GetSidebarState() : initialSidebarIsOpen;

        #endregion



        #region Private Methods for Internal Use Only

        // Build the list of menu items displayed in the Sidebar.
        private void InitializeSidebarMenu()
        {
            sidebarMenuItems = new List<SidebarMenu>()
            {
                new SidebarMenu
                {
                    Data = "Company",
                    Disabled = false,
                    Hidden = false,
                    IconCss = "oi oi-aperture",
                    ItemId = "1000",
                    ParentId = null,
                    SubMenu = new List<SidebarMenu>
                    {
                        new SidebarMenu
                        {
                            Data= "Overview",
                            Disabled = false,
                            Hidden = false,
                            IconCss = "oi oi-badge",
                            ItemId = "1101",
                            ParentId = "1000",
                            SubMenu = new List<SidebarMenu>
                            {
                                new SidebarMenu{ Data = "Hardware", ItemId = "1201", ParentId = "1101" },
                                new SidebarMenu{ Data = "Software", ItemId = "1202", ParentId = "1101" }
                            }
                        },

                        new SidebarMenu
                        {
                            Data= "Careers",
                            Disabled = false,
                            Hidden = false,
                            IconCss = "oi oi-basket",
                            ItemId = "1102",
                            ParentId = "1000"
                        },

                        new SidebarMenu
                        {
                            ItemId = "1199",
                            ParentId = "1000",
                            Separator = true
                        },

                        new SidebarMenu
                        {
                            Data= "About",
                            Disabled = false,
                            Hidden = false,
                            IconCss = "oi oi-ban",
                            ItemId = "1103",
                            ParentId = "1000"
                        }
                    }
                },

                new SidebarMenu
                {
                    Data = "Services",
                    Disabled = false,
                    Hidden = false,
                    IconCss = "oi oi-book",
                    ItemId = "2000",
                    ParentId = null,
                    SubMenu = new List<SidebarMenu>
                    {
                        new SidebarMenu{ Data= "Consulting", ParentId = "2000" },
                        new SidebarMenu{ Data= "Education", ParentId = "2000" },
                        new SidebarMenu{ Data= "Health", ParentId = "2000" }
                    }
                },

                new SidebarMenu
                {
                    Data = "Products",
                    Disabled = false,
                    Hidden = false,
                    IconCss = "oi oi-bookmark",
                    ItemId = "3000",
                    ParentId = null,
                    SubMenu = new List<SidebarMenu>
                    {
                        new SidebarMenu{ Data = "Hardware", ParentId = "3000" },
                        new SidebarMenu{ Data = "Software", ParentId = "3000" }
                    }
                },

                new SidebarMenu
                {
                    Data = "Contact Us",
                    Disabled = false ,
                    Hidden = false,
                    IconCss = "oi oi-bug",
                    ItemId = "4000",
                    ParentId = null
                }
            };
        }

        #endregion

    }
}
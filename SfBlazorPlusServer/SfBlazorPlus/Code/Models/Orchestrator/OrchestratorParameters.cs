using System.Diagnostics;
using Code420.SfBlazorPlus.OrchestratorComponents.OrchestratorTabManager.OrchestratorTabs.DummyTab;
using Code420.SfBlazorPlus.OrchestratorComponents.OrchestratorTabMananger.OrchestratorTabs.CounterTab;
using Code420.SfBlazorPlus.OrchestratorComponents.OrchestratorTabMananger.OrchestratorTabs.CounterStateMachineTab;
using Code420.SfBlazorPlus.OrchestratorComponents.OrchestratorTabManager.OrchestratorTabs.DynamicComponentTab;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Navigations;
using Code420.SfBlazorPlus.Code.Models.Menus;

namespace Code420.SfBlazorPlus.Code.Models.Orchestrator
{
    /// <summary>
    /// Containerizes all the data structures used by the Orchestrator.
    /// Responsible for initializing the data structures by the constructor.
    /// Injected into the Orchestrator component through an AddScoped DI definition.
    /// 
    /// NOTES: 
    ///     1.  Since the components used in the Tab Items are defined in BuildOrchestratorTabs(), 
    ///         make sure the using statements are correct.
    ///     2.  The linake between a Menu Item and the Tab Item loaded is through the Menu Item's
    ///         ItemId field and the Tab Item's CssClass field. These two must match for things to work.
    /// </summary>
    public class OrchestratorParameters : IOrchestratorParameters
    {

        #region Instance Variables

        // ==================================================
        // Instance variables
        // ==================================================

        #endregion



        #region Constructors

        public OrchestratorParameters()
        {
            BuildOrchestratorTabs();
            BuildSidebarMenu();
            BuildMainMenu();
            BuildFavoritesMenu();
            //Tester();
        }

        #endregion



        #region Public Properties

        public List<OrchestratorMenuItem> SidebarMenuItems { get; private set; }

        public List<OrchestratorMenuItem> MainMenuItems { get; private set; }

        public List<OrchestratorMenuItem> FavoritesMenuItems { get; private set; }

        public List<OrchestratorTabDefinition> OrchestratorTabs { get; private set; }

        #endregion



        #region Public Methods Providing Access to the Underlying Components to the Consumer

        // ==================================================
        // Public Methods providing access to the underlying component to the consumer
        // ==================================================

        #endregion



        #region Private Methods for Internal Use Only

        private void Tester()
        {
            Debug.WriteLine("Tester hit");
        }

        private void BuildOrchestratorTabs()
        {
            OrchestratorTabs = new()
            {
                new()
                {
                    MenuItemId = "4000", 
                    IsLoaded = false,
                    TabIndex = -1,
                    TabDefinition = new()
                    {
                        CssClass="4000",
                        ContentTemplate = RenderComponent(typeof(DummyTab)),
                        Disabled=false,
                        Header = new ()
                        {
                            IconCss= "",
                            IconPosition="",
                            Text = "Dummy Tab"
                        },
                        Visible=true
                    }
                },

                new()
                {
                    MenuItemId = "1001",
                    IsLoaded = false,
                    TabIndex = -1,
                    TabDefinition = new()
                    {
                        CssClass ="1001",
                        ContentTemplate = RenderComponent(typeof(CounterTab)),
                        Disabled = false,
                        Header = new()
                        {
                            IconCss = "",
                            IconPosition = "",
                            Text = "Counter"
                        },
                        Visible = true
                    }
                },

                new()
                {
                    MenuItemId = "1002",
                    IsLoaded = false,
                    TabIndex = -1,
                    TabDefinition = new()
                    {
                        CssClass = "1002",
                        ContentTemplate = RenderComponent(typeof(CounterStateMachineTab)),
                        Disabled = false,
                        Header = new()
                        {
                            IconCss = "",
                            IconPosition = "",
                            Text = "Counter State Machine"
                        },
                        Visible = true
                    }
                },

                new()
                {
                    MenuItemId = "2000",
                    IsLoaded = false,
                    TabIndex = -1,
                    TabDefinition = new()
                    {
                        CssClass = "2000",
                        ContentTemplate = RenderComponent(typeof(DynamicComponentTab)),
                        Disabled = false,
                        Header = new()
                        {
                            IconCss = "",
                            IconPosition = "",
                            Text = "Dynamic Component"
                        },
                        Visible = true
                    }
                }

            };
        }

        private void BuildSidebarMenu()
        {
            SidebarMenuItems = new List<OrchestratorMenuItem>()
            {
                new OrchestratorMenuItem
                {
                    MenuText = "Counter Tests",
                    IsDisabled = false,
                    IsHidden = false,
                    IconCss = "oi oi-aperture",
                    ItemId = "1000",
                    ParentId = null,
                    SubMenu = new List<OrchestratorMenuItem>
                    {
                        new OrchestratorMenuItem()
                        {
                            MenuText = "Counter",
                            ItemId = "1001",
                            ParentId = "1000"
                        },
                        new OrchestratorMenuItem()
                        {
                            MenuText = "Counter State Machine",
                            ItemId = "1002",
                            ParentId = "1000"
                        }
                    }
                },

                new OrchestratorMenuItem
                {
                    MenuText = "Dynamic Component",
                    IsDisabled = false,
                    IsHidden = false,
                    IconCss = "oi oi-book",
                    ItemId = "2000",
                    ParentId = null,
                },

                new OrchestratorMenuItem
                {
                    MenuText = "Dummy Tab",
                    IsDisabled = false ,
                    IsHidden = false,
                    IconCss = "oi oi-bug",
                    ItemId = "4000",
                    ParentId = null
                }
            };
        }

        private void BuildMainMenu()
        {
            MainMenuItems = new List<OrchestratorMenuItem>()
                {
                new OrchestratorMenuItem
                {
                    MenuText = "Counter Tests",
                    IsDisabled = false,
                    IsHidden = false,
                    ItemId = "1000",
                    ParentId = null,
                    SubMenu = new List<OrchestratorMenuItem>
                    {
                        new OrchestratorMenuItem()
                        {
                            MenuText = "Counter",
                            ItemId = "1001",
                            ParentId = "1000"
                        },
                        new OrchestratorMenuItem()
                        {
                            MenuText = "Counter State Machine",
                            ItemId = "1002",
                            ParentId = "1000"
                        }
                    }
                },

                new OrchestratorMenuItem
                {
                    MenuText = "Dynamic Component",
                    IsDisabled = false,
                    IsHidden = false,
                    ItemId = "2000",
                    ParentId = null,
                },

                new OrchestratorMenuItem
                {
                    MenuText = "Dummy Tab",
                    IsDisabled = false ,
                    IsHidden = false,
                    ItemId = "4000",
                    ParentId = null
                }
            };
        }

        private void BuildFavoritesMenu()
        {
            FavoritesMenuItems = new List<OrchestratorMenuItem>();
        }

        private RenderFragment RenderComponent(Type componentType) =>
            builder =>
            {
                builder.OpenComponent(0, componentType);
                builder.CloseComponent();
            };

        #endregion
    }
}

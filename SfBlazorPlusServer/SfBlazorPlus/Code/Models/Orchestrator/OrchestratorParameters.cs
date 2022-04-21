﻿using System.Diagnostics;

namespace Code420.SfBlazorPlus.Code.Models.Orchestrator
{
    public class OrchestratorParameters : IOrchestratorParameters
    {
        
        //
        // Instance variables
        //


        // 
        // Constructor
        //
        public OrchestratorParameters()
        {
            BuildOrchestratorTabsDictionary();
            BuildSidebarMenu();
            BuildMainMenu();
            BuildFavoritesMenu();
            Tester();
        }


        // 
        // Properties
        //

        public List<OrchestratorMenuItem> SidebarMenuItems { get; private set; }

        public List<OrchestratorMenuItem> MainMenuItems { get; private set; }

        public List<OrchestratorMenuItem> FavoritesMenuItems { get; private set; }

        public Dictionary<string, string> OrchestratorTabs { get; private set; }



        // 
        // Public Methods
        //


        //
        // Private Methods
        //

        private void Tester()
        {
            Debug.WriteLine("Tester hit");
            var temp = SidebarMenuItems[0].GetType();
        }

        private void BuildOrchestratorTabsDictionary()
        {
            OrchestratorTabs = new Dictionary<string, string>()
            {
                {"1201", "DummyTab" },
                {"1202", "DummyTab" }
            };
        }

        private void BuildSidebarMenu()
        {
            SidebarMenuItems = new List<OrchestratorMenuItem>()
            {
                new OrchestratorMenuItem
                {
                    MenuText = "Company",
                    IsDisabled = false,
                    IsHidden = false,
                    IconCss = "oi oi-aperture",
                    ItemId = "1000",
                    ParentId = null,
                    SubMenu = new List<OrchestratorMenuItem>
                    {
                        new OrchestratorMenuItem
                        {
                            MenuText= "Overview",
                            IsDisabled = false,
                            IsHidden = false,
                            IconCss = "oi oi-badge",
                            ItemId = "1101",
                            ParentId = "1000",
                            SubMenu = new List<OrchestratorMenuItem>
                            {
                                new OrchestratorMenuItem()
                                { 
                                    MenuText = "Hardware", 
                                    ItemId = "1201", 
                                    ParentId = "1101",
                                    ComponentName="DummyTab",
                                    ComponentCssClass="tab__hardware",
                                    ComponentDisabled=false,
                                    ComponentVisible=true,
                                    ComponentTabHeaderIconCss="",
                                    ComponentTabHeaderIconPosition="",
                                    ComponentTabHeaderText="Default Tab"
                                },
                                new OrchestratorMenuItem() 
                                { 
                                    MenuText = "Software", 
                                    ItemId = "1202", 
                                    ParentId = "1101" 
                                }
                            }
                        },

                        new OrchestratorMenuItem
                        {
                            MenuText= "Careers",
                            IsDisabled = false,
                            IsHidden = false,
                            IconCss = "oi oi-basket",
                            ItemId = "1102",
                            ParentId = "1000"
                        },

                        new OrchestratorMenuItem
                        {
                            ItemId = "1199",
                            ParentId = "1000",
                            IsSeparator = true
                        },

                        new OrchestratorMenuItem
                        {
                            MenuText= "About",
                            IsDisabled = false,
                            IsHidden = false,
                            IconCss = "oi oi-ban",
                            ItemId = "1103",
                            ParentId = "1000"
                        }
                    }
                },

                new OrchestratorMenuItem
                {
                    MenuText = "Services",
                    IsDisabled = false,
                    IsHidden = false,
                    IconCss = "oi oi-book",
                    ItemId = "2000",
                    ParentId = null,
                    SubMenu = new List<OrchestratorMenuItem>
                    {
                        new OrchestratorMenuItem{ MenuText= "Consulting", ParentId = "2000" },
                        new OrchestratorMenuItem{ MenuText= "Education", ParentId = "2000" },
                        new OrchestratorMenuItem{ MenuText= "Health", ParentId = "2000" }
                    }
                },

                new OrchestratorMenuItem
                {
                    MenuText = "Products",
                    IsDisabled = false,
                    IsHidden = false,
                    IconCss = "oi oi-bookmark",
                    ItemId = "3000",
                    ParentId = null,
                    SubMenu = new List<OrchestratorMenuItem>
                    {
                        new OrchestratorMenuItem{ MenuText = "Hardware", ParentId = "3000" },
                        new OrchestratorMenuItem{ MenuText = "Software", ParentId = "3000" }
                    }
                },

                new OrchestratorMenuItem
                {
                    MenuText = "Contact Us",
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
            MainMenuItems = new List<OrchestratorMenuItem>();
        }

        private void BuildFavoritesMenu()
        {
            FavoritesMenuItems = new List<OrchestratorMenuItem>();
        }
    }
}

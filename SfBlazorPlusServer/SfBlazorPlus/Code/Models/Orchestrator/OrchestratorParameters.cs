namespace Code420.SfBlazorPlus.Code.Models.Orchestrator
{
    public class OrchestratorParameters
    {
        
        //
        // Instance variables
        //


        // 
        // Constructor
        //
        public OrchestratorParameters()
        {
            BuildSidebarMenu();
        }


        // 
        // Properties
        //

        public List<IOrchestratorMenuItem> SidebarMenuItems { get; private set; }


        // 
        // Public Methods
        //


        //
        // Private Methods
        //

        private void BuildSidebarMenu()
        {
            SidebarMenuItems = new List<IOrchestratorMenuItem>()
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
                                new OrchestratorMenuItem{ MenuText = "Hardware", ItemId = "1201", ParentId = "1101" },
                                new OrchestratorMenuItem{ MenuText = "Software", ItemId = "1202", ParentId = "1101" }
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
    }
}

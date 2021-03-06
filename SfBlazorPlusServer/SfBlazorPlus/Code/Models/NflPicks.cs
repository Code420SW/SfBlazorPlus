namespace Code420.SfBlazorPlus.Code.Models
{
    //
    // This is a fast and dirty data struction for demonstration purposes.
    // DO NOT consider this good coding pratice--SRP is proper approach.
    //

    public class NflPicks
    {
        // Properties--no backing fields
        public Teams AfcTeams { get; set; }

        public Teams NfcTeams { get; set; }

        public string SuperBowlWinner { get; set; } = String.Empty;

        public string DisplayName { get; set; } = String.Empty;


        // Constructor
        public NflPicks()
        {
            AfcTeams = new();
            AfcTeams.TeamList.Add(new TeamData() { FullName= "Cincinnati Bengals", ShortName="Bengals" });
            AfcTeams.TeamList.Add(new TeamData() { FullName = "Kansas City Chiefs", ShortName = "Chiefs" });

            NfcTeams = new();
            NfcTeams.TeamList.Add(new TeamData() { FullName = "San Francisco 49ers", ShortName = "Niners" });
            NfcTeams.TeamList.Add(new TeamData() { FullName = "Los Angeles Rams", ShortName = "Rams" });
        }
        


        public class Teams
        {
            public Teams()
            {
                TeamList = new();
            }

            public List<TeamData> TeamList { get; set; }
            public string SelectedTeam { get; set; } = String.Empty;
        }

        public class TeamData
        {
            public string FullName { get; set; }
            public string ShortName { get; set; }
        }

    }
}

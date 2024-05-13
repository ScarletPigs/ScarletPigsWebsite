using ScarletPigsWebsite.Data.Models.RoleAssignments;

namespace ScarletPigsWebsite.Components.Pages
{
    public partial class BuildARoleSheet
    {
        private List<Squad> Squads = new List<Squad>();
        private Squad EditSquad = new Squad();
        private Role EditRole = new Role();


        protected override Task OnInitializedAsync()
        {

            Squads.Add(new Squad
            {
                Callsign = "Odin",
                DescriptiveName = "PLT Command",
                Description = "",
                SRRadioChannels = new string[] { "1", "2", "3" },
                LRRadioChannels = new string[] { "4", "5", "6" },
                Roles = new List<Role>
                {
                    new Role
                    {
                        Name = "Rifleman",
                        Icon = "imgs/arma/orbaticons/Nato JMS_Infantry.svg",
                        Description = "The standard infantryman, armed with",
                        AssignedPlayer = "Player1",
                    }
                },
                Squads = new List<Squad>
                {
                    new Squad
                    {
                        Callsign = "Iduna",
                        DescriptiveName = "Logistics",
                        Description = "",
                        SRRadioChannels = new string[] { "1", "2", "3" },
                        LRRadioChannels = new string[] { "4", "5", "6" },
                        Roles = new List<Role>
                        {
                            new Role
                            {
                                Name = "Rifleman",
                                Icon = "imgs/arma/orbaticons/Nato JMS_Infantry.svg",
                                Description = "The standard infantryman, armed with",
                                AssignedPlayer = "Player2",
                            },
                            new Role
                            {
                                Name = "Rifleman",
                                Icon = "imgs/arma/orbaticons/Nato JMS_Infantry.svg",
                                Description = "The standard infantryman, armed with",
                                AssignedPlayer = "Player3",
                            },
                            new Role
                            {
                                Name = "Rifleman",
                                Icon = "imgs/arma/orbaticons/Nato JMS_Infantry.svg",
                                Description = "The standard infantryman, armed with",
                                AssignedPlayer = "Player4",
                            }
                        }
                    },
                    new Squad
                    {
                        Callsign = "Thor",
                        DescriptiveName = "Rifle Squad",
                        Description = "",
                        SRRadioChannels = new string[] { "1", "2", "3" },
                        LRRadioChannels = new string[] { "4", "5", "6" },
                        Roles = new List<Role>
                        {
                            new Role
                            {
                                Name = "Rifleman",
                                Icon = "imgs/arma/orbaticons/Nato JMS_Infantry.svg",
                                Description = "The standard infantryman, armed with",
                                AssignedPlayer = "Player5",
                            }
                        },
                        Squads = new List<Squad>
                        {
                            new Squad
                            {
                                Callsign = "Freyja",
                                DescriptiveName = "Support Mk20",
                                Description = "",
                                SRRadioChannels = new string[] { "1", "2", "3" },
                                LRRadioChannels = new string[] { "4", "5", "6" },
                                Roles = new List<Role>
                                {
                                    new Role
                                    {
                                        Name = "Rifleman",
                                        Icon = "imgs/arma/orbaticons/Nato JMS_Infantry.svg",
                                        Description = "The standard infantryman, armed with",
                                        AssignedPlayer = "Player6",
                                    }
                                }
                            }
                        }
                    }
                }
            });

            return base.OnInitializedAsync();
        }

    }
}
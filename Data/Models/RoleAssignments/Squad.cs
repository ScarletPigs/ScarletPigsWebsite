namespace ScarletPigsWebsite.Data.Models.RoleAssignments
{
    public class Squad
    {
        public string Callsign { get; set; }
        public string DescriptiveName { get; set; }
        public string Description { get; set; }
        public string[] SRRadioChannels { get; set; }
        public string[] LRRadioChannels { get; set; }
        public List<Role> Roles { get; set; }
        public List<Squad> Squads { get; set; }
    }
}

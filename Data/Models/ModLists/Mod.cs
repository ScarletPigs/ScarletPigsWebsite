
using ScarletPigsWebsite.Data.Enums;
using ScarletPigsWebsite.Data.Models.Helpers;
using System.Text.RegularExpressions;

namespace ScarletPigsWebsite.Data.Models.ModLists
{
    public class Mod
    {

        public string UID { get; set; }
        public string Name { get; set; }

        public bool IsCdlc()
        {
            if (string.IsNullOrEmpty(UID))
                return false; // UID is null or empty, not a valid ID

            if (int.TryParse(UID, out int uidValue))
            {
                return Enum.IsDefined(typeof(CdlcEnum), uidValue);
            }

            return false; // UID is not a valid integer
        }

        internal string GetCommandLineName()
        {
            // If it's a CDLC, we can just return the command line name
            if (IsCdlc())
                return EnumUtil.GetCommandLineName((CdlcEnum)int.Parse(UID));

            // else it's a normal mod and we need to clean the name
            // Regular expression pattern for invalid characters
            string pattern = @"[.()!:/]+";

            // Replace invalid characters with an empty string
            return Regex.Replace(Name, pattern, string.Empty);
        }
    }
}
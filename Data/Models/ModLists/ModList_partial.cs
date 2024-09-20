using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging.Abstractions;
using ScarletPigsWebsite.Data.Models.Helpers;
using System.Text;
using System.Xml.Linq;

namespace ScarletPigsWebsite.Data.Models.ModLists
{
    public partial class ModList
    {
        public ModList()
        {
            Name = "";
            Description = "";
            Author = "";
            CreatedAt = DateTime.Now;
            LastUpdatedAt = DateTime.Now;
            Mods = new List<Mod>();
        }

        public static async Task<ModList> CreateModListFromFileAsync(IBrowserFile file)
        {
            return await HtmlModListParser.CreateModListFromFileAsync(file);
        }

        //loop through all the mods and create the command line
        public string GetCommandLine()
        {
            return string.Join(";", Mods
                .Select(mod => mod.GetCommandLineName())
                .Where(commandLineName => !string.IsNullOrEmpty(commandLineName))); // Filter out null or empty entries
        }

    }
}

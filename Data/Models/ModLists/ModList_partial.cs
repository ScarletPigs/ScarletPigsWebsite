using Microsoft.AspNetCore.Components.Forms;
using Microsoft.Extensions.Logging.Abstractions;
using ScarletPigsWebsite.Data.Enums;
using ScarletPigsWebsite.Data.Models.Helpers;
using ScarletPigsWebsite.Data.Models.Steamworks;
using ScarletPigsWebsite.Data.Util;
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
            Dlcs = new List<Mod>();
        }

        public static async Task<ModList> CreateModListFromFileAsync(IBrowserFile file)
        {
            return await HtmlModListParser.CreateModListFromFileAsync(file);
        }

        public static ModList CreateModListFromSteamIds(PublishedFileDetailsResponse publishedFileDetailsResponse)
        {
            if (publishedFileDetailsResponse?.Response?.Result == 1) // OK
            {
                // Handle successful response
                ModList modList = new ModList();

                var fileDetails = publishedFileDetailsResponse.Response.PublishedFileDetails;
                // Process fileDetails as needed
                foreach (var file in fileDetails)
                {
                    // Only add mods that were successfully retrieved
                    if (file.Result != 1)
                        continue;

                    // Only add mods that are for Arma 3
                    if (file.CreatorAppId != Constants.Arma3AppId)
                        continue;

                    Mod mod = new Mod()
                    {
                        Name = file.Title,
                        UID = file.PublishedFileId.ToString()
                    };
                    modList.AddMod(mod);
                }

                return modList;
            }
            else
            {
                return null;
            }
        }

        //loop through all the mods and create the command line
        public string GetCommandLine()
        {
            return string.Join(";", Dlcs
                .Concat(Mods)
                .Select(mod => mod.GetCommandLineName())
                .Where(commandLineName => !string.IsNullOrEmpty(commandLineName))); // Filter out null or empty entries
        }


        //TODO: Move this to a database table on the server and clean up the enum stuff.
        public static List<Mod> GetAvailableDlcs()
        {
            List<Mod> allDlcMods = new List<Mod>();
            foreach (DlcEnum dlc in Enum.GetValues(typeof(DlcEnum)))
            {
                Mod mod = new Mod()
                {
                    UID = ((int)dlc).ToString(),
                    Name = EnumUtil.GetDisplayName(dlc)
                };
                allDlcMods.Add(mod);
            }

            return allDlcMods;
        }

        //see if any of the mods in the list are dlcs and return those
        public static List<Mod> FindDlcFromIds(List<string> Uids)
        {
            List<Mod> dlcs = new List<Mod>();
            foreach (string uid in Uids)
            {
                if (int.TryParse(uid, out int uidValue))
                {
                    if (Enum.IsDefined(typeof(DlcEnum), uidValue))
                    {
                        Mod mod = new Mod()
                        {
                            UID = uid,
                            Name = EnumUtil.GetDisplayName((DlcEnum)uidValue)
                        };
                        dlcs.Add(mod);
                    }
                }
            }

            return dlcs;
        }


        public bool UpdateDlcs(List<Mod> dlcs)
        {
            if (dlcs.Count == Dlcs.Count && dlcs.All(Dlcs.Contains))
                return false;

            Dlcs = dlcs;
            return true;
        }

        public bool HasMods()
        {
            return Mods.Count + Dlcs.Count > 0;
        }

        public void AddMod(Mod mod)
        {
            if (mod.IsDlc())
                Dlcs.Add(mod);
            else
                Mods.Add(mod);
        }
        
        public void RemoveMod(Mod mod)
        {
            if (mod.IsDlc())
                Dlcs.Remove(mod);
            else
                Mods.Remove(mod);
        }

    }
}

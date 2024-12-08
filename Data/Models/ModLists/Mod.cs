﻿
using ScarletPigsWebsite.Data.Enums;
using ScarletPigsWebsite.Data.Models.Helpers;
using System.Text.RegularExpressions;

namespace ScarletPigsWebsite.Data.Models.ModLists
{
    public class Mod
    {

        //steam workshop id
        public string UID { get; set; }

        public long SizeInBytes { get; set; }

        private string _name;
        public string Name
        {
            //get our hardcoded name if it's a dlc, otherwise get the normal mod name
            get => IsDlc() && Enum.TryParse(typeof(DlcEnum), UID, out var dlcEnum)
                        ? EnumUtil.GetDisplayName((DlcEnum)dlcEnum)
                        : _name;
            set => _name = value;
        }

        public bool IsDlc()
        {
            if (string.IsNullOrEmpty(UID))
                return false; // UID is null or empty, not a valid ID

            if (int.TryParse(UID, out int uidValue))
            {
                return Enum.IsDefined(typeof(DlcEnum), uidValue);
            }

            return false; // UID is not a valid integer
        }

        internal string GetCommandLineName()
        {
            // If it's a CDLC, we can just return the command line name
            if (IsDlc())
                return EnumUtil.GetCommandLineName((DlcEnum)int.Parse(UID));

            //Else it's a normal mod and we need to clean the name

            //Apply special cases for the command line name
            //returns false if only special case pattern should be applied.
            if (!ApplySpecialCasesForCommandLineNames())
                return Name;


            //Check for allowed characters
            string pattern = @"[^a-zA-Z0-9' +\-@_()\[\]]+";

            // Replace invalid characters with an empty string
            return $"@{Regex.Replace(Name, pattern, string.Empty)}";
        }

        //apply special cases for the command line name.
        //returns true the base pattern should be applied, false if only special case pattern should be applied
        private bool ApplySpecialCasesForCommandLineNames()
        {
            string pattern = string.Empty;
            switch (UID)
            {
                //Task Force Arrowhead Radio (BETA!!!)
                case "894678801":
                    //Remove ()
                    pattern = @"[()]+";
                    Name = Regex.Replace(Name, pattern, string.Empty);
                    return true;
            }

            return true;
        }

        public override bool Equals(object o)
        {
            var other = o as Mod;
            return other?.UID == UID;
        }

        // Note: this is important so the select can compare pizzas
        public override int GetHashCode() => UID.GetHashCode();
    }
}
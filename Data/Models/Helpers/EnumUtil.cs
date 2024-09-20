using ScarletPigsWebsite.Data.Enums;
using System.ComponentModel;

namespace ScarletPigsWebsite.Data.Models.Helpers
{
    public static class EnumUtil
    {
        public static string GetCommandLineName(Enum enumEntry)
        {
            var fieldInfo = enumEntry.GetType().GetField(enumEntry.ToString());
            var attributes = (CommandLineNameAttribute[])fieldInfo.GetCustomAttributes(typeof(CommandLineNameAttribute), false);
            return attributes.Length > 0 ? attributes[0].Name : enumEntry.ToString();
        }
    }
}

using System.ComponentModel;

namespace ScarletPigsWebsite.Data.Enums
{
    public enum CdlcEnum
    {
        [CommandLineName("ws")]
        WesternSahara = 1681170,

        [CommandLineName("spe")]
        Spearhead = 1175380,

        [CommandLineName("")] //never need to add this to the command line
        Contact = 1021790,

        [CommandLineName("gm")]
        GlobalMobilization = 1042220,

        [CommandLineName("vn")]
        SogPrairieFire = 1227700,

        [CommandLineName("csla")]
        CslaIronCurtain = 1294440,

        [CommandLineName("rf")]
        ReactionForces = 2647760,
    }
}

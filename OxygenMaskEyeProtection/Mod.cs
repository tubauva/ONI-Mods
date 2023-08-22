using HarmonyLib;
using KMod;
using ONI_Mod_Oxygen_Mask;
using PeterHan.PLib.Core;
using PeterHan.PLib.Options;
using ProcGen;

public class Mod : UserMod2
{
    public override void OnLoad(Harmony harmony)
    {
        PUtil.InitLibrary();
        var options = new POptions();
        options.RegisterOptions(this, typeof(Config));
        base.OnLoad(harmony);
    }
}
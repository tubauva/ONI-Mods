using HarmonyLib;
using UnityEngine;

public static class HarmonyPatches
{
    [HarmonyPatch(typeof(OxygenMaskConfig), "CreateEquipmentDef")]
    public static class OxygenMaskConfig_CreateEquipmentDef_Patch
    {
        public static void Postfix(ref EquipmentDef __result)
        {
            __result.AdditionalTags = new Tag[1] { GameTags.AirtightSuit }; // adds the tag airtightsuit from atmo suit to oxygen mask
        }
    }

    public static void Patch()
    {
        Harmony harmony = new Harmony("OxygenMaskProtection");
        harmony.PatchAll();
    }
}

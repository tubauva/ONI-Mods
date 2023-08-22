using HarmonyLib;
using JetBrains.Annotations;
using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace ONI_Mod_Oxygen_Mask
{
    [HarmonyPatch(typeof(OxygenMaskConfig), "CreateEquipmentDef")]
    public class OxygenMaskConfig_Patch
    {
        public static bool ShouldStoreCO2()
        {
            return Config.Instance.StoreCO2; // Return the value of StoreCO2
        }

        public static void Postfix(EquipmentDef __result)
        {
            if (ShouldStoreCO2())
            {
                __result.AdditionalTags = new Tag[1] { GameTags.AirtightSuit }; // Add AirtightSuit tag
            }
        }
    }

    [HarmonyPatch(typeof(OxygenMaskConfig), "CreateEquipmentDef")]
    public class OxygenMaskConfig_AddEffects_Patch
    {
        public static void Postfix(EquipmentDef __result)
        {
            // Add the specified effects to the EffectImmunites list
            __result.EffectImmunites.Add(Db.Get().effects.Get("MinorIrritation"));
            __result.EffectImmunites.Add(Db.Get().effects.Get("MajorIrritation"));
        }
    }

    public static class HarmonyPatches
    {
        public static void Patch()
        {
            Harmony harmony = new Harmony("OxygenMaskProtection");
            harmony.PatchAll();
        }
    }
}

using System;
using HarmonyLib;
using RimWorld;
using Verse;
using System.Reflection;

namespace BaseRobot
{

    [StaticConstructorOnStartup]
    class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.github.harmony.rimworld.baserobots");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }

    [HarmonyPatch(typeof(Pawn_NeedsTracker))]
	[HarmonyPatch("ShouldHaveNeed")]
	[HarmonyPatch(new Type[] { typeof(NeedDef) })]
	class Need_Battery_Patch
	{
		static void Postfix(Pawn_NeedsTracker __instance, NeedDef nd, ref bool __result)
		{
			Pawn pawn = (Pawn)AccessTools.Field (typeof(Pawn_NeedsTracker), "pawn").GetValue (__instance);
            Log.Message("Pawn battery check: " + pawn.Name);
            if (nd.needClass == typeof(Need_Battery)) {
				if (pawn.def.thingClass == typeof(ArcBaseRobot) ) {
                    ArcBaseRobot robot = (ArcBaseRobot)pawn;
                    if (robot.isRobot()){
                        Log.Message("Pawn need battery : " + pawn.Name);
                        __result = true;
                    }else{
                        __result = false;
                    }
				} else {
					__result = false;
				}
			} else if (pawn.def.thingClass == typeof(ArcBaseRobot)) {
				__result = false;
			}
		}
	}
}
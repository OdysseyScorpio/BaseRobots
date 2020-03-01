using UnityEngine;
using Verse;
using RimWorld;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Reflection.Emit;

namespace BaseRobot
{


        public class PawnColumnWorker_RobotArea : PawnColumnWorker_AllowedArea

	{
		//
		// Methods
		//

		public override void DoCell (Rect rect, Pawn pawn, PawnTable table)

		{

                // Allow robots to be assigned to any area

               
                AreaAllowedGUI.DoAllowedAreaSelectors (rect, pawn );
		}
	}
}

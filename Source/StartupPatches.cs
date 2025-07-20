﻿using System.Collections.Generic;
using Verse;

namespace ProperShotguns
{
    [StaticConstructorOnStartup]
    public static class StartupPatches
    {
        static StartupPatches()
        {
            List<ThingDef> thingDefs = DefDatabase<ThingDef>.AllDefsListForReading;
            for (int i = 0; i < thingDefs.Count; i++)
            {
                var tDef = thingDefs[i];

                // Add verb caches to all projectile defs
                if (typeof(Projectile).IsAssignableFrom(tDef.thingClass))
                {
                    if (tDef.comps == null)
                        tDef.comps = new List<CompProperties>();
                    tDef.comps.Add(new CompProperties(typeof(CompProjectileVerbCache)));
                }
            }
        }
    }
}

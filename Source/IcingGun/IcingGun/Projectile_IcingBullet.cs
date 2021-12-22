using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Verse;

namespace IcingGun
{
    class Projectile_IcingBullet : RimWorld.Bullet
    {
        public ModExtension_IcingBullet Props => def.GetModExtension<ModExtension_IcingBullet>();

        protected override void Impact(Verse.Thing hitThing)
        {
            base.Impact(hitThing);
            if (Props != null && hitThing != null && hitThing is Verse.Pawn hitPawn)
            {
                float rand = Verse.Rand.Value;
                if (rand <= Props.addHediffChance)
                {
                    Verse.Messages.Message("TST_PlagueBullet_SuccessMessage".Translate(
                        this.launcher.Label, hitPawn.Label
                    ), RimWorld.MessageTypeDefOf.NeutralEvent);
                    Verse.Hediff icingOnPawn = hitPawn.health?.hediffSet?.GetFirstHediffOfDef(Props.hediffToAdd);

                    float randomSeverity = Verse.Rand.Range(0.15f, 0.30f);
                    if (icingOnPawn != null)
                    {
                        icingOnPawn.Severity += randomSeverity;
                    } else
                    {
                        Verse.Hediff hediff = Verse.HediffMaker.MakeHediff(Props.hediffToAdd, hitPawn);
                        hediff.Severity = randomSeverity;
                        hitPawn.health.AddHediff(hediff);
                    }
                } else
                {
                    RimWorld.MoteMaker.ThrowText(hitThing.PositionHeld.ToVector3(), hitThing.MapHeld, "IcingBullet_FailureMote".Translate(Props.addHediffChance), 12f);
                }
            }
        }
    }
}

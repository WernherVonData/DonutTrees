using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RimWorld;
using Verse;

namespace HelloWorld
{
    [StaticConstructorOnStartup]
    public static class Hello
    {
        static Hello()
        {
            Log.Message("Hello Rimworld");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SatsumaSoundCustomizer
{
    public static class Exhaust
    {
        public static void Mod_OnLoad()
        {

        }

        public static void ExhaustSoundChange()
        {
            GameObject exhaustPipe = GameObject.Find("SATSUMA(557kg, 248)/MiscParts/pivot_exhaust pipe/exhaust pipe(Clone)");
            GameObject exhaustMuffler = GameObject.Find("SATSUMA(557kg, 248)/MiscParts/pivot_exhaust_muffler/exhaust muffler(Clone)");

        }

    }
}

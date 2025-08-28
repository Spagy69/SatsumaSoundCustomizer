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
            GameObject headers = GameObject.Find("SATSUMA(557kg, 248)/Chassis/sub frame(xxxxx)/CarMotorPivot/block(Clone)/pivot_cylinder head/cylinder head(Clone)/pivot_headers/headers(Clone)");
            GameObject stockPipe = GameObject.Find("SATSUMA(557kg, 248)/MiscParts/pivot_exhaust pipe/exhaust pipe(Clone)");
            GameObject stockMuffler = GameObject.Find("SATSUMA(557kg, 248)/MiscParts/pivot_exhaust_muffler/exhaust muffler(Clone)");
            GameObject steelHeaders = GameObject.Find("SATSUMA(557kg, 248)/Chassis/sub frame(xxxxx)/CarMotorPivot/block(Clone)/pivot_cylinder head/cylinder head(Clone)/pivot_headers/steel headers(Clone)");
            GameObject racingPipe = GameObject.Find("SATSUMA(557kg, 248)/MiscParts/pivot_exhaust pipe/racing exhaust(Clone)");
            GameObject racingMuffler = GameObject.Find("SATSUMA(557kg, 248)/MiscParts/pivot_exhaust_muffler/racing muffler(Clone)");
        }

    }
}

using MSCLoader;
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
            AudioSource fromMuffler = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Exhaust/FromMuffler").GetComponent<AudioSource>();
            AudioSource fromHeaders = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Exhaust/FromHeaders").GetComponent<AudioSource>();
            AudioSource fromPipe = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Exhaust/FromPipe").GetComponent<AudioSource>();
            AudioSource fromCylinderHead = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Exhaust/FromEngine").GetComponent<AudioSource>();
        }

        public static void ExhaustSoundChange()
        {
            GameObject headers = GameObject.Find("SATSUMA(557kg, 248)/Chassis/sub frame(xxxxx)/CarMotorPivot/block(Clone)/pivot_cylinder head/cylinder head(Clone)/pivot_headers/headers(Clone)");
            GameObject stockPipe = GameObject.Find("SATSUMA(557kg, 248)/MiscParts/pivot_exhaust pipe/exhaust pipe(Clone)");
            GameObject stockMuffler = GameObject.Find("SATSUMA(557kg, 248)/MiscParts/pivot_exhaust_muffler/exhaust muffler(Clone)");
            GameObject steelHeaders = GameObject.Find("SATSUMA(557kg, 248)/Chassis/sub frame(xxxxx)/CarMotorPivot/block(Clone)/pivot_cylinder head/cylinder head(Clone)/pivot_headers/steel headers(Clone)");
            GameObject racingPipe = GameObject.Find("SATSUMA(557kg, 248)/MiscParts/pivot_exhaust pipe/racing exhaust(Clone)");
            GameObject racingMuffler = GameObject.Find("SATSUMA(557kg, 248)/MiscParts/pivot_exhaust_muffler/racing muffler(Clone)");

            if (headers != null)
            {
                ModConsole.Print("headers found!");
            }
            else if (steelHeaders != null)
            {
                ModConsole.Print("steel headers found!");
            }

            if (stockPipe != null)
            {
                ModConsole.Print("stock pipe found!");
            }
            else if (racingPipe != null)
            {
                ModConsole.Print("racing pipe found!");
            }

            if (stockMuffler != null)
            {
                ModConsole.Print("stock muffler found!");
            }
            else if (racingMuffler != null)
            {
                ModConsole.Print("racing muffler found!");
            }

        }

    }
}

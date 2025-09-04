using MSCLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace SatsumaSoundCustomizer
{
    public static class Exhaust
    {
        public static AudioClip cylinderHeadSound;
        public static AudioClip headersSound;
        public static AudioClip steelHeadersSound;
        public static AudioClip stockPipeSound;
        public static AudioClip racingPipeSound;
        public static AudioClip stockMufflerSound;
        public static AudioClip racingMufflerSound;

        public static GameObject fromMuffler;
        public static GameObject fromHeaders;
        public static GameObject fromPipe;
        public static GameObject fromCylinderHead;

        public static AudioSource fromMufflerAudio;
        public static AudioSource fromHeadersAudio;
        public static AudioSource fromPipeAudio;
        public static AudioSource fromCylinderHeadAudio;

        public static void Mod_OnLoad()
        {
            fromMuffler = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Exhaust/FromMuffler");
            fromHeaders = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Exhaust/FromHeaders");
            fromPipe = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Exhaust/FromPipe");
            fromCylinderHead = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Exhaust/FromEngine");

            fromMufflerAudio = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Exhaust/FromMuffler").GetComponent<AudioSource>();
            fromHeadersAudio = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Exhaust/FromHeaders").GetComponent<AudioSource>();
            fromPipeAudio = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Exhaust/FromPipe").GetComponent<AudioSource>();
            fromCylinderHeadAudio = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Exhaust/FromEngine").GetComponent<AudioSource>();

            cylinderHeadSound = LoadAudioClipSafe("cylinderHead.wav", "cylinderHead");
            headersSound = LoadAudioClipSafe("headers.wav", "headers");
            steelHeadersSound = LoadAudioClipSafe("steelHeaders.wav", "steelHeaders");
            stockPipeSound = LoadAudioClipSafe("stockPipe.wav", "stockPipe");
            racingPipeSound = LoadAudioClipSafe("racingPipe.wav", "racingPipe");
            stockMufflerSound = LoadAudioClipSafe("stockMuffler.wav", "stockMuffler");
            racingMufflerSound = LoadAudioClipSafe("racingMuffler.wav", "racingMuffler");
        }

        public static void ExhaustSoundChange()
        {
            GameObject cylinderHead = GameObject.Find("SATSUMA(557kg, 248)/Chassis/sub frame(xxxxx)/CarMotorPivot/block(Clone)/pivot_cylinder head/cylinder head(Clone)");
            GameObject headers = GameObject.Find("SATSUMA(557kg, 248)/Chassis/sub frame(xxxxx)/CarMotorPivot/block(Clone)/pivot_cylinder head/cylinder head(Clone)/pivot_headers/headers(Clone)");
            GameObject stockPipe = GameObject.Find("SATSUMA(557kg, 248)/MiscParts/pivot_exhaust pipe/exhaust pipe(Clone)");
            GameObject stockMuffler = GameObject.Find("SATSUMA(557kg, 248)/MiscParts/pivot_exhaust_muffler/exhaust muffler(Clone)");
            GameObject steelHeaders = GameObject.Find("SATSUMA(557kg, 248)/Chassis/sub frame(xxxxx)/CarMotorPivot/block(Clone)/pivot_cylinder head/cylinder head(Clone)/pivot_headers/steel headers(Clone)");
            GameObject racingPipe = GameObject.Find("SATSUMA(557kg, 248)/MiscParts/pivot_exhaust pipe/racing exhaust(Clone)");
            GameObject racingMuffler = GameObject.Find("SATSUMA(557kg, 248)/MiscParts/pivot_exhaust_muffler/racing muffler(Clone)");

            if (cylinderHead != null)
            {
                if (fromCylinderHeadAudio != null)
                {
                    fromCylinderHeadAudio.clip = cylinderHeadSound;
                    fromCylinderHeadAudio.pitch = SatsumaSoundCustomizer.enginePitchFloat;
                    fromCylinderHeadAudio.volume = SatsumaSoundCustomizer.engineVolumeFloat;
                    fromCylinderHeadAudio.Play();
                }
                ModConsole.Print("cylinder head found!");
            }

            if (headers != null)
            {
                if (fromHeadersAudio != null)
                {
                    fromHeadersAudio.clip = headersSound;
                    fromHeadersAudio.pitch = SatsumaSoundCustomizer.stockHeadersPitchFloat;
                    fromHeadersAudio.volume = SatsumaSoundCustomizer.stockHeadersVolumeFloat;
                    fromHeadersAudio.Play();
                }
                ModConsole.Print("headers found!");
            }
            else if (steelHeaders != null)
            {
                if (fromHeadersAudio != null)
                {
                    fromHeadersAudio.clip = steelHeadersSound;
                    fromHeadersAudio.pitch = SatsumaSoundCustomizer.racingHeadersPitchFloat;
                    fromHeadersAudio.volume = SatsumaSoundCustomizer.racingHeadersVolumeFloat;
                    fromHeadersAudio.Play();
                }
                ModConsole.Print("steel headers found!");
            }

            if (stockPipe != null)
            {
                if (fromPipeAudio != null)
                {
                    fromPipeAudio.clip = stockPipeSound;
                    fromPipeAudio.pitch = SatsumaSoundCustomizer.stockPipePitchFloat;
                    fromPipeAudio.volume = SatsumaSoundCustomizer.stockPipeVolumeFloat;
                    fromPipeAudio.Play();
                }
                ModConsole.Print("stock pipe found!");
            }
            else if (racingPipe != null)
            {
                if (fromPipeAudio != null)
                {
                    fromPipeAudio.clip = racingPipeSound;
                    fromPipeAudio.pitch = SatsumaSoundCustomizer.racingPipePitchFloat;
                    fromPipeAudio.volume = SatsumaSoundCustomizer.racingPipeVolumeFloat;
                    fromPipeAudio.Play();
                }
                ModConsole.Print("racing pipe found!");
            }

            if (stockMuffler != null)
            {
                if (fromMufflerAudio != null)
                {
                    fromMufflerAudio.clip = stockMufflerSound;
                    fromMufflerAudio.pitch = SatsumaSoundCustomizer.stockMufflerPitchFloat;
                    fromMufflerAudio.volume = SatsumaSoundCustomizer.stockMufflerVolumeFloat;
                    fromMufflerAudio.Play();
                }
                ModConsole.Print("stock muffler found!");
            }
            else if (racingMuffler != null)
            {
                if (fromMufflerAudio != null)
                {
                    fromMufflerAudio.clip = racingMufflerSound;
                    fromMufflerAudio.pitch = SatsumaSoundCustomizer.racingMufflerPitchFloat;
                    fromMufflerAudio.volume = SatsumaSoundCustomizer.racingMufflerVolumeFloat;
                    fromMufflerAudio.Play();
                }
                ModConsole.Print("racing muffler found!");
            }
        }

        public static AudioClip LoadAudioClipSafe(string fileName, string clipName)
        {
            try
            {
                string path = Path.Combine(ModLoader.GetModAssetsFolder(SatsumaSoundCustomizer.instanceMod), fileName);
                return WavUtility.ToAudioClip(path, clipName);
            }
            catch (Exception)
            {
                ModConsole.Error($"Error loading {fileName}");
                return null;
            }
        }
    }
}

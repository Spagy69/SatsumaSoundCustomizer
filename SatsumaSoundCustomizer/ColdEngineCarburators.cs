using MSCLoader;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

namespace SatsumaSoundCustomizer
{

    public static class ColdEngineCarburators
    {
        public static GameObject carburator;
        public static GameObject twinCarburators;
        public static GameObject racingCarburators;
        public static GameObject satsuma;
        public static SoundController satsumaSoundController;
        public static Transform engineGas;
        public static Transform engineGasRelease;
        public static AudioSource engineGasAudio;
        public static AudioSource engineGasReleaseAudio;
        public static AudioClip coldEngineStockCarbThrottleSound;
        public static AudioClip coldEngineTwinCarbThrottleSound;
        public static AudioClip coldEngineRacingCarbThrottleSound;
        public static AudioClip coldEngineStockCarbNoThrottleSound;
        public static AudioClip coldEngineTwinCarbNoThrottleSound;
        public static AudioClip coldEngineRacingCarbNoThrottleSound;
        public static void Mod_OnLoad()
        {

            satsuma = GameObject.Find("SATSUMA(557kg, 248)");
            satsumaSoundController = satsuma.GetComponent<SoundController>();

            engineGas = GameObject.Find("SATSUMA(557kg, 248)").transform.GetChild(40);
            engineGasRelease = GameObject.Find("SATSUMA(557kg, 248)").transform.GetChild(41);

            engineGasAudio = engineGas.GetComponent<AudioSource>();
            engineGasReleaseAudio = engineGasRelease.GetComponent<AudioSource>();


            coldEngineStockCarbThrottleSound = LoadAudioClipSafe("coldEngineStockCarbThrottle.wav", "coldEngineStockCarbThrottle");
            coldEngineTwinCarbThrottleSound = LoadAudioClipSafe("coldEngineTwinCarbThrottle.wav", "coldEngineTwinCarbThrottle");
            coldEngineRacingCarbThrottleSound = LoadAudioClipSafe("coldEngineRacingCarbThrottle.wav", "coldEngineRacingCarbThrottle");

            coldEngineStockCarbNoThrottleSound = LoadAudioClipSafe("coldEngineStockCarbNoThrottle.wav", "coldEngineStockCarbNoThrottle");
            coldEngineTwinCarbNoThrottleSound = LoadAudioClipSafe("coldEngineTwinCarbNoThrottle.wav", "coldEngineTwinCarbNoThrottle");
            coldEngineRacingCarbNoThrottleSound = LoadAudioClipSafe("coldEngineRacingCarbNoThrottle.wav", "coldEngineRacingCarbNoThrottle");

        }

        public static void ColdEngineCarburatorsSounds()
        {
            carburator = GameObject.Find("SATSUMA(557kg, 248)/Chassis/sub frame(xxxxx)/CarMotorPivot/block(Clone)/pivot_cylinder head/cylinder head(Clone)/pivot_carburator/carburator(Clone)");
            twinCarburators = GameObject.Find("SATSUMA(557kg, 248)/Chassis/sub frame(xxxxx)/CarMotorPivot/block(Clone)/pivot_cylinder head/cylinder head(Clone)/pivot_carburator/twin carburators(Clone)");
            racingCarburators = GameObject.Find("SATSUMA(557kg, 248)/Chassis/sub frame(xxxxx)/CarMotorPivot/block(Clone)/pivot_cylinder head/cylinder head(Clone)/pivot_carburator/racing carburators(Clone)");



            if (carburator != null)
            {
                engineGasAudio.clip = coldEngineStockCarbThrottleSound;
                engineGasReleaseAudio.clip = coldEngineStockCarbNoThrottleSound;

                satsumaSoundController.engineThrottlePitchFactor = SatsumaSoundCustomizer.coldEngineStockCarbThrottlePitchFloat;
                satsumaSoundController.engineThrottleVolume = SatsumaSoundCustomizer.coldEngineStockCarbThrottleVolumeFloat;

                satsumaSoundController.engineNoThrottlePitchFactor = SatsumaSoundCustomizer.coldEngineStockCarbNoThrottlePitchFloat;
                satsumaSoundController.engineNoThrottleVolume = SatsumaSoundCustomizer.coldEngineStockCarbNoThrottleVolumeFloat;

                engineGasAudio.Play();
                engineGasReleaseAudio.Play();
                ModConsole.Print("Carburator found! (cold)");
            }
            else if (twinCarburators != null)
            {
                engineGasAudio.clip = coldEngineTwinCarbThrottleSound;
                engineGasReleaseAudio.clip = coldEngineTwinCarbNoThrottleSound;

                satsumaSoundController.engineThrottlePitchFactor = SatsumaSoundCustomizer.coldEngineTwinCarbThrottlePitchFloat;
                satsumaSoundController.engineThrottleVolume = SatsumaSoundCustomizer.coldEngineTwinCarbThrottleVolumeFloat;

                satsumaSoundController.engineNoThrottlePitchFactor = SatsumaSoundCustomizer.coldEngineTwinCarbNoThrottlePitchFloat;
                satsumaSoundController.engineNoThrottleVolume = SatsumaSoundCustomizer.coldEngineTwinCarbNoThrottleVolumeFloat;

                engineGasAudio.Play();
                engineGasReleaseAudio.Play();
                ModConsole.Print("twin Carburator found! (cold)");
            }
            else if (racingCarburators != null)
            {
                engineGasAudio.clip = coldEngineRacingCarbThrottleSound;
                engineGasReleaseAudio.clip = coldEngineRacingCarbNoThrottleSound;

                satsumaSoundController.engineThrottlePitchFactor = SatsumaSoundCustomizer.coldEngineRacingCarbThrottlePitchFloat;
                satsumaSoundController.engineThrottleVolume = SatsumaSoundCustomizer.coldEngineRacingCarbThrottleVolumeFloat;

                satsumaSoundController.engineNoThrottlePitchFactor = SatsumaSoundCustomizer.coldEngineRacingCarbNoThrottlePitchFloat;
                satsumaSoundController.engineNoThrottleVolume = SatsumaSoundCustomizer.coldEngineRacingCarbNoThrottleVolumeFloat;

                engineGasAudio.Play();
                engineGasReleaseAudio.Play();
                ModConsole.Print("racing carburator found! (cold)");
            }
            else
            {
                ModConsole.Print("No carburetor was found");
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

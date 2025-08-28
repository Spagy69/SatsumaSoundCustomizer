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

    public static class WarmEngineCarburators
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
        public static AudioClip warmEngineStockCarbThrottleSound;
        public static AudioClip warmEngineTwinCarbThrottleSound;
        public static AudioClip warmEngineRacingCarbThrottleSound;
        public static AudioClip warmEngineStockCarbNoThrottleSound;
        public static AudioClip warmEngineTwinCarbNoThrottleSound;
        public static AudioClip warmEngineRacingCarbNoThrottleSound;
        public static void Mod_OnLoad()
        {

            satsuma = GameObject.Find("SATSUMA(557kg, 248)");
            satsumaSoundController = satsuma.GetComponent<SoundController>();

            engineGas = GameObject.Find("SATSUMA(557kg, 248)").transform.GetChild(40);
            engineGasRelease = GameObject.Find("SATSUMA(557kg, 248)").transform.GetChild(41);

            engineGasAudio = engineGas.GetComponent<AudioSource>();
            engineGasReleaseAudio = engineGasRelease.GetComponent<AudioSource>();


            warmEngineStockCarbThrottleSound = LoadAudioClipSafe("warmEngineStockCarbThrottle.wav", "warmEngineStockCarbThrottle");
            warmEngineTwinCarbThrottleSound = LoadAudioClipSafe("warmEngineTwinCarbThrottle.wav", "warmEngineTwinCarbThrottle");
            warmEngineRacingCarbThrottleSound = LoadAudioClipSafe("warmEngineRacingCarbThrottle.wav", "warmEngineRacingCarbThrottle");
            warmEngineStockCarbNoThrottleSound = LoadAudioClipSafe("warmEngineStockCarbNoThrottle.wav", "warmEngineStockCarbNoThrottle");
            warmEngineTwinCarbNoThrottleSound = LoadAudioClipSafe("warmEngineTwinCarbNoThrottle.wav", "warmEngineTwinCarbNoThrottle");
            warmEngineRacingCarbNoThrottleSound = LoadAudioClipSafe("warmEngineRacingCarbNoThrottle.wav", "warmEngineRacingCarbNoThrottle");

        }

        public static void WarmEngineCarburatorsSounds()
        {
            carburator = GameObject.Find("SATSUMA(557kg, 248)/Chassis/sub frame(xxxxx)/CarMotorPivot/block(Clone)/pivot_cylinder head/cylinder head(Clone)/pivot_carburator/carburator(Clone)");
            twinCarburators = GameObject.Find("SATSUMA(557kg, 248)/Chassis/sub frame(xxxxx)/CarMotorPivot/block(Clone)/pivot_cylinder head/cylinder head(Clone)/pivot_carburator/twin carburators(Clone)");
            racingCarburators = GameObject.Find("SATSUMA(557kg, 248)/Chassis/sub frame(xxxxx)/CarMotorPivot/block(Clone)/pivot_cylinder head/cylinder head(Clone)/pivot_carburator/racing carburators(Clone)");



            if (carburator != null)
            {
                engineGasAudio.clip = warmEngineStockCarbThrottleSound;
                engineGasReleaseAudio.clip = warmEngineStockCarbNoThrottleSound;

                satsumaSoundController.engineThrottlePitchFactor = SatsumaSoundCustomizer.warmEngineStockCarbThrottlePitchFloat;
                satsumaSoundController.engineThrottleVolume = SatsumaSoundCustomizer.warmEngineStockCarbThrottleVolumeFloat;

                satsumaSoundController.engineNoThrottlePitchFactor = SatsumaSoundCustomizer.warmEngineStockCarbNoThrottlePitchFloat;
                satsumaSoundController.engineNoThrottleVolume = SatsumaSoundCustomizer.warmEngineStockCarbNoThrottleVolumeFloat;

                engineGasAudio.Play();
                engineGasReleaseAudio.Play();
                ModConsole.Print("Carburator found! (warm)");
            }
            else if (twinCarburators != null)
            {
                engineGasAudio.clip = warmEngineTwinCarbThrottleSound;
                engineGasReleaseAudio.clip = warmEngineTwinCarbNoThrottleSound;

                satsumaSoundController.engineThrottlePitchFactor = SatsumaSoundCustomizer.warmEngineTwinCarbThrottlePitchFloat;
                satsumaSoundController.engineThrottleVolume = SatsumaSoundCustomizer.warmEngineTwinCarbThrottleVolumeFloat;

                satsumaSoundController.engineNoThrottlePitchFactor = SatsumaSoundCustomizer.warmEngineTwinCarbNoThrottlePitchFloat;
                satsumaSoundController.engineNoThrottleVolume = SatsumaSoundCustomizer.warmEngineTwinCarbNoThrottleVolumeFloat;

                engineGasAudio.Play();
                engineGasReleaseAudio.Play();
                ModConsole.Print("twin Carburator found! (warm)");
            }
            else if (racingCarburators != null)
            {
                engineGasAudio.clip = warmEngineRacingCarbThrottleSound;
                engineGasReleaseAudio.clip = warmEngineRacingCarbNoThrottleSound;

                satsumaSoundController.engineThrottlePitchFactor = SatsumaSoundCustomizer.warmEngineRacingCarbThrottlePitchFloat;
                satsumaSoundController.engineThrottleVolume = SatsumaSoundCustomizer.warmEngineRacingCarbThrottleVolumeFloat;

                satsumaSoundController.engineNoThrottlePitchFactor = SatsumaSoundCustomizer.warmEngineRacingCarbNoThrottlePitchFloat;
                satsumaSoundController.engineNoThrottleVolume = SatsumaSoundCustomizer.warmEngineRacingCarbNoThrottleVolumeFloat;

                engineGasAudio.Play();
                engineGasReleaseAudio.Play();
                ModConsole.Print("racing carburator found! (warm)");
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

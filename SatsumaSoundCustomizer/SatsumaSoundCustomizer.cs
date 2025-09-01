using HutongGames.PlayMaker.Actions;
using JetBrains.Annotations;
using MSCLoader;
using Steamworks;
using TanjentOGG;
using UnityEngine;

namespace SatsumaSoundCustomizer
{
    public class SatsumaSoundCustomizer : Mod
    {
        public override string ID => "SatsumaSoundCustomizer"; // Your (unique) mod ID 
        public override string Name => "Satsuma Sound Customizer"; // Your mod name
        public override string Author => "Spagy"; // Name of the Author (your name)
        public override string Version => "3.0"; // Version
        public override string Description => "Customizes Satsuma's engine sounds based on carburetor type and engine temperature"; // Short description of your mod

        public static SatsumaSoundCustomizer instanceMod;
        
        private Transform engineGas;
        private Transform engineGasRelease;
        private Transform transmission;
        private Transform brakes;

        private GameObject fromMufflerExhaust;
        private GameObject fromHeadersExhaust;
        private GameObject fromPipeExhaust;
        private GameObject fromEngineExhaust;
        private GameObject exhaustGameObject;

        private GameObject coolingSatsuma;
        private PlayMakerFSM coolingFsm;
        public static float coolantTemp;
        private bool coldStartSettingBool;
        private bool coldLoop;
        private bool repeatOrNot;

        public static SettingsCheckBox coldStartSetting;

        public static SettingsSlider coldEngineStockCarbThrottlePitch;
        public static SettingsSlider coldEngineStockCarbThrottleVolume;
        public static SettingsSlider coldEngineStockCarbNoThrottlePitch;
        public static SettingsSlider coldEngineStockCarbNoThrottleVolume;

        public static SettingsSlider coldEngineTwinCarbThrottlePitch;
        public static SettingsSlider coldEngineTwinCarbThrottleVolume;
        public static SettingsSlider coldEngineTwinCarbNoThrottlePitch;
        public static SettingsSlider coldEngineTwinCarbNoThrottleVolume;

        public static SettingsSlider coldEngineRacingCarbThrottlePitch;
        public static SettingsSlider coldEngineRacingCarbThrottleVolume;
        public static SettingsSlider coldEngineRacingCarbNoThrottlePitch;
        public static SettingsSlider coldEngineRacingCarbNoThrottleVolume;

        public static SettingsSlider warmEngineStockCarbThrottlePitch;
        public static SettingsSlider warmEngineStockCarbThrottleVolume;
        public static SettingsSlider warmEngineStockCarbNoThrottlePitch;
        public static SettingsSlider warmEngineStockCarbNoThrottleVolume;

        public static SettingsSlider warmEngineTwinCarbThrottlePitch;
        public static SettingsSlider warmEngineTwinCarbThrottleVolume;
        public static SettingsSlider warmEngineTwinCarbNoThrottlePitch;
        public static SettingsSlider warmEngineTwinCarbNoThrottleVolume;

        public static SettingsSlider warmEngineRacingCarbThrottlePitch;
        public static SettingsSlider warmEngineRacingCarbThrottleVolume;
        public static SettingsSlider warmEngineRacingCarbNoThrottlePitch;
        public static SettingsSlider warmEngineRacingCarbNoThrottleVolume;

        public static SettingsSlider enginePitch;
        public static SettingsSlider engineVolume;

        public static SettingsSlider stockHeadersPitch;
        public static SettingsSlider stockHeadersVolume;
        public static SettingsSlider stockPipePitch;
        public static SettingsSlider stockPipeVolume;
        public static SettingsSlider stockMufflerPitch;
        public static SettingsSlider stockMufflerVolume;

        public static SettingsSlider racingHeadersPitch;
        public static SettingsSlider racingHeadersVolume;
        public static SettingsSlider racingPipePitch;
        public static SettingsSlider racingPipeVolume;
        public static SettingsSlider racingMufflerPitch;
        public static SettingsSlider racingMufflerVolume;



        public static float coldEngineStockCarbThrottlePitchFloat;
        public static float coldEngineStockCarbThrottleVolumeFloat;
        public static float coldEngineStockCarbNoThrottlePitchFloat;
        public static float coldEngineStockCarbNoThrottleVolumeFloat;

        public static float coldEngineTwinCarbThrottlePitchFloat;
        public static float coldEngineTwinCarbThrottleVolumeFloat;
        public static float coldEngineTwinCarbNoThrottlePitchFloat;
        public static float coldEngineTwinCarbNoThrottleVolumeFloat;

        public static float coldEngineRacingCarbThrottlePitchFloat;
        public static float coldEngineRacingCarbThrottleVolumeFloat;
        public static float coldEngineRacingCarbNoThrottlePitchFloat;
        public static float coldEngineRacingCarbNoThrottleVolumeFloat;

        public static float warmEngineStockCarbThrottlePitchFloat;
        public static float warmEngineStockCarbThrottleVolumeFloat;
        public static float warmEngineStockCarbNoThrottlePitchFloat;
        public static float warmEngineStockCarbNoThrottleVolumeFloat;

        public static float warmEngineTwinCarbThrottlePitchFloat;
        public static float warmEngineTwinCarbThrottleVolumeFloat;
        public static float warmEngineTwinCarbNoThrottlePitchFloat;
        public static float warmEngineTwinCarbNoThrottleVolumeFloat;

        public static float warmEngineRacingCarbThrottlePitchFloat;
        public static float warmEngineRacingCarbThrottleVolumeFloat;
        public static float warmEngineRacingCarbNoThrottlePitchFloat;
        public static float warmEngineRacingCarbNoThrottleVolumeFloat;


        private GameObject powerOn;

        private float activeTimer;
        private float activeTimer1;

        private bool startedOrNot;
        private bool proccesCanRepeat;
        public override void ModSetup()
        {
            SetupFunction(Setup.OnMenuLoad, Mod_OnMenuLoad);
            SetupFunction(Setup.OnNewGame, Mod_OnNewGame);
            SetupFunction(Setup.PreLoad, Mod_PreLoad);
            SetupFunction(Setup.OnLoad, Mod_OnLoad);
            SetupFunction(Setup.PostLoad, Mod_PostLoad);
            SetupFunction(Setup.OnSave, Mod_OnSave);
            SetupFunction(Setup.OnGUI, Mod_OnGUI);
            SetupFunction(Setup.Update, Mod_Update);
            SetupFunction(Setup.FixedUpdate, Mod_FixedUpdate);
            SetupFunction(Setup.ModSettings, Mod_Settings);
        }

        private void Mod_Settings()
        {

            Settings.AddHeader("Custom sounds");
            Settings.AddText(this, "<color=red><b><size=30>Changing the pitch is highly recommended!</size></b></color>");
            Settings.AddText(this, "");

            enginePitch = Settings.AddSlider(this, "enginePitchSlider", "Cylinder head pitch", 0f, 3.0f, 1.0f);
            engineVolume = Settings.AddSlider(this, "engineVolumeSlider", "Cylinder head volume", 0f, 3.0f, 1.0f);
            Settings.AddText(this, "");

            Settings.AddText(this, "<b>Stock exhaust:</b>");
            stockHeadersPitch = Settings.AddSlider(this, "stockHeadersPitchSlider", "Stock headers pitch", 0f, 3.0f, 1.0f);
            stockHeadersVolume = Settings.AddSlider(this, "stockHeadersVolumeSlider", "Stock headers volume", 0f, 3.0f, 1.0f);
            Settings.AddText(this, "");

            stockPipePitch = Settings.AddSlider(this, "stockPipePitchSlider", "Stock pipe pitch", 0f, 3.0f, 1.0f);
            stockPipeVolume = Settings.AddSlider(this, "stockPipeVolumeSlider", "Stock pipe volume", 0f, 3.0f, 1.0f);
            Settings.AddText(this, "");

            stockMufflerPitch = Settings.AddSlider(this, "stockMufflerPitchSlider", "Stock muffler pitch", 0f, 3.0f, 1.0f);
            stockMufflerVolume = Settings.AddSlider(this, "stockMufflerVolumeSlider", "Stock muffler volume", 0f, 3.0f, 1.0f);
            Settings.AddText(this, "");

            Settings.AddText(this, "<b>Racing exhaust:</b>");
            racingHeadersPitch = Settings.AddSlider(this, "racingHeadersPitchSlider", "Steel headers pitch", 0f, 3.0f, 1.0f);
            racingHeadersVolume = Settings.AddSlider(this, "racingHeadersVolumeSlider", "Steel headers volume", 0f, 3.0f, 1.0f);
            Settings.AddText(this, "");

            racingPipePitch = Settings.AddSlider(this, "racingPipePitchSlider", "Racing pipe pitch", 0f, 3.0f, 1.0f);
            racingPipeVolume = Settings.AddSlider(this, "racingPipeVolumeSlider", "Racing pipe volume", 0f, 3.0f, 1.0f);
            Settings.AddText(this, "");

            racingMufflerPitch = Settings.AddSlider(this, "racingMufflerPitchSlider", "Racing muffler pitch", 0f, 3.0f, 1.0f);
            racingMufflerVolume = Settings.AddSlider(this, "racingMufflerVolumeSlider", "Racing muffler volume", 0f, 3.0f, 1.0f);
            Settings.AddText(this, "");


            Settings.AddText(this, "<b><size=25>Cold engine settings:</size></b>");
            coldStartSetting = Settings.AddCheckBox("coldStartSetting", "Cold start", true);
            Settings.AddText(this, "(Plays a unique engine sound when starting from a cold state.)");
            Settings.AddText(this, "");

            Settings.AddText(this, "<b>Stock carburetor:</b>");
            coldEngineStockCarbThrottlePitch = Settings.AddSlider(this, "coldEngineStockCarbThrottlePitchSlider", "Cold engine Throttle pitch (Stock carburetor)", 0f, 3.0f, 1.0f);
            coldEngineStockCarbThrottleVolume = Settings.AddSlider(this, "coldEngineStockCarbThrottleVolumeSlider", "Cold engine Throttle volume (Stock carburetor)", 0f, 3.0f, 1.0f);
            coldEngineStockCarbNoThrottlePitch = Settings.AddSlider(this, "coldEngineStockCarbNoThrottlePitchSlider", "Cold engine No Throttle pitch (Stock carburetor)", 0f, 3.0f, 1.0f);
            coldEngineStockCarbNoThrottleVolume = Settings.AddSlider(this, "coldEngineStockCarbNoThrottleVolumeSlider", "Cold engine No Throttle volume (Stock carburetor)", 0f, 3.0f, 1.0f);
            Settings.AddText(this, "");

            Settings.AddText(this, "<b>Twin carburetors:</b>");
            coldEngineTwinCarbThrottlePitch = Settings.AddSlider(this, "coldEngineTwinCarbThrottlePitchSlider", "Cold engine Throttle pitch (Twin carburetors)", 0f, 3.0f, 1.0f);
            coldEngineTwinCarbThrottleVolume = Settings.AddSlider(this, "coldEngineTwinCarbThrottleVolumeSlider", "Cold engine Throttle volume (Twin carburetors)", 0f, 3.0f, 1.0f);
            coldEngineTwinCarbNoThrottlePitch = Settings.AddSlider(this, "coldEngineTwinCarbNoThrottlePitchSlider", "Cold engine No Throttle pitch (Twin carburetors)", 0f, 3.0f, 1.0f);
            coldEngineTwinCarbNoThrottleVolume = Settings.AddSlider(this, "coldEngineTwinCarbNoThrottleVolumeSlider", "Cold engine No Throttle volume (Twin carburetors)", 0f, 3.0f, 1.0f);
            Settings.AddText(this, "");

            Settings.AddText(this, "<b>Racing carburetors:</b>");
            coldEngineRacingCarbThrottlePitch = Settings.AddSlider(this, "coldEngineRacingCarbThrottlePitchSlider", "Cold engine Throttle pitch (Racing carburetors)", 0f, 3.0f, 1.0f);
            coldEngineRacingCarbThrottleVolume = Settings.AddSlider(this, "coldEngineRacingCarbThrottleVolumeSlider", "Cold engine Throttle volume (Racing carburetors)", 0f, 3.0f, 1.0f);
            coldEngineRacingCarbNoThrottlePitch = Settings.AddSlider(this, "coldEngineRacingCarbNoThrottlePitchSlider", "Cold engine No Throttle pitch (Racing carburetors)", 0f, 3.0f, 1.0f);
            coldEngineRacingCarbNoThrottleVolume = Settings.AddSlider(this, "coldEngineRacingCarbNoThrottleVolumeSlider", "Cold engine No Throttle volume (Racing carburetors)", 0f, 3.0f, 1.0f);
            Settings.AddText(this, "");

            Settings.AddText(this, "<b><size=25>Warm engine settings:</size></b>");
            Settings.AddText(this, "<i>Required for proper sound transition when cold start is enabled. If cold start is disabled, these settings will still apply to the regular engine sounds.</i>");
            Settings.AddText(this, "");

            Settings.AddText(this, "<b>Stock carburetor:</b>");
            warmEngineStockCarbThrottlePitch = Settings.AddSlider(this, "warmEngineStockCarbThrottlePitchSlider", "Warm engine Throttle pitch (Stock carburetor)", 0f, 3.0f, 1.0f);
            warmEngineStockCarbThrottleVolume = Settings.AddSlider(this, "warmEngineStockCarbThrottleVolumeSlider", "Warm engine Throttle volume (Stock carburetor)", 0f, 3.0f, 1.0f);
            warmEngineStockCarbNoThrottlePitch = Settings.AddSlider(this, "warmEngineStockCarbNoThrottlePitchSlider", "Warm engine No Throttle pitch (Stock carburetor)", 0f, 3.0f, 1.0f);
            warmEngineStockCarbNoThrottleVolume = Settings.AddSlider(this, "warmEngineStockCarbNoThrottleVolumeSlider", "Warm engine No Throttle volume (Stock carburetor)", 0f, 3.0f, 1.0f);
            Settings.AddText(this, "");

            Settings.AddText(this, "<b>Twin carburetors:</b>");
            warmEngineTwinCarbThrottlePitch = Settings.AddSlider(this, "warmEngineTwinCarbThrottlePitchSlider", "Warm engine Throttle pitch (Twin carburetors)", 0f, 3.0f, 1.0f);
            warmEngineTwinCarbThrottleVolume = Settings.AddSlider(this, "warmEngineTwinCarbThrottleVolumeSlider", "Warm engine Throttle volume (Twin carburetors)", 0f, 3.0f, 1.0f);
            warmEngineTwinCarbNoThrottlePitch = Settings.AddSlider(this, "warmEngineTwinCarbNoThrottlePitchSlider", "Warm engine No Throttle pitch (Twin carburetors)", 0f, 3.0f, 1.0f);
            warmEngineTwinCarbNoThrottleVolume = Settings.AddSlider(this, "warmEngineTwinCarbNoThrottleVolumeSlider", "Warm engine No Throttle volume (Twin carburetors)", 0f, 3.0f, 1.0f);
            Settings.AddText(this, "");

            Settings.AddText(this, "<b>Racing carburetors:</b>");
            warmEngineRacingCarbThrottlePitch = Settings.AddSlider(this, "warmEngineRacingCarbThrottlePitchSlider", "Warm engine Throttle pitch (Racing carburetors)", 0f, 3.0f, 1.0f);
            warmEngineRacingCarbThrottleVolume = Settings.AddSlider(this, "warmEngineRacingCarbThrottleVolumeSlider", "Warm engine Throttle volume (Racing carburetors)", 0f, 3.0f, 1.0f);
            warmEngineRacingCarbNoThrottlePitch = Settings.AddSlider(this, "warmEngineRacingCarbNoThrottlePitchSlider", "Warm engine No Throttle pitch (Racing carburetors)", 0f, 3.0f, 1.0f);
            warmEngineRacingCarbNoThrottleVolume = Settings.AddSlider(this, "warmEngineRacingCarbNoThrottleVolumeSlider", "Warm engine No Throttle volume (Racing carburetors)", 0f, 3.0f, 1.0f);
            Settings.AddText(this, "");
            Settings.AddButton("APPLY SETTINGS", RefreshSettings);

        }



        private void Mod_OnMenuLoad()
        {
            // Called once, when the mod is loaded in the main menu
        }
        private void Mod_OnNewGame()
        {
            // Called once, when creating a new game. This is useful for deleting old mod saves
        }
        private void Mod_PreLoad()
        {
            // Called once, right after GAME scene loads but before the game is fully loaded
        }
        public void Mod_OnLoad()
        {
            instanceMod = this;

            ColdEngineCarburators.Mod_OnLoad();
            WarmEngineCarburators.Mod_OnLoad();
            Exhaust.Mod_OnLoad();

            RefreshSettings();

            startedOrNot = false;



            engineGas = GameObject.Find("SATSUMA(557kg, 248)").transform.GetChild(40);
            engineGasRelease = GameObject.Find("SATSUMA(557kg, 248)").transform.GetChild(41);
            transmission = GameObject.Find("SATSUMA(557kg, 248)").transform.GetChild(42);
            brakes = GameObject.Find("SATSUMA(557kg, 248)").transform.GetChild(43);

            fromMufflerExhaust = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Exhaust/FromMuffler");
            fromHeadersExhaust = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Exhaust/FromHeaders");
            fromPipeExhaust = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Exhaust/FromPipe");
            fromEngineExhaust = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Exhaust/FromEngine");
            exhaustGameObject = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Exhaust");

            coolingSatsuma = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Car/Cooling");
            coolingFsm = coolingSatsuma.GetComponent<PlayMakerFSM>();

            powerOn = GameObject.Find("SATSUMA(557kg, 248)/Electricity/PowerON");



            AudioSource engineGasAudio = engineGas.GetComponent<AudioSource>();
            AudioSource engineGasReleaseAudio = engineGasRelease.GetComponent<AudioSource>();

            AssetBundle satsumaSoundCustomizerBundle = LoadAssets.LoadBundle("SatsumaSoundCustomizer.ModAssets.satsumasoundcustomizer.unity3d");
            AudioClip silenceClip = satsumaSoundCustomizerBundle.LoadAsset<AudioClip>("silence");

            engineGasAudio.clip = silenceClip;
            engineGasReleaseAudio.clip = silenceClip;

        }
        private void Mod_PostLoad()
        {
            // Called once, after all mods finished OnLoad
        }
        private void Mod_OnSave()
        {
            // Called once, when save and quit
            // Serialize your save file here.
        }
        private void Mod_OnGUI()
        {
            // Draw unity OnGUI() here
        }
        private void Mod_Update()
        {



            if (powerOn.activeSelf == true && startedOrNot == false)
            {
                PowerON();
            }
            if (powerOn.activeSelf == false && startedOrNot == true)
            {
                activeTimer += Time.deltaTime;

                if (activeTimer >= 1)
                {
                    startedOrNot = false;
                    proccesCanRepeat = false;
                    repeatOrNot = false;
                    coldLoop = false;
                    RefreshSettings();
                    // !!! for changing volumes and pitch. start the car, DONT TURN OFF YET! set the sliders to your desired values. turn of the car and start again. the settings should apply ingame
                    ModConsole.Print("it can change sounds again");
                    activeTimer = 0;
                }
            }
        }
        private void Mod_FixedUpdate()
        {
            // FixedUpdate is called once per fixed frame
        }

        public void PowerON()
        {

            activeTimer1 += Time.deltaTime;

            if (activeTimer1 >= 0.1f && proccesCanRepeat == false)
            {
                activeTimer1 = 0f;
                coolantTemp = coolingFsm.FsmVariables.GetFsmFloat("CoolantTemp").Value;

                if (coolantTemp <= 69 && coldStartSettingBool == true)
                {
                    // Calls Cold Engine Carburators
                    // Calls Exhaust
                    if (coldLoop == false)
                    {
                        Exhaust.ExhaustSoundChange();
                        ColdEngineCarburators.ColdEngineCarburatorsSounds();
                        coldLoop = true;
                    }

                }
                else if (coolantTemp >= 70 && coldStartSettingBool == true)
                {
                    // Calls Warm Engine Carburators
                    // Calls Exhaust
                    ModConsole.Print("coolant warm");
                    proccesCanRepeat = true;
                    startedOrNot = true;
                    Exhaust.ExhaustSoundChange();
                    WarmEngineCarburators.WarmEngineCarburatorsSounds();
                }
                else if (coldStartSettingBool == false)
                {
                    // Calls Warm Engine Carburators
                    // Calls Exhaust
                    proccesCanRepeat = true;
                    startedOrNot = true;
                    Exhaust.ExhaustSoundChange();
                    WarmEngineCarburators.WarmEngineCarburatorsSounds();
                }
            }
        }
        public void RefreshSettings()
        {
            // APPLIES SETTINGS IN GAME. YOU HAVE TO TURN OFF AND ON THE CAR TO APPLY CHANGES 
            coldStartSettingBool = coldStartSetting.GetValue();

            coldEngineStockCarbThrottlePitchFloat = coldEngineStockCarbThrottlePitch.GetValue();
            coldEngineStockCarbThrottleVolumeFloat = coldEngineStockCarbThrottleVolume.GetValue();
            coldEngineStockCarbNoThrottlePitchFloat = coldEngineStockCarbNoThrottlePitch.GetValue();
            coldEngineStockCarbNoThrottleVolumeFloat = coldEngineStockCarbNoThrottleVolume.GetValue();

            coldEngineTwinCarbThrottlePitchFloat = coldEngineTwinCarbThrottlePitch.GetValue();
            coldEngineTwinCarbThrottleVolumeFloat = coldEngineTwinCarbThrottleVolume.GetValue();
            coldEngineTwinCarbNoThrottlePitchFloat = coldEngineTwinCarbNoThrottlePitch.GetValue();
            coldEngineTwinCarbNoThrottleVolumeFloat = coldEngineTwinCarbNoThrottleVolume.GetValue();

            coldEngineRacingCarbThrottlePitchFloat = coldEngineRacingCarbThrottlePitch.GetValue();
            coldEngineRacingCarbThrottleVolumeFloat = coldEngineRacingCarbThrottleVolume.GetValue();
            coldEngineRacingCarbNoThrottlePitchFloat = coldEngineRacingCarbNoThrottlePitch.GetValue();
            coldEngineRacingCarbNoThrottleVolumeFloat = coldEngineRacingCarbNoThrottleVolume.GetValue();

            warmEngineStockCarbThrottlePitchFloat = warmEngineStockCarbThrottlePitch.GetValue();
            warmEngineStockCarbThrottleVolumeFloat = warmEngineStockCarbThrottleVolume.GetValue();
            warmEngineStockCarbNoThrottlePitchFloat = warmEngineStockCarbNoThrottlePitch.GetValue();
            warmEngineStockCarbNoThrottleVolumeFloat = warmEngineStockCarbNoThrottleVolume.GetValue();

            warmEngineTwinCarbThrottlePitchFloat = warmEngineTwinCarbThrottlePitch.GetValue();
            warmEngineTwinCarbThrottleVolumeFloat = warmEngineTwinCarbThrottleVolume.GetValue();
            warmEngineTwinCarbNoThrottlePitchFloat = warmEngineTwinCarbNoThrottlePitch.GetValue();
            warmEngineTwinCarbNoThrottleVolumeFloat = warmEngineTwinCarbNoThrottleVolume.GetValue();

            warmEngineRacingCarbThrottlePitchFloat = warmEngineRacingCarbThrottlePitch.GetValue();
            warmEngineRacingCarbThrottleVolumeFloat = warmEngineRacingCarbThrottleVolume.GetValue();
            warmEngineRacingCarbNoThrottlePitchFloat = warmEngineRacingCarbNoThrottlePitch.GetValue();
            warmEngineRacingCarbNoThrottleVolumeFloat = warmEngineRacingCarbNoThrottleVolume.GetValue();

            GameObject coolingSatsumaRefresh = GameObject.Find("SATSUMA(557kg, 248)/CarSimulation/Car/Cooling");
            PlayMakerFSM coolingFsmRefresh = coolingSatsumaRefresh.GetComponent<PlayMakerFSM>();
            float coolantTempRefresh = coolingFsmRefresh.FsmVariables.GetFsmFloat("CoolantTemp").Value;

            if (coolantTempRefresh <= 69 && coldStartSettingBool == true)
            {
                Exhaust.ExhaustSoundChange();
                WarmEngineCarburators.WarmEngineCarburatorsSounds();
                ColdEngineCarburators.ColdEngineCarburatorsSounds();
            }

            else if (coolantTempRefresh >= 70 && coldStartSettingBool == true)
            {
                Exhaust.ExhaustSoundChange();
                ColdEngineCarburators.ColdEngineCarburatorsSounds();
                WarmEngineCarburators.WarmEngineCarburatorsSounds();
            }

            else if (coldStartSettingBool == false)
            {
                Exhaust.ExhaustSoundChange();
                WarmEngineCarburators.WarmEngineCarburatorsSounds();
            }
        }
    }
}
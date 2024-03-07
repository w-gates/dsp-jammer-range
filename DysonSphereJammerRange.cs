//
// Copyright (c) 2024, Walter Gates
// All rights reserved.
//
// This source code is licensed under the BSD-style license found in the
// LICENSE.txt file in the root directory of this source tree. 
//
// Dyson Sphere Program is developed by Youthcat Studio and published by Gamera Game.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BepInEx;
using HarmonyLib;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using BepInEx.Logging;
using System.Security;
using System.Reflection;
using System.Security.Permissions;
using NGPT;
using System.Collections;
using System.Data;

[module: UnverifiableCode]
#pragma warning disable CS0618 // Type or member is obsolete
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
#pragma warning restore CS0618 // Type or member is obsolete
namespace DysonSphereJammerRange
{
    [BepInPlugin(pluginGuid, pluginName, pluginVersion)]
    [BepInProcess("DSPGAME.exe")]
    [BepInProcess("Dyson Sphere Program.exe")]
    public class DysonSphereJammerRange : BaseUnityPlugin
    {
        public const string pluginGuid = "w-gates.dysonsphereprogram.jammerrange";
        public const string pluginName = "DSP Jammer Range";
        public const string pluginVersion = "1.0.0";
        new internal static ManualLogSource Logger;
        new internal static BepInEx.Configuration.ConfigFile Config;
        Harmony harmony;

        public static BepInEx.Configuration.ConfigEntry<bool> configEnableDebug;
        public static BepInEx.Configuration.ConfigEntry<float> configBaseJammerRange;
        public static BepInEx.Configuration.ConfigEntry<bool> configIncreaseRangeWithUpgrade;

        public void Awake()
        {
            Logger = base.Logger;  // "C:\Program Files (x86)\Steam\steamapps\common\Dyson Sphere Program\BepInEx\LogOutput.log"
            Config = base.Config;
            Logger.LogDebug("Awake.");

            try
            {
                InitialConfigSetup();
            }
            catch (Exception ex)
            {
                Logger.LogError($"Awake - Unable to set up config: {ex.Message}");
                throw ex;
            }

            try
            {
                harmony = new Harmony(pluginGuid);
                harmony.PatchAll(typeof(DysonSphereJammerRange));
            }
            catch (Exception ex)
            {
                Logger.LogError($"Awake - Unable to patch: {ex.Message}");
                throw ex;
            }

            Logger.LogInfo("Awake - Initialization complete.");
        }

        [HarmonyPrefix, HarmonyPatch(typeof(GameMain), "Begin")]
        public static void GameMain_Begin_Prefix()
        {
            if (configEnableDebug.Value)
            {
                Logger.LogDebug("DSP Jammer Range: Calling - GameMain_Begin_Prefix.");
            }
            Config.Reload();
        }

        public void InitialConfigSetup()
        {
            try
            {
                configEnableDebug = Config.Bind<bool>("Config", "EnableDebug", false, "Enabling debug will add more feedback to the BepInEx console.");
                configBaseJammerRange = Config.Bind<float>("Config", "BaseJammerRange", 40f, "The base Jammer Tower range. Default is 40m, the same as the base game.");
                configIncreaseRangeWithUpgrade = Config.Bind<bool>("Config", "IncreaseWithUpgrade", true, "Increase Jammer Tower range by the same % amount granted by the EM Weapon Strengh upgrade. Max is +50% of base.");
            }
            catch (Exception ex)
            {
                Logger.LogError($"InitialConfigSetup - Bind Config: {ex.Message}");
                throw ex;
            }
        }

        [HarmonyPrefix, HarmonyPatch(typeof(TurretComponent), "Shoot_Disturb")]
        public static void TurretComponent_Shoot_Disturb_Prefix(ref PrefabDesc pdesc, ref CombatUpgradeData combatUpgradeData)
        {
            float newRange = configBaseJammerRange.Value;
            if (configIncreaseRangeWithUpgrade.Value)
            {
                newRange *= (float)((int)((double)combatUpgradeData.magneticDamageScale * 1000.0 + 0.5)) / 1000f;
            }
            pdesc.turretMaxAttackRange = newRange;

            if (configEnableDebug.Value)
            {
                Logger.LogDebug($"DSP Jammer Range: Jammer Tower Attack Range: {pdesc.turretMaxAttackRange}.");
            }
        }
    }
}
